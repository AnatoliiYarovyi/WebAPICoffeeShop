using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Models.Customers
{
    public class CreateCustomerRequest
    {
        [Required]
        public string Type { get; init; }
        [Required]
        public string Name { get; init; }
        [Required]
        public string Email { get; init; }
    }
}