namespace MiniprojektAPI.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }

        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
