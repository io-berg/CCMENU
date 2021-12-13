using System;
using System.Collections.Generic;

namespace Cmenu
{
    public enum menuStyle
    {
        Numeric,
        Arrows,
        Aplhabetical,
        ByName
    }

    public class Menu : IMenuItem, IPrintableMenu
    {
        menuStyle style;
        string menuHeader;
        List<IMenuItem> menuItems = new();


        public int lastSelectedIndex { get; set; }
        public List<IMenuItem> Options { get { return menuItems; } }
        public int Length { get { return menuItems.Count; } }
        public string Name { get { return menuHeader; } }
        public menuStyle Style
        {
            get
            {
                return style;
            }
            set
            {
                style = (menuStyle)value;
            }
        }



        /// <summary>
        /// Add menuitems and run the menu with the Run() method.
        /// </summary>
        /// <param name="menuHeader">The text which will appear at the top of the menu</param>
        /// <param name="style">Decides the style of the menu. 
        /// 1 = numeric, 2 = arrows, 3 = alphabetical</param>
        public Menu(string menuHeader, int style = 0)
        {
            this.menuHeader = menuHeader;
            this.style = (menuStyle)style;
            this.lastSelectedIndex = 0;
        }

        /// <summary>
        /// Takes an object implementing the IMenuItem interface and adds it to the menu.
        /// </summary>
        /// <param name="item">The menuItem you wish to add to the menu</param>
        public void AddItem(IMenuItem item)
        {
            menuItems.Add(item);
        }

        public void PrintMenu(Menu menu)
        {
            Console.WriteLine(menuHeader);
            for (int i = 1; i <= menuItems.Count; i++)
            {
                Console.WriteLine($"{i}. {menuItems[i - 1].Name}");
            }
        }

        public void Run()
        {
            if (this.style == menuStyle.Numeric) RunNumeric();
            else if (this.style == menuStyle.Arrows) RunArrows();
            else if (this.style == menuStyle.Aplhabetical) RunAlphabetical();
            else if (this.style == menuStyle.ByName) RunByName();
        }

        private void RunByName()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        private void RunAlphabetical()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        private void RunArrows()
        {
            while (true)
            {
                Console.Clear();
                MenuPrinter.PrintMenu(this);
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (lastSelectedIndex == 0) lastSelectedIndex = this.Length - 1;
                    else lastSelectedIndex--;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (lastSelectedIndex == this.Length - 1) lastSelectedIndex = 0;
                    else lastSelectedIndex++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    RunItem(lastSelectedIndex);
                }
                else if (key == ConsoleKey.Escape) break;
            }
        }

        public void RunNumeric()
        {
            while (true)
            {
                MenuPrinter.PrintMenu(this);
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                {
                    break;
                }
                RunItem(((int)key) - 49); // -49 instea of 48 to get the correct index
            }
        }

        public void RunItem(int index)
        {
            if (index < 0 || index >= menuItems.Count)
            {
                throw new ArgumentException("Index out of range");
            }
            lastSelectedIndex = index;
            menuItems[index].Run();
        }
    }
}