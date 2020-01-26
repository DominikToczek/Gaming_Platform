using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum FieldState
{
    EmptyField=1,
    Home=2,
    Hotel=4
}

namespace GamePlatform.Models
{
    public class FieldWithCity:IField
    {
        int _fieldCost;
        int _stayOnFieldCost;

        
        public int FieldCost
        {
            get => FieldCost * (int) _fieldState;

            set
            {
                _fieldCost = value;
            }
        }
        public int StayOnFieldCost
        {
            get => _stayOnFieldCost * (int)_fieldState;
            set
            {
                _stayOnFieldCost = value;
            }
        }
        public string Name { get; }
        public Player Ower { get; private set; }
        private FieldState _fieldState;


        public FieldWithCity(string name , int fieldCost ,int stayOnFieldCost )
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
            if(Ower is null)
            {
                Ower = player;
                return true;
            }

            return false;
        }

        public bool BuyField(Player player)
        {
            if( player.Money <= FieldCost)
            {
                return false;
            }
            else
            {
                Ower = player;
                player.spendMoney(FieldCost);
                return true;
            }
        }

        public bool SellField(Player player)
        {
            if(player==Ower)
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

        public bool PayForStay(Player player)
        {
            if(player.Money >= StayOnFieldCost)
            {
                player.spendMoney(StayOnFieldCost);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BuyHome(Player player)
        {
            if(player.spendMoney(FieldCost))
            {
                _fieldState = FieldState.Home;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool BuyHotel(Player player)
        {
            if (player.spendMoney(FieldCost))
            {
                _fieldState = FieldState.Hotel;
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
