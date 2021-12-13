using System;

namespace Cmenu
{
    internal static class MenuPrinter
    {
        internal static void PrintMenu(IPrintableMenu menu)
        {
            switch (menu.Style)
            {
                case menuStyle.Numeric:
                    PrintNumeric(menu);
                    break;
                case menuStyle.Arrows:
                    PrintArrows(menu);
                    break;
                case menuStyle.Aplhabetical:
                    PrintAlphabetical(menu);
                    break;
                default:
                    throw new ArgumentException("Menu type not supported");
            }
        }

        private static void PrintAlphabetical(IPrintableMenu menu)
        {
            throw new NotImplementedException();
        }

        private static void PrintArrows(IPrintableMenu menu)
        {
            int lastSeleced = menu.lastSelectedIndex;

            System.Console.WriteLine("    " + menu.Name);
            for (int i = 1; i <= menu.Options.Count; i++)
            {
                if (i - 1 == lastSeleced)
                {
                    System.Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write($"-> {menu.Options[i - 1].Name}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else Console.WriteLine($"   {menu.Options[i - 1].Name}");
            }
        }

        private static void PrintNumeric(IPrintableMenu menu)
        {
            Console.WriteLine(menu.Name);
            for (int i = 1; i <= menu.Options.Count; i++)
            {
                Console.WriteLine($"{i}. {menu.Options[i - 1].Name}");
            }
        }
    }
}