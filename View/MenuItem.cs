namespace Congratulator.View
{
    internal class MenuItem
    {
        public string Title { get; set; }
        public delegate void ItemAction();
        public ItemAction ExecutedAction { get; set; }

        public MenuItem(string title, ItemAction action)
        {
            Title = title;
            ExecutedAction = action;
        }
}
}
