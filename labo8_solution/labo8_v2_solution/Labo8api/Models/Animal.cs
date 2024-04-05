namespace Labo8api.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public Animal(int id, string type, string name)
        {
            Id = id;
            Type = type;
            Name = name;
        }
    }
}
