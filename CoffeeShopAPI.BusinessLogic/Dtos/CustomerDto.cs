namespace CoffeeShopAPI.BusinessLogic.Dtos
{
    public class CustomerDto
    {
        public string Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Grade { get; }
        public decimal Discount { get; }

        public CustomerDto(string id, string name, string email, string grade, decimal discount)
        {
            Id = id;
            Name = name;
            Email = email;
            Grade = grade;
            Discount = discount;
        }
    }
}