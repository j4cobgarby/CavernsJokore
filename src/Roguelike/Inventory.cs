using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	class Inventory
	{
		public List<Item> items { get; set; }
		private int height = 6;
		
		public Inventory()
		{
			items = new List<Item>();

			// Starting items
			items.Add(new Torch(100));
			items.Add(new Dagger());
			items.Add(new Dagger());
			items.Add(new Bread());
		}

		public void AddItem(Item item)
		{
			items.Add(item);
			Program.info.changeContent(String.Format("{0} has been added to your inventory!", item.dispName));
		}

		public void AddItem(Item item, int amount)
		{
			for (int i = 0; i < amount; i++)
			{
				items.Add(item);
			}
			Program.info.changeContent(String.Format("{0}X {1} have been added to your inventory!", 
				amount.ToString(), item.dispName));
		}

		public void Draw()
		{
			List<string> alreadyDrawn = new List<string>();
			int textY = 0;

			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.DarkMagenta;

			for (int i = 0; i < height; i++)
			{
				Console.SetCursorPosition(0, 1 + i);
				Console.Write(new string(' ', Defs.width));
			}
			for (int i = 0; i < items.Count; i++)
			{
				if (!alreadyDrawn.Contains(items[i].dispName))
				{
					textY++;

					Console.SetCursorPosition(0, textY);
					Console.Write(Helpers.CapitalizeEachWord(items[i].dispName));
					int amountInInv = Helpers.HowManyItemInInv(items[i].dispName);
					if (amountInInv > 1)
					{
						//, nX
						Console.Write(", " + amountInInv.ToString() + "X");
					}
					alreadyDrawn.Add(items[i].dispName);
				}
			}

			Console.ResetColor();
			Console.ReadKey(true);
		}
	}
}
