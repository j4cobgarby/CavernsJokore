using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	class Species
	{
		public string displayName;
	}

	class Human : Species
	{
		public Human()
		{
			displayName = "Human";
		}
	}

	class Elf : Species
	{
		public Elf()
		{
			displayName = "Elf";
		}
	}

	class HalfElf : Species
	{
		public HalfElf()
		{
			displayName = "Half Elf";
		}
	}

	class Ogre : Species
	{
		public Ogre()
		{
			displayName = "Ogre";
		}
	}

	class Dwarf : Species
	{
		public Dwarf()
		{
			displayName = "Dward";
		}
	}

	class Satyr : Species
	{
		public Satyr()
		{
			displayName = "Satyr";
		}
	}

	class NightElf : Species
	{
		public NightElf()
		{
			displayName = "Night Elf";
		}
	}
}
