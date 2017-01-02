using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	static class Commands
	{
		/* Commands used by the player
		 * 
		 */
		public static void Help()
		{
			Console.Clear();
			Console.WriteLine("\n");
			Helpers.PrintCenter(" HELP\n");
			Helpers.PrintCenter(" CONTROLS\n");
			string[] helpLines = System.IO.File.ReadAllLines(Defs.gameRoot + "\\controls.txt");
			foreach (string ln in helpLines)
			{
				Helpers.PrintCenter(ln);
			}
			Console.ReadKey();
			Console.Clear();
			Console.WriteLine("\n");
			Helpers.PrintCenter(" HELP\n");
			Helpers.PrintCenter(" MOVEMENT\n");
			helpLines = System.IO.File.ReadAllLines(Defs.gameRoot + "\\movement.txt");
			foreach (string ln in helpLines)
			{
				Helpers.PrintCenter(ln);
			}
			Console.ReadKey();
			Console.ResetColor();
		}

		public static void Inventory()
		{
			Program.world.player.drawInventory();
		}

		public static void Quack()
		{
			Helpers.Do("You", "quacks");
		}

		public static void Eat()
		{
			Helpers.SelectFromInv();
		}

		/* Commands not directly used by the player
		 * 
		 */ 
		public static void ShiftRoom(int x, int y, string arrowDir)
		{
			try
			{
				Program.world.player.roomID[1] += x;
				Program.world.player.roomID[2] += y;

				Program.world.updateRoom();
				switch (arrowDir)
				{
					case "up":
						Program.world.player.t = Defs.height - 2;
						break;
					case "down":
						Program.world.player.t = 2;
						break;
					case "left":
						Program.world.player.l = Defs.width - 2;
						break;
					case "right":
						Program.world.player.l = 1;
						break;
					default: break;
				}
			}
			catch (Exception e) { }
		}

		public static void ShiftLevel(int z)
		{
			try
			{
				Program.world.player.roomID[0] += z;
				Program.world.updateRoom();
			}
			catch (Exception e) { }
		}
	}
}
