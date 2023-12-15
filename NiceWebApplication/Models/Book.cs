using NiceWebApplication.Core;

namespace NiceWebApplication.Models
{
    public class Book : IModel
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }

        public void Create(object[] arguments)
        {
            ID = (int)arguments[0];
            Name = (string)arguments[1];
            Description = (string)arguments[2];
            Genre = (string)arguments[3];
            Author = (string)arguments[4];
        }
        public override string ToString()
        {
            return $"{ID}, {Name}, {Description}, {Genre}, {Author}";
        }
    }
}
