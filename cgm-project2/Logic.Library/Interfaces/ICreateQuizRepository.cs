using System;
using System.Collections.Generic;
using System.Text;
using LogLib = Logic.Library;

namespace Logic.Library.Interfaces
{
    public interface ICreateQuizRepository
    {
        public LogLib.Models.Title CreateTitle(int titleId, string titleString, int creatorId);

        public LogLib.Models.Category CreateCategory(int categoryId, string categoryString, string categoryDescription, int titleId);

        public LogLib.Models.Question CreateQuestion(int questionId, string questionString, int titleId);

        public LogLib.Models.Answer CreateAnswer(int answerId, string answerString, int weight, int categoryId, int questionId);

        public void CreateFinalQuiz(); 

        public void DeleteQuiz();

        public void Save();
    }
}
