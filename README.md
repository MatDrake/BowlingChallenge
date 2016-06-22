# BowlingChallenge

A C# console application designed to help track a user's score for a game of 10-pin bowling

Author: Mat Drake

Created: 31st May 2016

Last updated: 22nd June 2016

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

Now the validation is working as intended, the next feature being worked on is have the total score displayed alongside your previous rolls for each set. i.e.:

|X|7,/|7,2|7,-|X|1,5|4,4|4,/|9,-|X||X X


 'X'  being a strike
 
 '/'  being a spare
 
 '-'  being a miss
 
 '|'  being the frame boundries
 
 '||' being the end of the 10th set and start of bonus balls
