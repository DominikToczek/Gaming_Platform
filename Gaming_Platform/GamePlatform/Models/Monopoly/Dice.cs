using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class Dice
    {

        public int LastRoll { get; private set; } 
        Random rnd = new Random();
        int _max;
        int _min;
        

        public Dice(int min = 1 , int max =6)
        {
            _min = min;
            _max = max;
            LastRoll = 0;
        }


        public  int  Rol()
        {
            LastRoll = rnd.Next(_min, _max);
            return LastRoll;
        }
            

    }
}
