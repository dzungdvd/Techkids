using System;

namespace Sokoban
{
	public class InputProcessor
	{
		public Player player;
		public void processCommand(string command)
		{
			switch (command.ToUpper()) {
			case "W":
				player.moveUp();
				break;
			case "S":
				player.moveDown();
				break;
			case "A":
				player.moveLeft();
				break;
			case "D":
				player.moveRight();
				break;
			}
		}
		public InputProcessor ()
		{
		}
	}
}

