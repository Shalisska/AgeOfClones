namespace Application.Management.Models
{
    public class StockManagementModel
    {
        public StockManagementModel() { }

        public StockManagementModel(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
