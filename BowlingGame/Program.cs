using System;

namespace BowlingGame

{
	class BowlingGame
	{

		static void Main()
		{
			BowlingScore playerOne = new BowlingScore ();
			BowlingSets gameSets = new BowlingSets ();
			BowlingDisplay display = new BowlingDisplay ();
			gameSets.StartGame (playerOne, display);
		}

	}
}
