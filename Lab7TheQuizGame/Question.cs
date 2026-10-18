namespace QuizGame
{
    // This Question class was written by me with AI guidance regarding
    // the structure.

    // This class holds the data for a quiz question
    internal class Question
    {
        public string Text { get; set; } // Question
        public List<string> Options { get; set; } // Answer options
        public int CorrectIndex { get; set; } // Index of correct answer

        // Constructor
        // Questions are created in the Quiz-class
        public Question(string text, List<string> options, int correctIndex)
        {
            Text = text;
            Options = options;
            CorrectIndex = correctIndex;
        }
    }
}