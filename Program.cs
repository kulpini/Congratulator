using Congratulator.Model;
using Congratulator.View;

namespace Congratulator
{
    internal class Program
    {
        static BirthdayPersons birthdays;
        static BirthdayDialog birthdayDialog;
        static InfoFrame infoFrame;
        static int dialogTop;
        const int DIALOG_LEFT = 70;
        static void Main()
        {

            birthdays = new BirthdayPersons();
            List<MenuItem> menuItems = new()
            {
                new MenuItem("Добавить запись", AddBirthdayPerson),
                new MenuItem("Удалить запись", DeleteBirthdayPerson),
                new MenuItem("Редактировать запись", EditBirthdayPerson),
                new MenuItem("Показать всех", ShowAllBirthdays),
                new MenuItem("Показать ближайших", ShowNearestBirthdays),
                new MenuItem("Выход", ExitApplication)
            };
            dialogTop = menuItems.Count + 2;
            infoFrame = new(dialogTop);
            birthdayDialog = new(dialogTop, DIALOG_LEFT);
            ConsoleMenu mainMenu = new(menuItems, 3);
            ShowAllBirthdays();
            mainMenu.Run();
        }

        private static void AddBirthdayPerson()
        {
            BirthdayPerson newPerson = birthdayDialog.ShowNewBirthdayDialog();
            birthdays.AddBirthdayPerson(newPerson);
            ShowAllBirthdays();
        }

        private static void DeleteBirthdayPerson()
        {
            BirthdayPerson deletedPerson = birthdayDialog.ShowDeleteBirthdayDialog();
            birthdays.DeleteBirthdayPerson(deletedPerson);
            ShowAllBirthdays();
        }

        private static void EditBirthdayPerson()
        {
            BirthdayPerson editedPerson = birthdayDialog.ShowEditBirthdayDialog(out BirthdayPerson newPerson);
            birthdays.EditBirthdayPerson(editedPerson, newPerson);
            ShowAllBirthdays();
        }

        private static void ShowAllBirthdays()
        {
            var e = birthdays.GetAllBirthdays();
            infoFrame.ShowInfo(e);
        }

        private static void ShowNearestBirthdays()
        {
            infoFrame.ShowInfo(birthdays.GetNearestBirtdays());
        }

        private static void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}
