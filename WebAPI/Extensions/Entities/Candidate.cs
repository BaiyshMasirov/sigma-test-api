using WebAPI.Extensions.Entities.Common;

namespace WebAPI.Extensions.Entities
{
    public class Candidate : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsNeedCall { get; set; }
        public DateTime? CallStartDate { get; set; }
        public DateTime? CallEndDate { get; set; }
        public string LinkedinProfile { get; set; }
        public string GitHubProfile { get; set; }
        public string Comment { get; set; }
    }
}