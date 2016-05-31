using System;

namespace BowlingGame
{
	public class BowlingSets
	{
		public string score;
		private int scoreNumber;

		public void StartGame(BowlingScore player)
		{
			do {
				GetScoreRollOne (player);
				TotalScore(player);
				if(scoreNumber != 10)
				{
					GetScoreRollTwo(player);
					TotalScore(player);
				}
			} while(player.setNumber < 11);
			if (player.bonusRollCounter > 0) 
			{
				do {
					Console.WriteLine ("Enter your score for your bonus roll");
					GetScore ();
					player.BonusRoll (scoreNumber);
					TotalScore (player);
				} while(player.bonusRollCounter > 0);
			}
		}

		private void GetScoreRollOne(BowlingScore player)
		{
			Console.WriteLine("Set number: " + player.setNumber + ". Please enter your score for roll one");
			GetScore ();
			player.RollOne (scoreNumber);
		}

		private void GetScoreRollTwo(BowlingScore player)
		{
			Console.WriteLine("Set number: " + player.setNumber + ". Please enter your score for roll two");
			GetScore ();
			player.RollTwo (scoreNumber);
		}

		private void StringToInt(string score)
		{
			scoreNumber = Int32.Parse (score);
		}

		private void GetScore()
		{
			string score = Console.ReadLine ();
			StringToInt (score);
		}

		private void TotalScore(BowlingScore player)
		{
			Console.WriteLine ("Your total score is: " + player.totalScore);
		}
	}
}

