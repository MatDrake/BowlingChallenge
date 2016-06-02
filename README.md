# BowlingChallenge

A C# console application designed to help track a user's score for a game of 10-pin bowling

Author: Mat Drake

Created: 31st May 2016

Last updated: 3rd June 2016

----------

The program files are saved within the folder BowlingGame and the tests are contained within BowlingGameTests.

There are three classes of:
- BowlingGame
- BowlingScore
- BowlingSets

BowlingGame contains the main method that runs on launch, with BowlingSets managing the input and out of the program and BowlingScore handling the calculations.

Running the application will prompt you to input the amount of pins you knocked down for each roll. This needs to be entered as a number between 0 - 10. You will be told which roll of which set you are entering the score for and your total score will be displayed each time you enter a new roll.

----------

Work in Progress:

Currently there is no conditioning in place to verify that a valid number of pins is entered for a set; you can enter 9 pins for your first roll and 9 pins for a second roll of a set.

It is intended for this to be resolved in the next update.
