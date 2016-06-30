using System;

namespace BowlingGame
{
	public class BowlingSets
	{
		public string score;
		public int currentSetNumber;
		private int scoreNumber;
		private int scoreNumberCheck;

		public void StartGame(BowlingScore player, BowlingDisplay display)
		{
			do {
				GetScoreRollOne (player, display);
				TotalScore(player, display);
				if(scoreNumber != 10)
				{
					GetScoreRollTwo(player, display);
					TotalScore(player, display);
				}
			} while(player.setNumber < 10);
			display.scoreDisplay += '|';
			if (player.bonusRollCounter > 0) 
			{
				do {
					Console.WriteLine ("Enter your score for your bonus roll");
					GetScore (player);
					display.SetDisplayBonus(player, scoreNumberCheck);
					player.BonusRoll (scoreNumber);
					TotalScore (player, display);
				} while(player.bonusRollCounter > 0);
			}
		}

		public int currentSet(BowlingScore player)
		{
			currentSetNumber = player.setNumber + 1;
			return currentSetNumber;
		}

		private void GetScoreRollOne(BowlingScore player, BowlingDisplay display)
		{
			Console.WriteLine("Set number: " + currentSet(player) + ". Please enter your score for roll one");
			display.rollNumber = 1;
			GetScore (player);
			display.SetDisplay(player, scoreNumberCheck);
			player.RollOne (scoreNumber);
		}

		private void GetScoreRollTwo(BowlingScore player, BowlingDisplay display)
		{
			Console.WriteLine("Set number: " + currentSet(player) + ". Please enter your score for roll two");
			display.rollNumber = 2;
			GetScore (player);
			display.SetDisplay(player, scoreNumberCheck);
			player.RollTwo (scoreNumber);
		}

		private void StringToInt(string score)
		{
			scoreNumber = Int32.Parse (score);
		}

		private void GetScore(BowlingScore player)
		{
			score = Console.ReadLine ();
			CheckInputInt (score, player);
		}

		private void TotalScore(BowlingScore player, BowlingDisplay display)
		{
			Console.WriteLine ("Your total score is: " + player.totalScore);
			Console.WriteLine (display.scoreDisplay);
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
			if (scoreNumberCheck >= 0 && scoreNumberCheck <= 10) 
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
			if (player.bonusRollCounter != 0 && scoreNumberCheck <= 10)
			{
				StringToInt (inputText);
			}
			else if((scoreNumberCheck + player.setsFirstRoll[player.setNumber]) > 10)
			{
				Console.WriteLine ("Invalid roll: set score exceeds 10. Please re-enter your score.");
				GetScore (player);
			}
			else
			{
				StringToInt (inputText);
			}
		}
	}
}

