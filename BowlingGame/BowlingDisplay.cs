using System;

namespace BowlingGame
{
	public class BowlingDisplay
	{
		public string scoreDisplay; 

		private void IsFirstRollOfTwoBonusRolls(BowlingScore player)
		{
			if (player.bonusRollCounter == 2) 
			{
				scoreDisplay += ",";  // WIP Extracting BowlingDisplay elements in to a separate class. Starting at the smallest steps, currently bringing over the variables needed.
			}
		}
	}
}

