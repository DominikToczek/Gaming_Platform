using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    class EmptyField : IField
    {
        public string Name { get; }
        public bool IsOccupied { get; set; }

    }
}
