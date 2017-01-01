using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	class Class
	{
		public string id;

		public int max_strength;
		public int max_wisdom;
		public int max_stealth;
		public int max_charisma;
		public int max_defense;
		public int max_dexterity;
		public int max_willpower;
		public int max_perception;
		public int max_luck;

		ClassStats stats;
	}
	class Warrior : Class
	{
		public int max_strength = 40;
		public int max_wisdom = 20;
		public int max_stealth = 18;
		public int max_charisma = 31;
		public int max_defense = 32;
		public int max_dexterity = 21;
		public int max_willpower = 19;
		public int max_perception = 25;
		public int max_luck = 23;
	}
	class Wizard : Class
	{
		public int max_strength = 21;
		public int max_wisdom = 40;
		public int max_stealth = 23;
		public int max_charisma = 26;
		public int max_defense = 16;
		public int max_dexterity = 29;
		public int max_willpower = 37;
		public int max_perception = 29;
		public int max_luck = 31;
	}
	class Rogue : Class
	{
		public int max_strength = 27;
		public int max_wisdom = 19;
		public int max_stealth = 40;
		public int max_charisma = 16;
		public int max_defense = 14;
		public int max_dexterity = 30;
		public int max_willpower = 21;
		public int max_perception = 32;
		public int max_luck = 28;
	}
	class Archer : Class
	{
		public int max_strength = 25;
		public int max_wisdom = 20;
		public int max_stealth = 34;
		public int max_charisma = 20;
		public int max_defense = 23;
		public int max_dexterity = 25;
		public int max_willpower = 28;
		public int max_perception = 23;
		public int max_luck = 25;
	}
	class Paladin : Class
	{
		public int max_strength = 34;
		public int max_wisdom = 35;
		public int max_stealth = 18;
		public int max_charisma = 31;
		public int max_defense = 32;
		public int max_dexterity = 21;
		public int max_willpower = 24;
		public int max_perception = 25;
		public int max_luck = 28;
	}
	class Beastlord : Class
	{
		public int max_strength = 31;
		public int max_wisdom = 28;
		public int max_stealth = 20;
		public int max_charisma = 18;
		public int max_defense = 30;
		public int max_dexterity = 20;
		public int max_willpower = 28;
		public int max_perception = 29;
		public int max_luck = 27;
	}
}
