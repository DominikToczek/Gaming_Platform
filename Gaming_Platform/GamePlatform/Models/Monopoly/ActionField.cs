using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class ActionField : IField
    {
        public string Name { get; }
        public FieldType Fieldtype => FieldType.Action;
        public bool IsOcupation => false;
        public int FieldCost => 0;
        public int StayOnFieldCost => 0;

        public ActionField(string name )
        {
            Name = name;
        }

        public Action GetAction()
        {
          Random rnd = new Random();
          return  Actions.actions[rnd.Next(0, Actions.actions.Count)];
        }
    }
}
