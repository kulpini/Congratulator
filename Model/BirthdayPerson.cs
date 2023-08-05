namespace Congratulator.Model
{
    public class BirthdayPerson
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public BirthdayPerson() { }

        public BirthdayPerson(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
}
