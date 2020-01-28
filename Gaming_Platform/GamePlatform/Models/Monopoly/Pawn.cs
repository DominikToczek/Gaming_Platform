using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public  class Pawn:IPawn
    {
        public string Color { get; set; }
        public int Number { get; set; }
        public int ActualPosition { get;  set; }

        public Pawn(string color , int number, int actualPosition)
        {
            Color = color;
            Number = number;
            ActualPosition = actualPosition;
        }

        public void Move(int number, int numberOfField)
        {
            ActualPosition = (number + ActualPosition) % numberOfField;
        }

        public bool SetOnField(int number, int numberOfField)
        {
            if(number<= numberOfField-1)
            {
                ActualPosition = number;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
