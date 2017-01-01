using System;

namespace Roguelike
{
	static class Defs
	{
		public static string gameRoot = "C:\\Program Files\\Jokore";

		public static int width = 80;
		public static int height = 25;

		public static char UpArrow    = '\u2191';
		public static char DownArrow  = '\u2193';
		public static char LeftArrow  = '\u2190';
		public static char RightArrow = '\u2192';

		public static char[] validCharsForTextInput = 
			"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 "
			.ToCharArray();

		public static char[] playerPassables =
			". \u2591><\u2191\u2193\u2190\u2192"
			.ToCharArray();

		public static void Splash()
		{
			Console.Write(new string('\n', 4));
			Console.ForegroundColor = ConsoleColor.Magenta;
			foreach (string ln in System.IO.File.ReadAllLines(gameRoot + "\\logo.txt"))
			{
				Helpers.PrintCenter(ln);
			}
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Console.Write("\n");
			Helpers.PrintCenter("github.com/j4cobgarby/CavernsJokore");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("\n");
			Helpers.PrintCenter(" TO START ");
			Helpers.PrintCenter(" PRESS ANY KEY ");
			Console.ResetColor();
			Console.ReadKey();
		}

		public static void ResetCursor()
		{
			Console.SetCursorPosition(0, 0);
		}
	}


}
