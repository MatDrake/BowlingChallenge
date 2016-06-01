using System;

namespace BowlingGame

{
	class BowlingGame
	{

		static void Main()
		{
			BowlingScore playerOne = new BowlingScore ();
			BowlingSets gameSets = new BowlingSets ();
			gameSets.StartGame (playerOne);
		}


	}
}
