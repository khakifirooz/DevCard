namespace DotNet9Learning.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Items(string name)
        {
            Name = name;
        }
    }
}
