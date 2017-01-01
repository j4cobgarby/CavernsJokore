using System;
using System.IO;

namespace Roguelike
{	
	class Program
	{
		public static Info info;
		public static World world;

		static void Main(string[] args)
		{
			bool exited = false;
			bool inmenu = true;
			Console.CursorVisible = false;

			Console.Clear();

			Defs.Splash();

			info = new Info();
			world = new World();

			while (inmenu)
			{
				string choice = Helpers.MultiChoice("Main menu",
				"New game", "Load save", "Credits", "Exit");

				switch (choice)
				{
					case "New game":
						world.player = Helpers.PlayerSetupWizard();
						inmenu = false;
						break;
					case "Load save":
						string[] saveFiles = System.IO.Directory.GetFiles(Defs.gameRoot + "\\saves");
						for (int ind = 0; ind < saveFiles.Length; ind++)
						{
							string file = saveFiles[ind];
							saveFiles[ind] = Path.GetFileNameWithoutExtension(file);
						}
						string saveChoice = Helpers.MultiChoice("Saves", saveFiles);
						Console.SetCursorPosition(0, Defs.height / 2);
						Helpers.PrintCenter("Not implemented.. Yet.");
						Console.ReadKey(true);
						//inmenu = false;
						break;
					case "Credits":
						Console.Write("\n");
						Console.BackgroundColor = ConsoleColor.Gray;
						Console.ForegroundColor = ConsoleColor.Black;
						Helpers.PrintCenter("CREDITS\n");
						Console.ResetColor();
						foreach (string ln in 
							System.IO.File.ReadAllLines(Defs.gameRoot + "\\credits.txt"))
						{
							Helpers.PrintCenter(ln);
						}
						Console.ReadKey(true);
						break;
					case "Exit":
						if (choice == "Exit") exited = true;
						return;
					default: break;
				}
			}
			
			Console.Clear();
			world.draw();
			info.changeContent(info.help);
			info.draw();

			while (true)
			{
				world.handleInput();
				Console.Clear();
				world.draw();
				info.draw();
				//info.changeContent("l:" + world.player.l.ToString() + " | t:" + world.player.t.ToString());
			}
		}
	}
}
