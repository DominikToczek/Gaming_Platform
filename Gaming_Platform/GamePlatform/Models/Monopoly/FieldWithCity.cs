using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GamePlatform.Models
{
    public class FieldWithCity:IField
    {
        public int Price { get; set; }
        public string Name { get; }
        public bool IsOccupied { get; set; }
        private Player Ower;



        /// <summary>
        /// Ustwienie słaściciela pola
        /// </summary>
        /// <returns>Zwraca false jak pole już do kogoś należy</returns>
        public bool SetOwer(Player player)
        {
            if(Ower is null)
            {
                Ower = player;
                return true;
            }

            return false;
        }


        
      



        
    }
}
