using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public abstract class Pawn:IPawn
    {
        public string Color { get; }
        public int Number { get; }

        public Pawn() { }

        public Pawn(string Color , int Number)
        {
            this.Color = Color;
            this.Number = Number;
        }
    }
}
