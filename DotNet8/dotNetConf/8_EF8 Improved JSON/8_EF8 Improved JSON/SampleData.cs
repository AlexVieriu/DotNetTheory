namespace _8_EF8_Improved_JSON;

public class SampleData
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime Visits { get; set; }
        public int Detailid { get; set; }
        public DateTime MemberSince { get; set; }
    }

    public class CustomerDetails
    {
        public int CustomerDetailsId { get; set; }
        public string Region { get; set; }
        public string Notes { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Pestende { get; set; }
        public string Country { get; set; }
        public bool Primary { get; set; }
        public int CustomerDetailsId { get; set; }
    }

    public class Phone
    {
        public int PhoneId { get; set; }
        public string CountryCode { get; set; }
        public string Number { get; set; }
        public bool Primary { get; set; }
        public int CustomerDetailsId { get; set; }
    }
}
