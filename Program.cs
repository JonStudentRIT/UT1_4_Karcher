using System;
using System.Timers;

namespace _3QuestionsRecreation
{
    /* Class: Program
     * Author: Jonathan Karcher
     * Purpose: Replicate the three questions program
     */ 
    class Program
    {
        // general user input
        static string input;
        // time up trigger
        static bool timeIsUp = false;
        static string correctAnswer;
        static Timer timer = new Timer();
        /* Method: Main
         * Purpose: Manage if the game is running
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // start the game
            bool play = true;
            // add a newline
            Console.WriteLine();
            do
            {
                // if the replay condition is true then play the game
                if(play)
                {
                    Game();
                }
                // ask the user if they want to play again
                Console.Write("Play again? ");
                input = Console.ReadLine();
                // repeat the question if the entery was invalid
                play = false;
                // replayCondition
                if(input[0] == 'y' || input[0] == 'Y')
                {
                    play = true;
                }
                // exit condition
                if(input[0] == 'n' || input[0] == 'N')
                {
                    break;
                }
                // loop untill the user enters a string starting with n 
            } while (input[0] != 'n' || input[0] != 'N');
        }
        /* Method: Game
         * Purpose: Display the appropriate question
         * Restrictions: None
         */
        static void Game()
        {
            // what question did the user choose
            int question = 0;
            // how many questions are there to choose from
            int numberOfQuestions = 3;
            do
            {
                Console.Write("Choose your question (1-" + numberOfQuestions + "): ");
                input = Console.ReadLine();
                // if the user chose a valid input
            } while (!int.TryParse(input, out question) || question <= 0 || question >= numberOfQuestions + 1);
            // ask the corresponding question
            switch (question)
            {
                case 1:
                    QuestionOne();
                    break;
                case 2:
                    QuestionTwo();
                    break;
                case 3:
                    QuestionThree();
                    break;
                default:
                    break;
            }
        }
        /* Method: QuestionOne
         * Purpose: Display question 1, check for the apropriate answer, and begin the timer
         * Restrictions: None
         */
        static void QuestionOne()
        {
            // reset the time up timer
            timeIsUp = false;
            // reset the answer
            correctAnswer = "black";
            // give the user instructions
            Console.WriteLine("You have 5 seconds to answer the following question:");
            // ask the question
            Console.WriteLine("What is your favorite color?");
            // reset the timer for the player to have 5 seconds
            ResetTimer();
            input = Console.ReadLine();
            // if the user ran out of time then ignore what they enter
            if(timeIsUp)
            {
                return;
            }
            // if they enter the correct answer
            if(input.ToLower() == correctAnswer)
            {
                Console.WriteLine("Well done!");
            }
            // if they enter the wrong answer
            else
            {
                Console.WriteLine("Wrong!  The answer is: " + correctAnswer);
            }
            // stop the timer
            timer.Stop();
        }
        /* Method: QuestionTwo
         * Purpose: Display question 2, check for the apropriate answer, and begin the timer
         * Restrictions: None
         */
        static void QuestionTwo()
        {
            // reset the time up timer
            timeIsUp = false;
            // reset the answer
            correctAnswer = "42";
            // give the user instructions
            Console.WriteLine("You have 5 seconds to answer the following question:");
            // ask the question
            Console.WriteLine("What is the answer to life, the universe and everything?");
            // reset the timer for the player to have 5 seconds
            ResetTimer();
            input = Console.ReadLine();
            // if the user ran out of time then ignore what they enter
            if (timeIsUp)
            {
                return;
            }
            // if they enter the correct answer
            if (input.ToLower() == correctAnswer)
            {
                Console.WriteLine("Well done!");
            }
            // if they enter the wrong answer
            else
            {
                Console.WriteLine("Wrong!  The answer is: " + correctAnswer);
            }
            // stop the timer
            timer.Stop();
        }
        /* Method: QuestionThree
         * Purpose: Display question 3, check for the apropriate answer, and begin the timer
         * Restrictions: None
         */
        static void QuestionThree()
        {
            // reset the time up timer
            timeIsUp = false;
            // reset the answer
            correctAnswer = "What do you mean? African or European swallow?";
            // give the user instructions
            Console.WriteLine("You have 5 seconds to answer the following question:");
            // ask the question
            Console.WriteLine("What is the airspeed velocity of an unladen swallow?");
            // reset the timer for the player to have 5 seconds
            ResetTimer();
            input = Console.ReadLine();
            // if the user ran out of time then ignore what they enter
            if (timeIsUp)
            {
                return;
            }
            // if they enter the correct answer
            if (input.ToLower() == correctAnswer)
            {
                Console.WriteLine("Well done!");
            }
            // if they enter the wrong answer
            else
            {
                Console.WriteLine("Wrong!  The answer is: " + correctAnswer);
            }
            // stop the timer
            timer.Stop();
        }
        /* Method: ResetTimer
         * Purpose: Reset the game timer to 5 seconds
         * Restrictions: None
         */
        static void ResetTimer()
        {
            // set the timer to 5 seconds
            timer = new Timer(5000);
            // create an event handeler
            ElapsedEventHandler elapsedEventHandler = new ElapsedEventHandler(TimeIsUp);
            // add the event handeler to the elapsed listener
            timer.Elapsed += elapsedEventHandler;
            // start the timer
            timer.Start();
        }
        /* Method: TimeIsUp
         * Purpose: Inform the player that they have run out of time, tell them the correct answer, tell the player how to proceed
         * Restrictions: None
         */
        static void TimeIsUp(Object source, System.Timers.ElapsedEventArgs e)
        {
            // tell the user the time is up
            Console.WriteLine("Time's up!");
            // tell the user the correct answer
            Console.WriteLine("The answer is: " + correctAnswer);
            // tell the user how to proceed
            Console.WriteLine("Please press enter.");
            // set the timer trigger to be over
            timeIsUp = true;
            // stop the timer 
            timer.Stop();
        }
    }

}
