namespace BowlingGame
{
	using NUnit.Framework;
	using System;

	[TestFixture ()]
	public class BowlingSetTest
	{
		public BowlingSets game;

		[SetUp]
		public void BeforeTest()
		{
			game = new BowlingSets();
		}
	}
}