using System;

namespace BowlingGame
{
	public class BowlingSets
	{
		public string score;
		private int scoreNumber;
		private int scoreNumberCheck;

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
					GetScore (player);
					player.BonusRoll (scoreNumber);
					TotalScore (player);
				} while(player.bonusRollCounter > 0);
			}
		}

		private void GetScoreRollOne(BowlingScore player)
		{
			Console.WriteLine("Set number: " + player.setNumber + ". Please enter your score for roll one");
			GetScore (player);
			player.RollOne (scoreNumber);
		}

		private void GetScoreRollTwo(BowlingScore player)
		{
			Console.WriteLine("Set number: " + player.setNumber + ". Please enter your score for roll two");
			GetScore (player);
			player.RollTwo (scoreNumber);
		}

		private void StringToInt(string score)
		{
			scoreNumber = Int32.Parse (score);
		}

		private void GetScore(BowlingScore player)
		{
			string score = Console.ReadLine ();
			CheckInputInt (score, player);
		}

		private void TotalScore(BowlingScore player)
		{
			Console.WriteLine ("Your total score is: " + player.totalScore);
		}

		private void CheckInputInt(string inputText, BowlingScore player)
		{
			int inputInt = 0;
			bool successfullyParsed = int.TryParse(inputText, out inputInt);
			if (successfullyParsed) 
			{
				scoreNumberCheck = Int32.Parse(inputText);
				CheckValidScore (scoreNumberCheck, inputText, player);
			} 
			else 
			{
				Console.WriteLine ("Please enter a number between 0 and 10.");
				GetScore (player);
			}
		}
	
		private void CheckValidScore(int scoreNumberCheck, string inputText, BowlingScore player)
		{
			if (scoreNumber >= 0 && scoreNumber <= 10) 
			{
				CheckValidRollTwo (player, inputText, scoreNumberCheck);
			} 
			else 
			{
				Console.WriteLine ("Please enter a number between 0 and 10.");
				GetScore (player);
			}
		}

		private void CheckValidRollTwo(BowlingScore player, string inputText, int scoreNumberCheck)
		{
			if ((scoreNumberCheck + player.setsFirstRoll[player.setNumber - 1]) > 10) // WIP - Only valid scores can now be entered, but an exception is thrown during bonus rolls as index of array is out of range.
			{
				Console.WriteLine ("Test");
				GetScore (player);
			}
			else
			{
				StringToInt (inputText);
			}
		}
	}
}

