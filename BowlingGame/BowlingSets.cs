﻿using System;

namespace BowlingGame
{
	public class BowlingSets
	{
		public string score;
		public string scoreDisplay;
		public int currentSetNumber;
		public int rollNumber;
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
			} while(player.setNumber < 10);
			scoreDisplay += '|';
			if (player.bonusRollCounter > 0) 
			{
				do {
					Console.WriteLine ("Enter your score for your bonus roll");
					GetScore (player);
					SetDisplayBonus(player, scoreDisplay);
					player.BonusRoll (scoreNumber);
					TotalScore (player);
				} while(player.bonusRollCounter > 0);
			}
		}

		public int currentSet(BowlingScore player)
		{
			currentSetNumber = player.setNumber + 1;
			return currentSetNumber;
		}

		private void GetScoreRollOne(BowlingScore player)
		{
			Console.WriteLine("Set number: " + currentSet(player) + ". Please enter your score for roll one");
			rollNumber = 1;
			GetScore (player);
			SetDisplay(player);
			player.RollOne (scoreNumber);
		}

		private void GetScoreRollTwo(BowlingScore player)
		{
			Console.WriteLine("Set number: " + currentSet(player) + ". Please enter your score for roll two");
			rollNumber = 2;
			GetScore (player);
			SetDisplay(player);
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

		private void TotalScore(BowlingScore player)
		{
			Console.WriteLine ("Your total score is: " + player.totalScore);
			Console.WriteLine (scoreDisplay);
		}

		private void SetDisplay(BowlingScore player)
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

		private void SetDisplayBonus(BowlingScore player, BowlingDisplay display)
		{
			if (scoreNumberCheck == 10) 
			{
				scoreDisplay += "X";
				display.IsFirstRollOfTwoBonusRolls (player);
			} 
			else 
			{
				scoreDisplay += $"{scoreNumberCheck}";
				display.IsFirstRollOfTwoBonusRolls (player);
			}
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

