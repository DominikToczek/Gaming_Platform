using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class Dice
    {
        Random rnd = new Random();
        int _max;
        int _min;

        public Dice(int min = 1 , int max =6)
        {
            _min = min;
            _max = max;
        }


        public  int  Rol() => rnd.Next(_min, _max);

    }
}
