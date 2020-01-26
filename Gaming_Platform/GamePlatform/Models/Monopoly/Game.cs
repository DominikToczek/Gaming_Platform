using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class Game
    {
        public List<Player> Players;
        public string aaa = "Dadad";

        public Game()
        {
            Players = initializationPlayer();


        }

        public Player GetPlayer(int id)
        {
            return Players[id - 1];
        }

        List<Player> initializationPlayer()
        {
            var pawn = new Pawn("red", 1, 1);
            List<Player> players = new List<Player>(); ;
            players.Add(new Player("Kamil", 0, pawn));
            players.Add(new Player("Ola", 0, pawn));
            players.Add(new Player("Daniel", 0, pawn));
            players.Add(new Player("Kuba", 0, pawn));
            return players;

          
        }
    }
}
