namespace CustomerRegistration.Domain.Entities
{
    public class Address
    {
        public Guid AddressId { get; set; }  // address_id (chave primária)
        public Guid CustomerId { get; set; }  // customer_id (chave estrangeira)
        public string? Street { get; set; }  // street (opcional)
        public int? Number { get; set; }  // number (opcional)
        public string? Neighborhood { get; set; }  // neighborhood (opcional)
        public string? City { get; set; }  // city (opcional)
        public string? State { get; set; }  // state (opcional, 2 caracteres)
        public string? PostalCode { get; set; }  // postal_code (opcional, 8 caracteres)
    }
}
