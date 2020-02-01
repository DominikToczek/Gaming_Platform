using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class Player : IPlayer
    {
        public int Id { get; set; }
        public int Money { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public Pawn Pawn { get; set; }

        public Player()
        {

        }


        public Player(int id, string name, string avatar, int money, Pawn pawn)
        {
            Id = id;
            Name = name;
            Avatar = avatar;
            Money = money;
            Pawn = pawn;
        }

        public void AddMoney(int Money)
        {
            this.Money += Money;
        }

        public bool spendMoney(int Money)
        {
            if (this.Money >= 0 && (this.Money - Money) >= 0)
            {
                this.Money -= Money;
                return true;
            }
            else
            {
                return false;

            }

        }


    }


}