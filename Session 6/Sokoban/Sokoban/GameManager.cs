using System;

namespace Sokoban
{
	public class GameManager
	{
		int mapHeight = 7;
		int mapWidth = 7;
		int playerX = 1;
		int playerY = 2;
		int boxX = 2;
		int boxY = 2;
		int gateX = 3;
		int gateY = 3;
		public bool isEnded = false;

		public void DrawMap(){
			for (int y = 0; y < mapHeight; y++) {
				for (int x = 0; x < mapWidth; x++) {
					if (x == playerX && y == playerY) {
						Console.Write ("P ");
					} else if (x == boxX && y == boxY) {
						Console.Write ("B ");
					} else if (x == gateX && y == gateY) {
						Console.Write ("G ");
					} else
						Console.Write ("- ");
				}
				Console.WriteLine ();
			}		
		}

		public void InputProcessor(){
			Console.Write ("What's your command?:  ");
			string command = Console.ReadLine ();

			//Check Boundary
			int nextPlayerX = -1;
			int nextPlayerY = -1;
			int directionX = 0;
			int directionY = 0;


			if (command.ToLower () == "d") {
				directionX = 1;
				nextPlayerX = playerX + 1;
				if (nextPlayerX >= 0 && nextPlayerX < mapWidth) {
					playerX ++;
				}
			}
			if (command.ToLower () == "a") {
				directionX = -1;
				nextPlayerX = playerX - 1;
				if (nextPlayerX >= 0 && nextPlayerX < mapWidth) {
					playerX -- ;
				}
			}
			if (command.ToLower () == "w") {
				directionY = -1;
				nextPlayerY = playerY - 1 ;
				if (nextPlayerY >= 0 && nextPlayerY < mapHeight) {
					playerY -- ;
				}
			}
			if (command.ToLower () == "s") {
				directionY = 1;
				nextPlayerY = playerY + 1;
				if (nextPlayerY >= 0 && nextPlayerY < mapHeight) {
					playerY ++;
				}
			}

			//Box Pushing
			int nextBoxX;
			int nextBoxY;

			if(playerX == boxX && playerY == boxY){
				nextBoxX = boxX + directionX;
				if (nextBoxX >= 0 && nextBoxX < mapWidth) {
					boxX = boxX + directionX;
				}
				nextBoxY = boxY + directionY;
				if (nextBoxY >= 0 && nextBoxY < mapHeight) {
					boxY = boxY + directionY;
				}
			}

		} 

		public void WinCheck(){
			//Win lose Check
			if (boxX == gateX && boxY == gateY){
				Console.WriteLine ("You win");
				isEnded = true;
			}
		}


		public GameManager ()
		{
		}
	}
}