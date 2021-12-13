using System.Collections.Generic;

namespace Cmenu
{
    public interface IPrintableMenu
    {
        string Name { get; }
        menuStyle Style { get; }
        List<IMenuItem> Options { get; }
        int lastSelectedIndex { get; set; }
    }
}