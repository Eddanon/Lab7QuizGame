namespace QuizGame
{
    // The structure of this class (menu loop, random question and
    // point counting) was inspired by AI's suggestions.
    // I wrote all the questions myself.
    internal class Quiz
    {
        private List<Question> questions; // This list will get filled with questions
        private int points = 0; // Point counter for the player
        private Random random = new Random();

        // Creates the game and fills the question list
        public Quiz()
        {
            questions = CreateQuestions();
        }

        // Questions are added below
        private List<Question> CreateQuestions()
        {
            List<Question> list = new List<Question>();

            list.Add(new Question(
                "Vad är 2 + 2?",
                new List<string> { "3", "4", "5" },
                1));

            list.Add(new Question(
                "Vad är 10 + 2?",
                new List<string> { "12", "4", "8" },
                0));

            list.Add(new Question(
                "Vad är 50 / 2?",
                new List<string> { "0", "15", "25" },
                2));

            list.Add(new Question(
                "Vilken är Sveriges huvudstad?",
                new List<string> { "Oslo", "Göteborg", "Stockholm", "Malmö" },
                2));

            list.Add(new Question(
                "Vilken av dessa frukter är gul?",
                new List<string> { "Vattenmelon", "Banan", "Plommon" },
                1));

            list.Add(new Question(
                "Vilken tunnelbanelinje har en station vid Ropsten?",
                new List<string> { "Röd linje 13", "Grön linje 19", "Blå linje 11" },
                0));

            list.Add(new Question(
                "Vilket land har den största befolkningen?",
                new List<string> { "USA", "Indien", "Kina", "Mongoliet" },
                1));

            list.Add(new Question(
                "Vilket av dessa djur är en reptil?",
                new List<string> { "Gås", "Huggorm", "Åsna", "Kamel" },
                1));

            return list;
        }

        // This is the main loop of the game
        public void Run()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Välkommen till detta enkla nybörjar-quiz!");
            Console.WriteLine("-----------------------------------------");

            bool keepRunning = true;
            while (keepRunning)
            {
                string choice = ShowMainMenu();

                switch (choice)
                {
                    case "1":
                        if (questions.Count == 0)
                        {
                            Console.WriteLine("Det är slut på frågor!");
                            keepRunning = false; // End the game
                        }
                        else
                        {
                            AskQuestion();
                        }
                        break;
                    case "2":
                        Console.WriteLine($"Du har {points} poäng.");
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                }
            }

            Console.WriteLine($"Tack för att du spelade! Dina poäng: {points}");
        }

        // Shows the menu and keeps asking until the input is 1, 2 or 0
        private string ShowMainMenu()
        {
            Console.WriteLine("\nVAD VILL DU GÖRA?\n" +
                              "[1] Gå till nästa fråga\n" +
                              "[2] Visa poäng\n" +
                              "[0] Avsluta spelet");

            while (true)
            {
                string userChoice = Console.ReadLine() ?? "";

                if (userChoice == "1" || userChoice == "2" || userChoice == "0")
                {
                    return userChoice;
                }

                Console.WriteLine("Välj ett av de giltiga alternativen.");
            }
        }

        // Picks a random question, removes it, asks it and updates the point counter
        private void AskQuestion()
        {
            // Chooses a random index number among the questions
            int index = random.Next(questions.Count);
            Question question = questions[index];
            questions.RemoveAt(index); // Prevents the same question from appearing twice

            Console.WriteLine("\n" + question.Text);
            Console.WriteLine("(Välj en siffra)");
            for (int i = 0; i < question.Options.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {question.Options[i]}"); // +1 because the user counts from 1
            }

            int answer = ReadAnswer(question.Options.Count);

            // answer - 1 converts the user's number to a list index
            if (answer - 1 == question.CorrectIndex)
            {
                points++;
                Console.WriteLine("Rätt svar! +1 poäng");
            }
            else
            {
                points = Math.Max(0, points - 1); // Points never go below 0
                Console.WriteLine($"Fel svar! Rätt svar var: {question.Options[question.CorrectIndex]}");
            }
        }

        // Keeps asking until the user types a number between 1 and numberOfOptions
        private int ReadAnswer(int numberOfOptions)
        {
            while (true)
            {
                // ?? "" is used to avoid input equaling to null
                string input = Console.ReadLine() ?? "";

                // TryParse is used to avoid an error if the input isn't an integer.
                if (int.TryParse(input, out int number) && number >= 1 && number <= numberOfOptions)
                {
                    return number;
                }

                Console.WriteLine($"Skriv ett nummer mellan 1 och {numberOfOptions}.");
            }
        }
    }
}