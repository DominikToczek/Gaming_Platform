namespace GamePlatform.Models
{
    public class EmptyField : IField
    {
        public string Name { get; }

        public FieldType Fieldtype => FieldType.Empty;

        public new object GetType => typeof(EmptyField);

        public bool IsOcupation => false;
        public int FieldCost => 0;
        public int StayOnFieldCost => 0;

        public EmptyField()
        {
            Name = "Empty";
      
        }

    }
}
