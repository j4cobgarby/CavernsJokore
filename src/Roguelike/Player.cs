using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	class Player
	{
		public int l, t;
		public char disp;

		//                  Level  x  y
		public int[] roomID = { 0, 0, 0 };

		public string name;
		public string gender; // "male" or "female"

		public Inventory inv = new Inventory();

		public Class cls;
		public ClassStats clsStats;
		public Species species;

		public Player()
		{
			this.l = Defs.width / 2;
			this.t = Defs.height / 2;
			this.name = "Unnamed";
			this.disp = '@';
		}

		public Player(int l, int t, Class cls, ClassStats clsStats, Species species, string name)
		{
			this.l = l;
			this.t = t;

			this.cls = cls;
			this.clsStats = clsStats;
			this.species = species;
			this.name = name;

			this.disp = '@';
		}

		public void draw()
		{
			Console.SetCursorPosition(l, t);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(disp);
			Console.ResetColor();
		}

		public void drawInventory()
		{
			inv.draw();
		}

		public void move(int l, int t) // This will also handle events based on chars moved to
		{
			Program.info.changeContent("l:" + this.l.ToString() + " | t:" + this.t.ToString());
			int supposedl, supposedt;
			supposedl = this.l + l;
			supposedt = this.t + t;

			string[] layout = Program.world.currentRoom.getLayout;
			string row;
			try
			{
				row = layout[supposedt - 1]; // The vertical offset
			}
			catch (Exception e) { return; }
			char supposedFloor = row[supposedl];

			if (Defs.playerPassables.Contains(supposedFloor))
			{
				if (this.l + l >= 0 && this.l + l < Defs.width)
				{
					this.l += l;
				}
				if (this.t + t >= 1 && this.t + t < Defs.height)
				{
					this.t += t;
				} // But, check for arrows symbolising the edge doors,
				  // since those chars won't actually be visited directly.
				if (supposedFloor == Defs.UpArrow)
				{
					Commands.ShiftRoom(0, 1, "up");
				}
				else if (supposedFloor == Defs.DownArrow)
				{
					Commands.ShiftRoom(0, -1, "down");
				}
				else if (supposedFloor == Defs.LeftArrow)
				{
					Commands.ShiftRoom(-1, 0, "left");
				}
				else if (supposedFloor == Defs.RightArrow)
				{
					Commands.ShiftRoom(1, 0, "right");
				}
				// So, after the player has definitely moved, apply
				// what should happen based on the char they're on.
				switch (supposedFloor)
				{
					case '>':
						Program.info.changeContent("Press '>' to descend.");
						break;
					case '<':
						Program.info.changeContent("Press '<' to ascend.");
						break;
					default: break;
				}
			}
		}
	}
}
