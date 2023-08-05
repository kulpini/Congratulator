using Congratulator.Model;

namespace Congratulator.View
{
    internal class BirthdayDialog
    {
        private int frameTop;
        private int frameLeft;
        private int frameBottom;

        public BirthdayDialog(int top, int left)
        {
            frameLeft = left;
            frameTop = top;
            frameBottom = top;
        }

        public BirthdayPerson ShowNewBirthdayDialog()
        {
            Console.SetCursorPosition(frameLeft, frameTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Добавление записи:");
            frameBottom++;
            ShowNameBirthdayDialog(out string name, out DateTime date);
            ClearDialogFrame();
            return new BirthdayPerson(name, date);
        }

        public BirthdayPerson ShowDeleteBirthdayDialog()
        {
            Console.SetCursorPosition(frameLeft, frameTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Удаление записи:");
            frameBottom++;
            ShowNameBirthdayDialog(out string name, out DateTime date);
            ClearDialogFrame();
            return new BirthdayPerson(name, date);
        }

        public BirthdayPerson ShowEditBirthdayDialog(out BirthdayPerson newPerson)
        {
            Console.SetCursorPosition(frameLeft, frameTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Редактирование записи:");
            frameBottom ++;
            ShowNameBirthdayDialog(out string name, out DateTime date);
            Console.CursorLeft = frameLeft;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Новые значения:");
            frameBottom++;
            ShowNameBirthdayDialog(out string newName, out DateTime newDate);
            newPerson = new BirthdayPerson(newName, newDate);
            ClearDialogFrame();
            return new BirthdayPerson(name, date);
        }

        private void ShowNameBirthdayDialog(out string name, out DateTime birthday)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = frameLeft;
            Console.Write("Имя: ");
            Console.CursorVisible = true;
            name = Console.ReadLine();
            int cursorTop = Console.CursorTop;
            int frameWidth = Console.BufferWidth - frameLeft;
            do
            {
                Console.SetCursorPosition(frameLeft, cursorTop);
                Console.Write(new string(' ', frameWidth));
                Console.SetCursorPosition(frameLeft, cursorTop);
                Console.Write("Дата рождения: ");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out birthday));
            Console.CursorVisible = false;
            frameBottom += 2;
        }

        private void ClearDialogFrame()
        {
            int frameWidth = Console.BufferWidth - frameLeft;
            for (int i=frameTop;i<=frameBottom;i++)
            {
                Console.SetCursorPosition(frameLeft, i);
                Console.Write(new string(' ', frameWidth));
            }
        }
    }
}
