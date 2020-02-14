public enum FieldState
{
    EmptyField = 1,
    Home = 2,
    Home2 = 3,
    Home3 = 4,
    Hotel = 5
}

namespace GamePlatform.Models
{
    public class FieldWithCity : IField
    {
        int _fieldCost;
        int _stayOnFieldCost;

        public int FieldCost
        {
            get => _fieldCost * (int)_fieldState;

            private set => _fieldCost = value;
        }
        public int StayOnFieldCost
        {
            get => _stayOnFieldCost * (int)_fieldState;
            private set => _stayOnFieldCost = value;
        }
        public string Name { get; }
        public Player Ower { get; private set; }
        public FieldState GetFieldState => _fieldState;
        public int HouseCost => _fieldCost * ((int)_fieldState + 1);
        public int HotelCost => _fieldCost * (int)FieldState.Hotel;
        public bool CanBuyHotel => GetFieldState == FieldState.Home3;
        public FieldType Fieldtype => FieldType.City;
        public new object GetType =>  typeof(FieldWithCity);
        public bool IsOcupation => !(Ower is null);
        private FieldState _fieldState;


        public FieldWithCity(string name, int fieldCost, int stayOnFieldCost)
        {
            Name = name;
            FieldCost = fieldCost;
            StayOnFieldCost = stayOnFieldCost;
            Ower = null;
            _fieldState = FieldState.EmptyField;

        }

        /// <summary>
        /// Ustwienie słaściciela pola
        /// </summary>
        /// <returns>Zwraca false jak pole już do kogoś należy</returns>
        public bool SetOwer(Player player)
        {
            if (Ower is null)
            {
                Ower = player;
                return true;
            }

            return false;
        }

        public bool BuyField(Player player)
        {
            if (Ower is null)
            {
                if (player.Money < FieldCost)
                {
                    return false;
                }
                else
                {
                    SetOwer(player);
                    player.spendMoney(FieldCost);
                    return true;
                }
            }
            else
            {
                return false;
            }



        }

        public bool SellField(Player player)
        {
            if (!(Ower is null))
            {
                if (player.Id == Ower.Id)
                {
                    Ower = null;
                    player.AddMoney(FieldCost);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool PayForStay(Player player)
        {
            if (!(Ower is null))
            {
                if (player.Money >= StayOnFieldCost)
                {
                    player.spendMoney(StayOnFieldCost);
                    Ower.AddMoney(StayOnFieldCost);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public bool BuyHome(Player player)
        {
            if (!(Ower is null))
            {
                if (
                                (player.spendMoney(FieldCost) &&
                                (_fieldState >= FieldState.EmptyField && _fieldState < FieldState.Home3)) &&
                                player.Id == Ower.Id)
                {
                    switch (_fieldState)
                    {
                        case FieldState.EmptyField:
                            _fieldState = FieldState.Home;
                            break;
                        case FieldState.Home:
                            _fieldState = FieldState.Home2;
                            break;
                        case FieldState.Home2:
                            _fieldState = FieldState.Home3;
                            break;

                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }

        }

        public bool BuyHotel(Player player)
        {
            if(!(Ower is null))
            {
                if ((player.spendMoney(FieldCost) && _fieldState == FieldState.Home3) &&
               player.Id == Ower.Id)
                {
                    _fieldState = FieldState.Hotel;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           

        }

    }
}
