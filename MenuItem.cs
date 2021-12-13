using System;

namespace Cmenu
{
    public class MenuItem : IMenuItem
    {
        Action action;
        string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public MenuItem(string name, Action action)
        {
            this.name = name;
            this.action = action;
        }

        public void Run()
        {
            action();
        }
    }
}