
namespace Assignment.Domain
{
    public class ProductDomain
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
      
        private ProductDomain(int id, string name, string description, DateTime createdDate)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedDate = createdDate;
        }

       
        public static ProductDomain Create(string name, string description, DateTime createdDate)
        {
            return new ProductDomain(0, name, description, createdDate);
        }


        public void UpdateDetails(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
