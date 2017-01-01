using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	class ClassStats
	{
		public int _strength;
		public int _wisdom;
		public int _stealth;
		public int _charisma;
		public int _defense;
		public int _dexterity;
		public int _willpower;
		public int _perception;
		public int _luck;

		/* INFORMATION ABOUT STATS
		 * 
		 * Each stat will have a value from 0 (worst) to a maximum value depending on their species.
		 * 
		 * Each species will have a different maximum value for each stat.
		 * 
		 * For example, an orc may have a very high max strengh, but a relatively low wisdom, whereas
		 *	an elf may have the opposite of this.
		 *	
		 *	-- STATS --
		 * 
		 * strength: How well the character performs physical tasks e.g. hitting, pulling a bow
		 * 
		 * wisdom: The extent of the characters's magical ability.
		 * 
		 * stealth: How 'sneaky' the character is. With high stealth, for example, the character could sneak past enemies.
		 * 
		 * charisma: How 'sociable' the character is. It will increase their ability to bargain with npc while trading, and
		 *	will also be trusted more.
		 *	
		 * dexterity: The character's agility. High dexterity means the character can travel faster, and dodge
		 *	attacks more effectively.
		 *	
		 * willpower: The character's defense against mind-altering magic. This usually increases with wisdom. This can
		 *	also increase the accuracy with ranged weapons, and slightly alter the critical hit chance.
		 * 
		 * perception: The character's general awareness of their surroundings. This will increase the chance that
		 *	when searching for doors, etc. they will find one if there is one, of course.
		 *	
		 * luck: How lucky the character is! Increases the chance of critical hits, and further the chance of finding
		 *	what's searched for.
		 */

		public ClassStats(
			int _strength, 
			int _wisdom, 
			int _stealth, 
			int _charisma, 
			int _defense, 
			int _dexterity, 
			int _willpower, 
			int _perception, 
			int _luck
		)
		{
			this._strength = _strength;
			this._wisdom = _wisdom;
			this._stealth = _stealth;
			this._charisma = _charisma;
			this._defense = _defense;
			this._dexterity = _dexterity;
			this._willpower = _willpower;
			this._perception = _perception;
			this._luck = _luck;
		}
	}
}
