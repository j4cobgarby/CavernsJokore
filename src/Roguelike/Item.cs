using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	class Item
	{
		public bool isWieldable { get; set; }
		public bool isWeapon { get; set; }
		public bool isRanged { get; set; }
		public bool isMagic { get; set; }
		public bool isStackable { get; set; }
		public bool isEdible { get; set; }

		public int bluntDmg { get; set; } // 1-50
		public int pierceDmg { get; set; } // 1-50
		public int attackSpeed { get; set; } // Affects chance to miss etc.., 1-20 = slow-fast
		public int stackSize { get; set; }
		public int healthOnEat { get; set; } // If it's food, it will restore some health on eating

		public string dispName { get; set; }

		public string hitMessage { get; set; }
		// where {0} is player name
		// {1} is who's been hit
		// {2} is for how much damage
		// -- I don't know how i will implement this, but oh well

		// No constructor because I can't be bothered
		// to write all these values in every time
		// I initialize one of these. Also, each
		// different item will have its own class
		// extended from this one.

		// Also, for each class extending this one,
		// there may very well be other classes
		// extending those.
		// For example:
		// Item => Sword => WoodenSword
		// Let's do that first.
	}

	/*
	 * The swords
	 */
	class Sword : Item
	{
		public Sword(int bluntDmg, int pierceDmg, int attackSpeed, string dispName)
		{
			isWieldable = true;
			isWeapon = true;
			isRanged = false;
			isMagic = false;

			this.bluntDmg = bluntDmg;
			this.pierceDmg = pierceDmg;
			this.attackSpeed = attackSpeed;

			this.dispName = dispName;
			hitMessage = "{0} strikes {1} for {2} damage with " + dispName + "!";
		}
	}
	class PracticeSword : Sword
	{
		public PracticeSword() : base(1, 0, 6, "a practice sword") { }
	}
	class Dagger : Sword
	{
		public Dagger() :        base(2, 4, 9, "a dagger") { }
	}
	class Longsword : Sword
	{
		public Longsword() :     base(2, 8, 5, "a longsword") { }
	}
	class Cutlass : Sword
	{
		public Cutlass() :       base(3, 10, 8, "a cutlass") { }
	}
	class Falchion : Sword
	{
		public Falchion() :      base(3, 11, 7, "a falchion") { }
	}
	class Rapier : Sword
	{
		public Rapier() :        base(2, 9, 7, "a rapier") { }
	}
	class DualDaggers : Sword
	{
		public DualDaggers() :   base(1, 9, 13, "dual daggers") { }
	}
	class DragonDaggers : Sword
	{
		public DragonDaggers() : base(2, 24, 15, "dragon daggers") { }
	}

	/*
	 * Misc
	 */
	class Torch : Item
	{
		public Torch(int turns)
		{
			isWieldable = true;
			isWeapon = false;
			isRanged = false;
			isMagic = false;

			dispName = "a torch";
		}
	}
}
