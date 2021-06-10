namespace Repositories.Mall
{
    public class DBCustomerMaster : BaseEntity
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }             
        public string UserType { get; set; }        
        public int UserTypeId { get; set; }
    }
}
