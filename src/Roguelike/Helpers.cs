﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Roguelike
{
	abstract class Helpers
	{
		private static readonly ConsoleColor accent = ConsoleColor.Magenta;
		private static readonly ConsoleColor accentFG = ConsoleColor.White;

		public static int HowManyItemInInv(string disp)
		{
			int amount = 0;
			foreach (Item it in Program.world.player.inv.items)
			{
				string current = it.dispName;
				if (disp == current) amount++;
			}
			return amount;
		}

		public static string CapitalizeEachWord(string s)
		{
			s = Regex.Replace(s, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
			return s;
		}

		public static Item SelectFromInv()
		{
			int chosenIndex = 0;
			while (true)
			{
				// The drawing

				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.DarkMagenta;

				for (int i = 0; i < 6; i++) // 6 is the height
				{
					Console.SetCursorPosition(0, 1 + i);
					Console.Write(new string(' ', Defs.width));
				}
				for (int i = 0; i < Program.world.player.inv.items.Count; i++)
				{
					if (i - 1 == chosenIndex)
					{
						Console.BackgroundColor = ConsoleColor.DarkMagenta;
						Console.ForegroundColor = ConsoleColor.White;
					}

					Console.SetCursorPosition(0, i + 1);
					Console.Write(Helpers.CapitalizeEachWord(Program.world.player.inv.items[i].dispName));

					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.BackgroundColor = ConsoleColor.White;
				}

				Console.ResetColor();

				// End drawing

				ConsoleKeyInfo key = Console.ReadKey(true);
				switch (key.Key.ToString())
				{
					case "UpArrow":
						chosenIndex--;
						break;
					case "DownArrow":
						chosenIndex++;
						break;
					default:
						break;
				}
				if (key.Key.ToString() == "Enter")
				{
					return Program.world.player.inv.items[chosenIndex + 1];
				} 
			}
		}

		public static void PrintCenter(string s)
		{
			Console.SetCursorPosition((Defs.width - s.Length) / 2, Console.CursorTop);
			Console.WriteLine(s);
		}

		public static void Sleep(int milli)
		{
			System.Threading.Thread.Sleep(milli);
		}

		public static void Say(string who, string what)
		{
			Program.info.changeContent(String.Format("{0}> {1}", who, what));
		}

		public static void Do(string who, string what)
		{
			Program.info.changeContent(String.Format("{0}: *{1}*", who, what));
		}

		static string textBlank = "_"; // What's displayed in text input for somewhere not typed
		
		public static string TextInput(string prompt, int max)
		{
			string buffer = "";

			Console.Clear();
			Console.SetCursorPosition(20, Defs.height / 2);
			Console.Write(prompt + ": " + new string(textBlank[0], max));
			Console.SetCursorPosition(20 + (prompt + ": ").Length, Defs.height / 2);

			while (true)
			{
				ConsoleKeyInfo key = Console.ReadKey(true);
				if (key.Key.ToString() == "Enter") break;
				if (key.Key.ToString() == "Backspace" &&
					buffer.Length - 1 >= 0)
				{
					Console.Write("\b{0}\b", textBlank);
					try
					{
						buffer = buffer.Remove(buffer.Length - 1);
					}
					catch (Exception e) {
						buffer = "";
					}
					
				}
				else
				{
					if (Defs.validCharsForTextInput.Contains(key.KeyChar) &&
						buffer.Length + 1 <= max)
					{
						Console.Write(key.KeyChar.ToString());
						buffer = buffer + key.KeyChar.ToString();
					}
				}
			}

			return buffer;
		}

		public static string LongestString(string[] arr)
		{
			string longest = arr.OrderByDescending(s => s.Length).First();
			return longest;
		}

		public static string MultiChoice(string prompt, params string[] choices)
		{
			string result = "";
			int chosenIndex = 0;
			int baseTop = 8;
			int left = 30;
			int longest = LongestString(choices).Length ;

			Console.Clear();
			Console.SetCursorPosition(left, baseTop - 2);
			Console.Write(prompt);

			while (true)
			{
				for (int index = 0; index < choices.Length; index++)
				{
					Console.SetCursorPosition(left, baseTop + index);
					if (index == chosenIndex)
					{
						Console.BackgroundColor = accent;
						Console.ForegroundColor = accentFG;
						Console.Write(choices[index]);
						Console.ResetColor();
					} else
					{
						Console.Write(choices[index]);
					}
				}

				Console.SetCursorPosition(left, baseTop + choices.Length + 2);
				Console.WriteLine(new string(' ', longest));
				Console.SetCursorPosition(left, baseTop + choices.Length + 2);
				Console.Write(choices[chosenIndex]);

				ConsoleKeyInfo key = Console.ReadKey(true);
				switch (key.Key.ToString())
				{
					case "UpArrow":
						if (chosenIndex - 1 >= 0) chosenIndex--;
						else
						{
							chosenIndex = choices.Length - 1;
						}
						break;
					case "DownArrow":
						if (chosenIndex + 1 < choices.Length) chosenIndex++;
						else
						{
							chosenIndex = 0;
						}
						break;
					default:
						break;
				}
				if (key.Key.ToString() == "Enter") break;
			}
			Console.Clear();

			result = choices[chosenIndex];
			return result;
		}

		private static void WizardUpdate(string name, string gender, string species, string cls)
		{
			Console.Clear();
			Console.SetCursorPosition(0, Defs.height / 2);
			Helpers.PrintCenter(String.Format("{0}, the {1} {3} {2}!", name, gender, cls, species));
			Console.SetCursorPosition(0, (Defs.height / 2) + 2);
			Helpers.PrintCenter("Press <ANY KEY> to continue");
			Console.ReadKey(true);
		}
		
		public static Player PlayerSetupWizard()
		{
			string def = new string(textBlank[0], 4);
			string name = def;
			string gender = def;
			string species = def;
			string cls = def;

			Player result = new Player();

			Console.Clear();
			name = TextInput("What's your name?", 20);
			result.name = name;

			WizardUpdate(name, gender, species, cls);

			gender = MultiChoice("And, what gender are you?",
				"Male", "Female").ToLower();
			result.gender = gender;

			WizardUpdate(name, gender, species, cls);

			species = MultiChoice("Pick a species",
				"Human", "Elf", "Half Elf", "Night Elf", "Ogre", "Dwarf", "Satyr");
			switch (species)
			{
				case "Human":     result.species = new Human(); break;
				case "Elf":       result.species = new Elf(); break;
				case "Half Elf":  result.species = new HalfElf(); break;
				case "Night Elf": result.species = new NightElf(); break;
				case "Ogre":      result.species = new Ogre(); break;
				case "Dwarf":     result.species = new Dwarf(); break;
				case "Satyr":     result.species = new Satyr(); break;
				default: break;
			}

			WizardUpdate(name, gender, species, cls);

			cls = MultiChoice("Now, choose a class",
				"Warrior", "Wizard", "Rogue", "Archer", "Paladin", "Beastlord");
			switch (cls)
			{
				case "Warrior":   result.cls = new Warrior(); break;
				case "Wizard":    result.cls = new Warrior(); break;
				case "Rogue":     result.cls = new Warrior(); break;
				case "Archer":    result.cls = new Warrior(); break;
				case "Paladin":   result.cls = new Warrior(); break;
				case "Beastlord": result.cls = new Warrior(); break;
				default: break;
			}

			WizardUpdate(name, gender, species, cls);
			Console.Clear();
			Console.SetCursorPosition(0, Defs.height / 2);
			PrintCenter("You wake up...");
			Console.ReadKey(true);

			Console.Clear();
			Console.SetCursorPosition(0, Defs.height / 2);
			PrintCenter("...");
			Console.ReadKey(true);

			return result;
		}

		public static string RoomFileFromID(int[] id)
		{
			string result = "";
			result += (id[0].ToString() +"-"+ id[1].ToString() +"-"+ id[2].ToString() + ".txt");
			return result;
		}
	}
}
