using Congratulator.Model;

namespace Congratulator.View
{
    internal class InfoFrame
    {
        int frameTop;
        int frameBottom;
        public InfoFrame(int top)
        {
            frameTop = top;
            frameBottom = top;
        }

        public void ShowInfo(List<BirthdayPerson> birthdays)
        {
            ClearInfoFrame();
            Console.SetCursorPosition(0, frameTop);
            Console.WriteLine(new string('-', 30));
            foreach (var person in birthdays)
            {
                Console.WriteLine($"{person.Name,-25}{person.Birthday,-15:dd MMMM}{CountAge(person.Birthday),-10}");
            }
            frameBottom = Console.CursorTop;
        }

        private void ClearInfoFrame()
        {
            for (int i = frameTop; i <= frameBottom; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', 50));
            }
        }

        private static string CountAge(DateTime birthday)
        {
            int years = DateTime.Today.Year - birthday.Year;
            string yearsName = "лет";
            if (years < 5 || years > 20)
            {
                if (years % 10 == 1)
                    yearsName = "год";
                else
                    yearsName = "года";
            }
            return $"{years} {yearsName}";
        }

    }
}
