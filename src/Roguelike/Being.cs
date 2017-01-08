namespace Roguelike
{
	abstract class Being
	{
		protected Being(bool doesAttackPlayer, char disp, string name)
		{
			DoesAttackPlayer = doesAttackPlayer;
			Disp = disp;
			Name = name;
		}

		public int L, T;
		public int Health;
		
		public bool DoesAttackPlayer { get; set; }
		public bool CanHide { get; set; }

		public char Disp { get; set; }

		public string Name { get; set; }
	}

	// --

	abstract class Humanoid : Being
	{
		protected Humanoid() : base(false, 'h', "a humanoid") { }
	}

	// --

	abstract class Undead : Being
	{
		protected Undead() : base(true, 'u', "an undead being") { }
	}

	class Zombie : Undead { }

	class Phantom : Undead
	{
		public Phantom()
		{
			Disp = 'p';
			CanHide = true;
		}
	}
}
