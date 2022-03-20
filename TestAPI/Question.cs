using System.ComponentModel.DataAnnotations;

namespace TestAPI
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Options { get; set; } = string.Empty;
        public int CorrectAnswer { get; set; }

    }
}
