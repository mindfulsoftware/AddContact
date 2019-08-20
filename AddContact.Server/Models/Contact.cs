namespace AddContact.Server.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
    }
}
