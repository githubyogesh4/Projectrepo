namespace BusinessEntities.Mall.ResponseDto
{
    public class ContactUsResponse //: BaseResponse
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
