using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	class World
	{
		public Player player;
		public Room currentRoom;

		public World()
		{
			currentRoom = new Room(Defs.gameRoot + "\\rooms\\0-0-0.txt");
		}

		public void updateRoom()
		{
			currentRoom.layout = Helpers.RoomFileFromID(player.roomID);
		}

		public void draw()
		{
			Console.SetCursorPosition(0, 0);
			currentRoom.Draw();
			player.draw();
		}

		public void handleInput()
		{
			ConsoleKeyInfo key = Console.ReadKey(true);
			if (key.Key.ToString() == "UpArrow") // First check arrow keys, using key.Key.ToString()
			{
				player.move(0, -1);
			}
			else if (key.Key.ToString() == "DownArrow")
			{
				player.move(0, 1);
			}
			else if (key.Key.ToString() == "RightArrow")
			{
				player.move(1, 0);
			}
			else if (key.Key.ToString() == "LeftArrow")
			{
				player.move(-1, 0);
			}
			else
			{   /**
			     * If the key isn't an arrow key, check for normal keys, e.g. 'a', 'L', etc..
			     * This can't be done using key.Key.ToString(), since this would return the uppercase
			     * value of any letter.
			     */
				string[] layout = Program.world.currentRoom.getLayout;
				string row;
				try
				{
					row = layout[Program.world.player.t - 1]; // The vertical offset
				}
				catch (Exception e) { return; }
				char supposedFloor = row[Program.world.player.l];

				switch (key.KeyChar.ToString())
				{
					case "?":
						Commands.Help();
						break;
					case ">":
						if (supposedFloor == '>') Commands.ShiftLevel(1); // Down
						break;
					case "<":
						if (supposedFloor == '<') Commands.ShiftLevel(-1); // n' Up!
						break;
					case "a":
						break;
					case "b":
						break;
					case "c":
						break;
					case "d":
						break;
					case "e":
						break;
					case "f":
						break;
					case "g":
						break;
					case "h":
						break;
					case "i":
						Commands.Inventory();
						break;
					case "j":
						break;
					case "k":
						break;
					case "l":
						break;
					case "m":
						break;
					case "n":
						break;
					case "o":
						break;
					case "player":
						break;
					case "q":
						Commands.Quack();
						break;
					case "r":
						break;
					case "s":
						break;
					case "t":
						break;
					case "u":
						break;
					case "v":
						break;
					case "w":
						break;
					case "x":
						break;
					case "y":
						break;
					case "z":
						break;
					default: break;
				}
			}
		}
	}
}
