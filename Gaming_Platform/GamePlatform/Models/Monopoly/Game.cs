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

        public int DiceRoll()
        {
            return dice.Rol();
        }

        public void BuyHome(int numberOfHome , int idFild)
        {
            for(int i =0; i< numberOfHome; i++)
            {
                (board.GetFiels(idFild) as FieldWithCity).BuyHome(_selectedPlayer);
            }
        }

        public void MovePawn(int number)
        {
            _selectedPlayer.Pawn.Move(number, board.NumberOfField);
        }

        public void SelectPlayer(int number)
        {
            _selectedPlayer = Players[number];
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
                Pawn pawn = new Pawn(playersData[i].Pawn.Color, i + 1, 1);
                players.Add(new Player(i + 1, playersData[i].Name, playersData[i].Avatar, 10000, pawn));
            }
            _selectedPlayer = players[0];
            Players = players;
            return players;
        }

        public object CreateObjectToView()
        {
            var actualField = board.GetFiels(_selectedPlayer.Pawn.ActualPosition);

            return new
            {
                NumerPola = _selectedPlayer.Pawn.ActualPosition,
                TuraGracza = (_selectedPlayer.Id + 1) % 3,
                Gracze = new
                {
                    NumerGracza = _selectedPlayer.Id,
                    AktualnyStanKonat = _selectedPlayer.Money,
                    ListaPolGracza = board.GetAllFields(_selectedPlayer)
                },
                RodzajPola = "Dsd",
                Okupowanie = (actualField.Ower is null) ? false : true,
                OkupowniePrzezKogo = actualField.Ower,
                KwotaZaPostuj = actualField.StayOnFieldCost,
                NumerAkcji = "Dsd",
                PrawieBankrut = board.GetAllFields(_selectedPlayer).Count > 0 ,
                Bankrut = board.GetAllFields(_selectedPlayer).Count == 0 ,
            };

        }

       

    }
}

