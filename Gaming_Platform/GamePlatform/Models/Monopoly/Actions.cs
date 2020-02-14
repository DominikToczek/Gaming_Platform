using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public static class Actions
    {
        public static List<Action> actions = new List<Action>
        {
        new Action("Add",100,true),
        new Action("Spend",100,false),
        };
    }

    public class Action
    {
        static public string Name { get; private set; }
        static public int Money { get; private set; }
        static public bool IsAddMoney { get; private set; }

        public Action(string name , int money , bool isAddMoney )
        {
            Name = name;
            Money = money;
            isAddMoney = IsAddMoney;
        }
   }
}
