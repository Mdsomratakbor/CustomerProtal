namespace CustomerInfo.API.DTO
{
    public class AddressEditDTO : AddressDTO 
    {
        public int CustomerId { get; set; }
        public int Id { get; set; }
    }
}
