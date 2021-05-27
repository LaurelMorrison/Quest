using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main()
        {
            System.Console.Write("Enter player's name: ");

            string name = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = ("the player with no name");
                System.Console.WriteLine("Fine, don't say 'hello'!");
                PlayGame();
            }
            else
            {
                System.Console.WriteLine($"Hello, {name}! Let's play.");
                PlayGame();
            }

            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            void PlayGame()
            {
                Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
                Challenge theAnswer = new Challenge(
                    "What's the answer to life, the universe and everything?", 42, 25);
                Challenge whatSecond = new Challenge(
                    "What is the current second?", DateTime.Now.Second, 50);

                int randomNumber = new Random().Next() % 10;
                Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

                Challenge favoriteBeatle = new Challenge(
                    @"Who's your favorite Beatle?
                        1) John
                        2) Paul
                        3) George
                        4) Ringo
                            ",
                    4, 20
                );


                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                // Make a new "Adventurer" object using the "Adventurer" class

                Robe PlayersRobe = new Robe();
                {
                    PlayersRobe.Length = 12;
                    PlayersRobe.Colors = new List<string> { "red", "blue", "green" };
                }
                Adventurer theAdventurer = new Adventurer(name, PlayersRobe);

                Console.WriteLine(theAdventurer.GetDescription());


                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle
            };

                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in challenges)
                {
                    challenge.RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }
            }



            bool repeatQuestion = true;
            int response = 0;
            while (repeatQuestion)
            {
                Console.Write(@"Would you like to play again?
                1. yes
                2. no"
                );
                response = int.Parse(Console.ReadLine());
                int yes = 1;
                int no = 2;
                if (response == yes)
                {
                    Console.WriteLine("Round 2");
                    PlayGame();
                    repeatQuestion = false;
                }
                else if (response == no)
                {
                    Console.WriteLine("BYE THEN");
                    repeatQuestion = false;

                }
                else
                {
                    Console.WriteLine("answer valid response");
                    repeatQuestion = true;
                }
            }
        }
    }
}