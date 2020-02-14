using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class Game
    {
        public List<Player> Players { get; private set; }
        public Board board { get; private set; }
        public Player SelectedPlayer => _selectedPlayer;
        Dice dice;
        Player _selectedPlayer;

        public Game()
        {
            Players = new List<Player>();
            board = new Board();
            dice = new Dice();
        }

        public Player GetPlayer(int id)
        {
            return Players[id - 1];
        }

        public void SetPlayer( int idPlayer)
        {
            _selectedPlayer = Players[idPlayer-1];
        }

        public void NextPlayer()
        {
            _selectedPlayer = Players[NextPlayerId() - 1];
        }
        

        public int NextPlayerId()
        {
            if (_selectedPlayer.Id < Players.Count)
                return _selectedPlayer.Id + 1;
            else
                return 1;
        }



        public void DiceRoll()
        {
            _selectedPlayer.Pawn.Move(dice.Rol(), board.NumberOfField);
        }

        public void BuyField()
        {
            (board.GetFiels(_selectedPlayer.Pawn.ActualPosition) as FieldWithCity).BuyField(_selectedPlayer);    
        }
        public void BuyHotel()
        {
            (board.GetFiels(_selectedPlayer.Pawn.ActualPosition) as FieldWithCity).BuyHotel(_selectedPlayer);
        }

        public void BuyHome(int numberOfHome)
        {
            for (int i = 0; i < numberOfHome; i++)
            {
                (board.GetFiels(_selectedPlayer.Pawn.ActualPosition) as FieldWithCity).BuyHotel(_selectedPlayer);
            }
        }

        public void MovePawn(int number)
        {
            _selectedPlayer.Pawn.Move(number, board.NumberOfField);
            var actualField = board.GetFiels(_selectedPlayer.Pawn.ActualPosition);
            if(actualField.IsOcupation)
            {
                var fieldCity = actualField as FieldWithCity;
                if (fieldCity.Ower.Id != _selectedPlayer.Id)
                    fieldCity.PayForStay(_selectedPlayer);
            }
        }

        public void SellField(int idFild)
        {
            (board.GetFiels(idFild) as FieldWithCity).SellField(_selectedPlayer);
        }

        public List<Player> InitPlayer(Player[] playersData)
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < playersData.Length; i++)
            {
                Pawn pawn = new Pawn(playersData[i].Pawn.Color, i + 1, 0);
                players.Add(new Player(i + 1, playersData[i].Name, playersData[i].Avatar, 10000, pawn));
            }
            _selectedPlayer = players[0];
            Players = players;
            return players;
        }

        public object CreateObjectToView()
        {
            var actualField = board.GetFiels(_selectedPlayer.Pawn.ActualPosition);
            var actualFiladType = actualField.Fieldtype;

            return new
            {
                IDPlayer = SelectedPlayer.Id,
                numberOfMeshes = dice.LastRoll,
                currentPlayerField = SelectedPlayer.Pawn.ActualPosition,
                actionField = (actualField is FieldWithCity) ?false:true,
                actioNumber = 0,
                ocupation = actualField.IsOcupation,
                ocupationByPlayerTurn = (actualField.IsOcupation) ? (actualField as FieldWithCity).Ower.Id == SelectedPlayer.Id : false,
                IDOfOccupationFieldPlayer = (actualField.IsOcupation) ? (actualField as FieldWithCity).Ower?.Id : -1,
                payingForVisitOcupationField = (actualField.IsOcupation) ? (actualField as FieldWithCity).StayOnFieldCost : -1,
                canBuyHotel = (actualField.Fieldtype == FieldType.City) ? (actualField as FieldWithCity).CanBuyHotel : false,
                IDOfNextPlayer = NextPlayerId(),
                bankrupt = _selectedPlayer.Money <= 0,
                houseCost = (actualField.Fieldtype == FieldType.City) ? (actualField as FieldWithCity).HouseCost:-1,
                hotelCost = (actualField.Fieldtype == FieldType.City) ? (actualField as FieldWithCity).HotelCost:-1,
            };

        }
    //IDPlayer: 1,//int
    //numberOfMeshes: 2, //int
    //currentPlayerField: 25, //int
    //actionField: true,//true or false
    //actioNumber: 2,//int
    //ocupation: true,//true or false
    //ocupationByPlayerTurn: true, //true or false
    //IDOfOccupationFieldPlayer: 2,//int
    //payingForVisitOcupationField: 2,//int
    //canBuyHotel: true,//true or false
    //IDOfNextPlayer: 2,//int
    //bankrupt: true, //true or false


    }
}