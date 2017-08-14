using System;

namespace Sokoban
{
	public class Map
	{
		public int width = 7;
		public int height = 7;
		public Player player;
		public Box box;
		public Gate gate;

		public void print ()
		{
			for (int y = 0; y < height; y++) {
				for (int x = 0; x < width; x++) {
					if (x == player.x && y == player.y) {
						Console.Write ("P ");
					} else if (x == box.x && y == box.y) {
						Console.Write ("B ");
					} else if (x == gate.x && y == gate.y) {
						Console.Write ("G ");
					} else {
						Console.Write ("- ");
					}
				}
				Console.WriteLine ();
			}
		}
	}
}

