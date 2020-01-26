using System.Collections.Generic;

namespace GamePlatform.Models
{
    public interface IPlayer
    {
        string Name { get; set; }
      
        Pawn  Pawns { get; set; }
        int Money { get; set; }
        bool spendMoney(int money);

        void AddMoney(int money);

 
       

    }
}
