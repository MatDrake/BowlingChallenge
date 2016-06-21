using System;

namespace BowlingGame
{
	public class BowlingDisplay
	{
		public string playerScoreDisplay;

		public string ScoreDisplay(BowlingSets playerSets)
		{
			playerScoreDisplay += playerSets.score;
			return playerScoreDisplay;
		}
	}
}

