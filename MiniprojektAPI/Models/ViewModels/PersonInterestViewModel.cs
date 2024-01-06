namespace MiniprojektAPI.Models.ViewModels
{
    public class PersonInterestViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public InterestViewModel[] Interests { get; set; }
    }
}
