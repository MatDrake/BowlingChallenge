using System;
using System.Collections.Generic;

namespace BowlingGame
{
	public class BowlingScore
	{
		public int[] setsFirstRoll;
		public int[] setsSecondRoll;
		public int[] bonusRoll;
		List<int> setsBonusRoll = new List<int>();
		public int setNumber;
		public int totalScore;
		public int strikeCounter;
		public int bonusRollCounter;

		public BowlingScore ()
		{
		    setsFirstRoll = new int[11];
			setsSecondRoll = new int[10];
			bonusRoll = new int[2];
			setNumber = 0;
			totalScore = 0;
			strikeCounter = 0;
			bonusRollCounter = 0;
		}

		public void RollOne(int roll) 
		{
			setsFirstRoll [setNumber] = roll;
			AddToTotalScore (roll);
			StrikeCalculations (roll);
			StrikeSetIncrease (roll);
			IsBonusRoll();
		}
			
		public void RollTwo(int roll)
		{
			setsSecondRoll [setNumber] = roll;
			AddToTotalScore (roll);
			StrikeCalculations (roll);
			IsSpare(roll);
			if (setNumber < 10) 
			{
				IncreaseSetNumber ();
			}
			IsBonusRoll ();
		}

		public void BonusRoll(int roll)
		{
			setsBonusRoll.Add (roll);
			StrikeCalculations (roll);
			bonusRollCounter -= 1;
		}

		private void IncreaseSetNumber()
		{
			
			setNumber += 1;
		}

		private void AddToTotalScore(int roll)
		{
			totalScore += roll;
		}

		private void StrikeCalculations (int roll)
		{
			StrikeScoreBonus (roll);
			StrikeCounterDecrease ();
		}

		private void StrikeSetIncrease(int roll)
		{
			if (roll == 10 && setNumber < 10) 
			{
				setsSecondRoll [setNumber] = 0;
				IncreaseSetNumber ();
				StrikeCounterIncrease ();
			}
		}

		private void StrikeCounterIncrease()
		{
			strikeCounter += 2;
		}

		private void StrikeCounterDecrease()
		{
			if(strikeCounter == 3)
			{
				strikeCounter -= 2;
			}
			else if(strikeCounter <= 2 && strikeCounter != 0)
			{
				strikeCounter -= 1;
			}
		}

		private void StrikeScoreBonus(int roll)
		{
			if (strikeCounter == 3) {
				totalScore += (roll * 2); 
			} 
			else if (strikeCounter > 0) 
			{
				totalScore += roll;
			}
		}

		private void IsBonusRoll()
		{
			if (setsFirstRoll [9] == 10) {
				bonusRollCounter = 2;
			} else if ((setsFirstRoll [9] + setsSecondRoll [9]) == 10) {
				bonusRollCounter = 1;
			}
		}
			
		private void IsSpare(int roll)
		{
			if ((setsFirstRoll [setNumber] + roll) == 10) {
				strikeCounter += 1;
			}
		}
	}
}

