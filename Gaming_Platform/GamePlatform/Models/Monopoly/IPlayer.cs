namespace GamePlatform.Models
{
    public interface IPlayer
    {
        string Name { get; }
        //List<Pawn>  Pawns { get; }
        int Money { get; }
        bool spendMoney(int Money);

        void AddMoney(int Money);

    }
}
