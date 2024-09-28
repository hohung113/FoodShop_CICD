namespace PizzaStore.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
