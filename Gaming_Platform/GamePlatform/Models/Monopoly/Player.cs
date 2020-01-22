using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class Player :IPlayer
    {
        public int Money { get; private set; }
        public string Name { get; }
       // public List<Pawn> Pawns { get; }

        public Player(string name , int money)
        {
            Name = name;
            Money = money;
        }


        public void AddMoney(int Money)
        {
            this.Money += Money;
        }

        public bool spendMoney(int Money)
        {
           if(this.Money <= 0 &&  (this.Money - Money)<=0 )
            {
                this.Money -= Money;
                return true;
            }

            return false;
        }


    }
}
