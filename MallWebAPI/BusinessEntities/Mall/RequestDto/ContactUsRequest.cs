namespace BusinessEntities.Mall.RequestDto
{
    public class ContactUsRequest : BaseRequest
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
