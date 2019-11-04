using System;
using System.Collections.Generic;
using System.Text;
using LogLibMod = Logic.Library.Models;

namespace Logic.Library.Interfaces
{
    public interface ICreateQuizRepository
    {
        public void CreateTitle(LogLibMod.Title title);

        public void CreateCategory(LogLibMod.Category category);

        public void CreateQuestion(LogLibMod.Question question);

        public void CreateAnswer(LogLibMod.Answer answer);

        public void DeleteQuiz(int titleId);

        public void Save();
    }
}
