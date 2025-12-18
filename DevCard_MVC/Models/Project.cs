using System.Text;

namespace DevCard_MVC.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }

        public Project(int id, string name, string description, string client)
        {
            Id = id;
            Name = name;
            Description = description;
            Client = client;
        }
    }
}
