using System.Xml.Serialization;

namespace Congratulator.Model
{
    public class BirthdayPersons
    {
        private readonly List<BirthdayPerson> BirthdayPersonList;
        const int NEAREST_DAYS_AMOUNT = 7;
        public BirthdayPersons()
        {
            BirthdayPersonList = LoadListFromFile();
        }

        public void AddBirthdayPerson(BirthdayPerson person)
        {
            BirthdayPersonList.Add(person);
            SaveListToFile();
        }

        public void DeleteBirthdayPerson(BirthdayPerson person)
        {
            int index = BirthdayPersonList.FindIndex(p => p.Name == person.Name & p.Birthday == person.Birthday);
            if (index != -1)
            {
                BirthdayPersonList.RemoveAt(index);
                SaveListToFile();
            }
        }

        public void EditBirthdayPerson(BirthdayPerson person, BirthdayPerson newPerson)
        {
            int index = BirthdayPersonList.FindIndex(p => p.Name == person.Name & p.Birthday == person.Birthday);
            if (index != -1)
            {
                BirthdayPersonList[index].Name = newPerson.Name;
                BirthdayPersonList[index].Birthday = newPerson.Birthday;
                SaveListToFile();
            }
        }

        public List<BirthdayPerson> GetAllBirthdays()
        {
            return BirthdayPersonList.OrderBy(p => p.Birthday.Month & p.Birthday.Day).ToList();
        }

        public List<BirthdayPerson> GetNearestBirtdays()
        {
            int currentMonth = DateTime.Today.Month;
            int currentDay = DateTime.Today.Day;
            DateTime nearestDate = DateTime.Today.AddDays(NEAREST_DAYS_AMOUNT);
            int nearestMonth = nearestDate.Month;
            int nearestDay = nearestDate.Day;
            return BirthdayPersonList.Where
                (p => p.Birthday.Month >= currentMonth & p.Birthday.Day >= currentDay
                    & p.Birthday.Month <= nearestMonth & p.Birthday.Day <= nearestDay)
                .OrderBy(p => p.Birthday.Month & p.Birthday.Day).ToList();
        }

        private void SaveListToFile()
        {
            XmlSerializer xmlSerializer = new(typeof(List<BirthdayPerson>));
            using FileStream stream = new("birthdays.xml", FileMode.OpenOrCreate);
            xmlSerializer.Serialize(stream, BirthdayPersonList);
        }

        private static List<BirthdayPerson> LoadListFromFile()
        {
            XmlSerializer xmlSerializer = new(typeof(List<BirthdayPerson>));
            try
            {
                using FileStream stream = new("birthdays.xml", FileMode.Open);
                if (xmlSerializer.Deserialize(stream) is List<BirthdayPerson> list)
                {
                    return list;
                }
                else
                {
                    return new List<BirthdayPerson>();
                }
            }
            catch
            {
                return new List<BirthdayPerson>();
            }
        }
    }
}
