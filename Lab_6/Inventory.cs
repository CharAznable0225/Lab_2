using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"Added {item.Name} to inventory.");
        }

        public bool HasItems() => items.Count > 0;

        public void ShowItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("Your inventory:");
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine($"{i + 1}. {items[i].Name}");
        }

        public void UseItem(Player player, int index)
        {
            if (index < 0 || index >= items.Count)
            {
                Console.WriteLine("Invalid item number.");
                return;
            }

            Item item = items[index];
            item.Use(player);
            items.RemoveAt(index);
            Console.WriteLine($"{item.Name} has been used.");
        }
    }
}
