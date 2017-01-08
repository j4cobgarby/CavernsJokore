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
		} // ?

		public static void Eat()
		{
			Item proposedFood = Helpers.SelectFromInv();
			if (proposedFood.isEdible)
			{
				// Then the item IS food, so..
				Program.world.player.health += proposedFood.healthOnEat;
				Helpers.Do("You", String.Format(
					"eats {0}, recouping {1} point(s) of health.", 
					proposedFood.dispName, proposedFood.healthOnEat));
			}
			else
			{
				// But this is what happens if it isn't.
				Program.info.changeContent("I wouldn't eat that..");
				return;
			}
		} // e

		public static void Inventory()
		{
			Program.world.player.drawInventory();
		} // i

		public static void Quack()
		{
			Helpers.Do("You", "quacks");
		} // q

		/* Commands not directly used by the player
		 * but instead used when the player does a specific
		 * thing.
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
