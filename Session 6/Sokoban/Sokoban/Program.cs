using System;

namespace Sokoban
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Map map = new Map ();
			Player player = new Player ();
			InputProcessor inputProcessor = new InputProcessor ();
			map.player = player;
			inputProcessor.player = player;

			//game loop
			//while True:
			while (true) {
				//print map
				map.print();

				//get user input
				//Console.Write
				string command = Console.ReadLine ();

				//process user input (update player & box position)
				inputProcessor.processCommand(command);

				//win/loss conditions check


			}
		}
	}
}
