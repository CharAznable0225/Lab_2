using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{

    public class Player
    {
        public string Name { get; private set; }

      
        public List<Item> Inventory { get; private set; } = new List<Item>();

        public Player(string name)
        {
            Name = name;
        }

        
        public void ShowInventory()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Inventory[i].Name}");
            }
        }

       
        public void UseItem(int index)
        {
            if (index < 0 || index >= Inventory.Count)
            {
                Console.WriteLine("Invalid item selection.");
                return;
            }

            Item item = Inventory[index];
            item.Use(this); 
            Inventory.RemoveAt(index); 
        }
    }
}
