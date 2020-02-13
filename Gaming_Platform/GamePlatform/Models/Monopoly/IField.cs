using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GamePlatform.Models
{
    public interface IField
    {
         string Name { get;  }
         FieldType Fieldtype { get; }
         bool IsOcupation { get; }
         int FieldCost { get; }
         int StayOnFieldCost { get; }
        

    }
}
