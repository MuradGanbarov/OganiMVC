using System.ComponentModel.DataAnnotations;

namespace OganiMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Uzunluqu 25 xarakterden chox olmamalidir")]
        [Required(ErrorMessage = "Ad mutleq daxil edilmelidir")]
        public string Name { get; set; }

        public string ImageURL { get; set; }
        public decimal Price { get; set; }

        public DateTime CreateTime { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
