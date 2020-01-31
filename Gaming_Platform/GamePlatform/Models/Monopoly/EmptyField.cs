namespace GamePlatform.Models
{
    public class EmptyField : IField
    {
        public string Name { get; }

        public Player Ower => null;

        public int StayOnFieldCost => 0;

        public EmptyField()
        {
            Name = "Empty";
        
        }


        
    }
}
