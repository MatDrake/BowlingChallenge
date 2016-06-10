namespace BowlingGame
{
	using NUnit.Framework;
	using System;

		[TestFixture ()]
		public class BowlingScoreTest
		{

			public const int spareRollOne = 4; 
			public const int spareRollTwo = 6;
			public const int strike = 10;
			public BowlingScore playerOne;
			public Random rnd;
			public int randomNonStrikeRoll;


			[SetUp]
			public void BeforeTest()
			{
				playerOne = new BowlingScore();
				rnd = new Random ();
				randomNonStrikeRoll = rnd.Next (10);
			}

			[Test ()]
			public void SaveScoreForRollOne ()
			{
				playerOne.RollOne (randomNonStrikeRoll);
				Assert.AreEqual (randomNonStrikeRoll, playerOne.setsFirstRoll [playerOne.setNumber]);
		    }

			[Test()]
			public void SaveScoreForRollTwo ()
			{
				playerOne.RollTwo (randomNonStrikeRoll);
				Assert.AreEqual (randomNonStrikeRoll, playerOne.setsSecondRoll [playerOne.setNumber - 1]);
			}

			[Test()]
			public void IncreaseSetNumberOnSecondRoll ()
			{
				Assert.AreEqual (0, playerOne.setNumber);

				playerOne.RollTwo (randomNonStrikeRoll);
				Assert.AreEqual (1, playerOne.setNumber);
			}

			[Test()]
			public void RollsAddToTotalScore ()
			{
				Assert.AreEqual (0, playerOne.totalScore);

				playerOne.RollOne (spareRollOne);
				playerOne.RollTwo (spareRollOne);
				Assert.AreEqual ((spareRollOne * 2), playerOne.totalScore);
			}

			[Test()]
			public void StrikesIncreaseSetNumber()
			{
				Assert.AreEqual (0, playerOne.setNumber);

				playerOne.RollOne (strike);
				Assert.AreEqual (1, playerOne.setNumber);
			}

			[Test()]
			public void StrikesAddToStrikeCounter()
			{
				Assert.AreEqual(0, playerOne.strikeCounter);

				playerOne.RollOne(strike);
				Assert.AreEqual (2, playerOne.strikeCounter);
			}

			[Test()]
			public void RollsAfterStrikesDecreaseStrikeCounter()
			{
				playerOne.RollOne(strike);
				Assert.AreEqual(2, playerOne.strikeCounter);

				playerOne.RollOne(randomNonStrikeRoll);
				Assert.AreEqual(1, playerOne.strikeCounter);
			}

			[Test()]
			public void StrikeAfterAStrikeDoesntDecreaseStrikeCounter()
			{
				playerOne.RollOne(strike);
				playerOne.RollOne(strike);
				Assert.AreEqual(3, playerOne.strikeCounter);
			}

			[Test()]
			public void StrikeCounterCantExceedThree()
			{
				playerOne.RollOne(strike);
				playerOne.RollOne(strike);
				Assert.AreEqual(3, playerOne.strikeCounter);

				playerOne.RollOne(strike);
				Assert.AreEqual(3, playerOne.strikeCounter);
			}

			[Test()]
			public void StrikesIncreaseNextRollScoreByDouble()
			{
				playerOne.RollOne (strike);
				Assert.AreEqual (strike, playerOne.totalScore);
				
				
				playerOne.RollOne (randomNonStrikeRoll);
				Assert.AreEqual ((strike + (randomNonStrikeRoll * 2)), playerOne.totalScore);
			}

			[Test()]
			public void StrikesIncreaseNextTwoRollScoresByDouble()
			{
				playerOne.RollOne (strike);
				playerOne.RollOne (spareRollOne);
				playerOne.RollTwo (spareRollOne);
				Assert.AreEqual ((strike + (spareRollOne * 4)), playerOne.totalScore); 
			}

			[Test()]
			public void MultipleStrikesStackStrikeBonus()
			{
				for (int i = 0; i < 3; i++) 
				{
					playerOne.RollOne (strike);
				}
				playerOne.RollOne (spareRollOne);
				playerOne.RollTwo (spareRollOne);
				Assert.AreEqual (80, playerOne.totalScore);
			}

			[Test()]
			public void PerfectGameScoreCalculatesCorrectly()
			{
				for (int i = 0; i < 10; i++) 
				{
					playerOne.RollOne (strike);
				}
				playerOne.BonusRoll (strike);
				playerOne.BonusRoll (strike);
				Assert.AreEqual(300, playerOne.totalScore);
			}

			[Test()]
			public void NonStrikesAfterStrikesCorrectlyCalculate()
			{
				playerOne.RollOne (strike);
				playerOne.RollOne (strike);
				playerOne.RollOne (spareRollOne);
				playerOne.RollTwo (spareRollOne);
				playerOne.RollOne (strike);
				Assert.AreEqual (60, playerOne.totalScore);
			}
			
			[Test()]
			public void SparesAddOneToStrikeCounter()
			{
				playerOne.RollOne (spareRollOne);
				playerOne.RollTwo (spareRollTwo);
				Assert.AreEqual (1, playerOne.strikeCounter);
			}

			[Test()]
			public void SparesIncreaseNextRollByDouble()
			{
				playerOne.RollOne (spareRollOne);
				playerOne.RollTwo (spareRollTwo);
				Assert.AreEqual (strike, playerOne.totalScore);

				playerOne.RollOne (randomNonStrikeRoll);
				Assert.AreEqual (strike + (randomNonStrikeRoll * 2), playerOne.totalScore);
			}

			[Test()]
			public void StrikeOnTenthSetAddsTwoToBonusRollCounter()
			{
				int counter = 0;
				while (counter < 9) 
				{
					playerOne.RollOne (strike);
					counter++;
				}

				playerOne.RollOne (strike);
				Assert.AreEqual (2, playerOne.bonusRollCounter);
			}

			[Test()]
			public void SpareOnTenthSetAddsOneToBonusRollCounter()
			{
				int counter = 0;
				while (counter < 9) 
				{
					playerOne.RollOne (strike);
					counter++;
				}

				playerOne.RollOne (spareRollOne);
				playerOne.RollTwo (spareRollTwo);
				Assert.AreEqual (1, playerOne.bonusRollCounter);
			}

	}
}