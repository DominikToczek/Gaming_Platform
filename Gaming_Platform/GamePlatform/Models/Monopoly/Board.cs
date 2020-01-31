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
            return _fields.Where(x => x.Ower?.Id == player.Id).ToList();
        }
        public List<IField> GetAllField => _fields;

        private void CreateBoard()
        {
            _fields = new List<IField>();
            _fields.Add(new StartField());
            _fields.Add(new FieldWithCity("Brenada", 1000, 1000));
            _fields.Add(new FieldWithCity("Sewilla", 1000, 1000));
            _fields.Add(new FieldWithCity("Madryt", 1000, 1000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Hongkong", 1000, 1000));
            _fields.Add(new FieldWithCity("Pekin", 1000, 1000));
            _fields.Add(new FieldWithCity("Szanghaj", 1000, 1000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Wenecja", 1000, 1000));
            _fields.Add(new FieldWithCity("Mediolan", 1000, 1000));
            _fields.Add(new FieldWithCity("Rzym", 1000, 1000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Hamburg", 1000, 1000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Berlin", 1000, 1000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Londyn", 1000, 1000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Sydnej", 1000, 1000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Chicago", 1000, 1000));
            _fields.Add(new FieldWithCity("LasVegas", 1000, 1000));
            _fields.Add(new FieldWithCity("NewYork", 1000, 1000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Londyn", 1000, 1000));
            _fields.Add(new FieldWithCity("Paryż", 1000, 1000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Karkow", 1000, 1000));
            _fields.Add(new EmptyField());
            _fields.Add(new FieldWithCity("Warszawa", 1000, 1000));
        }

    }
}
