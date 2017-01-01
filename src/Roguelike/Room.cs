using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
	class Room
	{
		public string[] _layout;

		public Room(string fileName)
		{
			_layout = File.ReadAllLines(fileName);
		}

		public string layout
		{
			set {
				_layout = File.ReadAllLines(Defs.gameRoot + "\\rooms\\" + value);
			}
		}

		public string[] getLayout
		{
			get
			{
				return _layout;
			}
		}

		public void Draw()
		{
			Console.Write("\n");
			foreach (string ln in _layout)
			{
				Console.Write(ln);
			}
		}
	}
}
