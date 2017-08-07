using System;

namespace Sokoban
{
	public class Map
	{
		public int width = 7;
		public int height = 7;
		public Player player;
		//public Box box;
		//public Gate gate;

		public Map ()
		{
		}

		public void print()
		{
			for (int y = 0; y < height; y++) {
				for (int x = 0; x < width; x++) {
					if (x == player.x && y == player.y) {
						Console.Write ("P ");
					} else {
						Console.Write ("- ");
					}
				}
				Console.WriteLine ();
			}
		}
	}
}

