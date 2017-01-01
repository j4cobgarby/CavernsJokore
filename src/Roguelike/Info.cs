using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	class Info
	{
		public string help = "Press <?> for help!";
		public string defaultContent = "Nothing interesting happening at the moment..";
		public string content = "";

		public void changeContent(string to)
		{
			content = to;
		}

		public void draw()
		{
			Defs.ResetCursor();
			Console.BackgroundColor = ConsoleColor.DarkMagenta;
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(content);
			Console.Write(new string(' ', Defs.width - content.Length));
			Console.ResetColor();
		}
	}
}
