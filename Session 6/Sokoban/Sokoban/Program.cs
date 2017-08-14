using System;

namespace Sokoban
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			GameManager gameManager = new GameManager();
			while (true) {
				gameManager.DrawMap ();
				gameManager.InputProcessor ();
				gameManager.WinCheck ();
				if (gameManager.isEnded) {
					break;
				}
			}
		}
	}
}