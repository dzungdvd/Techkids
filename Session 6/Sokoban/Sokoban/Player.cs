using System;

namespace Sokoban
{
	public class Player
	{
		public int x;
		public int y;

		public void moveRight ()
		{
			x++;
		}

		public void moveLeft ()
		{
			x--;
		}

		public void moveUp ()
		{
			y--;
		}

		public void moveDown ()
		{
			y++;
		}
	}
}

