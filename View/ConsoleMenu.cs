namespace Congratulator.View
{
    internal class ConsoleMenu
    {
        readonly List<MenuItem> MenuItems;
        int SelectedItem;

        public ConsoleMenu(List<MenuItem> items, int selectedItem = -1)
        {
            MenuItems = items;
            SelectedItem = selectedItem;
            if (selectedItem>-1)
            {
                //MenuItems[SelectedItem].ExecutedAction();
            }
            ShowMenu();
        }

        public void Run()
        {
            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        MoveDown();
                        break;
                    case ConsoleKey.UpArrow:
                        MoveUp();
                        break;
                    case ConsoleKey.Enter:
                        MenuItems[SelectedItem].ExecutedAction();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.SetCursorPosition(0, 0);
            ShowMenuItems();
            Console.CursorVisible = false;
        }

        private void ShowMenuItems()
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (i == SelectedItem)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(MenuItems[i].Title);
                //Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void MoveDown()
        {
            if (SelectedItem < MenuItems.Count - 1)
            {
                SelectedItem++;
                ShowMenu();
            }
        }

        private void MoveUp()
        {
            if (SelectedItem > 0)
            {
                SelectedItem--;
                ShowMenu();
            }
        }
    }
}
