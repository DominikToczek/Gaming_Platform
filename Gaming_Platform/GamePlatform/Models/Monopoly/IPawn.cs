namespace GamePlatform.Models
{
    public interface IPawn
    {
        string Color { get; set; }
        int Number { get; set; }
        int ActualPosition { get; set; }

        void Move(int number,int numberOfField);
        bool SetOnField(int number ,int numberOfField);


    }
}
