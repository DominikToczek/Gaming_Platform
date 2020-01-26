namespace GamePlatform.Models
{
    public class EmptyField : IField
    {
        public string Name { get; }
       
        public EmptyField()
        {
            Name = "Empty";
        
        }


        
    }
}
