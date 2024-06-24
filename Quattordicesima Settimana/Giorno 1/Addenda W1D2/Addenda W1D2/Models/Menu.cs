using System.Collections.Generic;

namespace Addenda_W1D2.Models
{
    public class Menu
    {
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();

        public void AddItem(MenuItem item)
        {
            Items.Add(item);
        }
    }
}
