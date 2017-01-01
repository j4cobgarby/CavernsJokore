using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	class Inventory // The player's static inv
	{
		List<Item> items { get; set; }
		private int height = 6;
		
		public Inventory()
		{
			items = new List<Item>();
			items.Add(new PracticeSword());
			items.Add(new DragonDaggers());
		}

		public void draw()
		{
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;

			for (int i = 0; i < height; i++)
			{
				Console.SetCursorPosition(0, 1 + i);
				Console.Write(new string(' ', Defs.width));
			}
			for (int i = 0; i < items.Count; i++)
			{
				Console.SetCursorPosition(0, 1 + i);
				Console.Write(Helpers.CapitalizeEachWord(items[i].dispName));
			}

			Console.ResetColor();
			Console.ReadKey(true);
		}
	}
}
