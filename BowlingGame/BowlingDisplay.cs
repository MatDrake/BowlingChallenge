using System;

namespace BowlingGame
{
	public class BowlingDisplay
	{
		public string scoreDisplay;
		public int rollNumber;

		public void SetDisplay(BowlingScore player, int scoreNumberCheck)
		{
			if (scoreNumberCheck == 10 && rollNumber == 1) 
			{
				scoreDisplay += "X|";
			} 
			else if (scoreNumberCheck == 0) 
			{
				scoreDisplay += "-";
				IsEndOfFrame ();
			}
			else if ((scoreNumberCheck + player.setsFirstRoll [player.setNumber]) == 10) 
			{
				scoreDisplay += "/|";
			}
			else
			{
				scoreDisplay += scoreNumberCheck;
				IsEndOfFrame ();
			}
		}

		public string DisplaySets()
		{
			return scoreDisplay;
		}

		public void IsFirstRollOfTwoBonusRolls(BowlingScore player)
		{
			if (player.bonusRollCounter == 2) 
			{
				scoreDisplay += ",";
			}
		}

		public void SetDisplayBonus(BowlingScore player, int scoreNumberCheck)
		{
			if (scoreNumberCheck == 10) 
			{
				scoreDisplay += "X";
			} 
			else if (scoreNumberCheck == 0) 
			{
				scoreDisplay += "-";
			}
			else 
			{
				scoreDisplay += $"{scoreNumberCheck}";
			}
			IsFirstRollOfTwoBonusRolls (player);
		}

		private void IsEndOfFrame()
		{
			if (rollNumber == 2) 
			{
				scoreDisplay += '|';
			} 
			else 
			{
				scoreDisplay += ",";
			}
		}
	}
}

