using System;
using System.Collections.Generic;
using System.Text;
using LogLibMod = Logic.Library.Models;

namespace Logic.Library.Interfaces
{
    public interface ICreateQuizRepository
    {
        public LogLibMod.Title CreateTitle(int titleId, string titleString, int creatorId);

        public LogLibMod.Category CreateCategory(int categoryId, string categoryString, string categoryDescription, int titleId);

        public LogLibMod.Question CreateQuestion(int questionId, string questionString, int titleId);

        public LogLibMod.Answer CreateAnswer(int answerId, string answerString, int weight, int categoryId, int questionId);

        public void CreateFinalQuiz(LogLibMod.Title title, List<LogLibMod.Category> categories, List<LogLibMod.Question> questions, List<LogLibMod.Answer> answers); 

        public void DeleteQuiz();

        public void Save();
    }
}
