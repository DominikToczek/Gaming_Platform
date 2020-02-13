using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class StartField : IField
    {
        public string Name { get; private set; }

        public new object GetType => typeof(StartField);

        public FieldType Fieldtype => FieldType.Start;

        public int FieldCost => 0;
        public int StayOnFieldCost => 0;
        public bool IsOcupation => false;

        int _moneyForStay = 1000;

        public StartField()
        {

        }

        public void AddMoneyForStaty(Player player)
        {
            player.AddMoney(_moneyForStay);
        }
    }
}
