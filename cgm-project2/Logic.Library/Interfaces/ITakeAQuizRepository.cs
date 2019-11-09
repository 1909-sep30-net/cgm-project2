using System;
using System.Collections.Generic;
using System.Text;
//using DatLib = Data.Library;
using LogLib = Logic.Library;

namespace Logic.Library.Interfaces
{
    public interface ITakeAQuizRepository
    {
        public IEnumerable<Models.Title> GetQuizByNameOrId(int Id = -1, string title = null);
        
        //public List<DatLib.Entities.Category> GetCategoriesFromTitleId(int Id);
        
        //public List<DatLib.Entities.Answer> GetAnswersFromQuestionId(int Id);
        
        //public List<DatLib.Entities.Question> GetQuestionsFromTitleId(int Id);
        
        public Models.Quiz GetQuiz(int Id = -1, string title = null);
        
        public Models.Category EvaluateQuiz(List<int> formValues);

        //public Models.Category GetResultCategory(int titleId, int score);

        public void Save();

    }
}
