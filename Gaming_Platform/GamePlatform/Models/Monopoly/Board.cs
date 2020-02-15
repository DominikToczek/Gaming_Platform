using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GamePlatform.Models
{
    public class Board
    {
        List<IField> _fields;
        public int NumberOfField => _fields.Count;

        public  Board()
        {
            CreateBoard();        
        }

        public IField GetFiels(int id)
        {
            return _fields[id];
        }

        public List<IField> GetAllFields(Player player)
        {
            return _fields.Where(x => x.Fieldtype == FieldType.City).Where(a => (a as FieldWithCity).Ower.Id == player.Id).ToList();
        }
        public List<IField> GetAllField => _fields;

        private void CreateBoard()
        {
            _fields = new List<IField>();
            _fields.Add(new StartField());
            _fields.Add(new FieldWithCity("Sewilla", 1000, 1000));
            _fields.Add(new FieldWithCity("Venecja", 1000, 1000));
            _fields.Add(new FieldWithCity("Honk Kang", 1000, 1000));
            _fields.Add(new ActionField("Action"));
            _fields.Add(new FieldWithCity("Londyn", 2000, 2000));
            _fields.Add(new FieldWithCity("Madryt", 2000, 2000));
            _fields.Add(new FieldWithCity("Milan", 2000, 2000));
            _fields.Add(new FieldWithCity("Barcelona", 2000, 2000));
            _fields.Add(new EmptyField());
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Rome", 3000, 3000));
            _fields.Add(new FieldWithCity("Beijing", 3000, 3000));
            _fields.Add(new FieldWithCity("Birminghan", 3000, 3000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Hamburg", 4000, 4000));
            _fields.Add(new ActionField("Action"));
            _fields.Add(new FieldWithCity("Leeds", 4000, 4000));
            _fields.Add(new FieldWithCity("Shanghaj", 4000, 4000));
            _fields.Add(new FieldWithCity("Berlin", 5000, 5000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Sydnej", 6000, 6000));
            _fields.Add(new FieldWithCity("Chicago", 6000, 6000));
            _fields.Add(new FieldWithCity("Warsawa", 6000, 6000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Brisbane", 7000, 7000));
            _fields.Add(new FieldWithCity("Las Vegas", 7000, 7000));
            _fields.Add(new FieldWithCity("Rio De Janero", 8000, 8000));
            _fields.Add(new FieldWithCity("New York", 8000, 8000));
            _fields.Add(new FieldWithCity("Franfurt", 9000, 9000));
            _fields.Add(new EmptyField());
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Paris", 10000, 10000));
            _fields.Add(new FieldWithCity("Melbourne", 10000, 10000));
            _fields.Add(new FieldWithCity("Cracow", 10000, 10000));
            _fields.Add(new FieldWithCity("Marsselle", 12000, 12000));    
            _fields.Add(new ActionField("Action"));
            _fields.Add(new FieldWithCity("Sbo Paulo", 11000, 11000));
            _fields.Add(new FieldWithCity("Wroclaw", 12000, 12000));
            _fields.Add(new FieldWithCity("Londyn", 13000, 13000));
      
        }

    }
}
