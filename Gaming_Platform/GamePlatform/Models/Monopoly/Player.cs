using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class Player :IPlayer
    {
        public int Money { get;  set; }
        public string Name { get;  set; }
        public Pawn Pawns { get; set; }

        public Player(string name , int money , Pawn pawn)
        {
            Name = name;
            Money = money;
            Pawns = pawn;
        }


        public void AddMoney(int Money)
        {
            this.Money += Money;
        }

        public bool spendMoney(int Money)
        {
           if(this.Money >= 0 &&  (this.Money - Money)>=0 )
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
