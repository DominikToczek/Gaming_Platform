﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class StartField : IField
    {
        public string Name { get; private set; }
        public bool IsOccupied { get ; set ; }
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
