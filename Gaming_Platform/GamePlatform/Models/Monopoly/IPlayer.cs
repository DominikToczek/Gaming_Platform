using System.Collections.Generic;

namespace GamePlatform.Models
{
    public interface IPlayer
    {
        int Id { get; set; }
        string Name { get; set; }
        string Avatar { get; set; }
        Pawn  Pawn { get; set; }

        int Money { get; set; }
        bool spendMoney(int money);
        void AddMoney(int money);

 
       

    }
}
