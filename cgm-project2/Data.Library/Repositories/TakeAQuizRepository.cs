using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DatLib = Data.Library;
using LogLib = Logic.Library;
using Logic.Library.Interfaces;


namespace Data.Library.Repositories
{
    public class TakeAQuizRepository : ITakeAQuizRepository
    {
        private readonly Entities.ecgbhozpContext _dbContext;
        public TakeAQuizRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// This method takes  the name or Id (or both) of a quiz and returns the quizes matching the criteria.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public IEnumerable<LogLib.Models.Title> GetQuizByNameOrId(int Id = -1, string title = null)
        {
            IQueryable<Entities.Title> titles = _dbContext.Title.AsNoTracking();

            if (Id != -1)
            {
                titles = titles.Where(i => i.TitleId == Id);
            }
            if (title != null)
            {
                titles = titles.Where(i => i.TitleString == title);
            }
            return titles.Select(Mapper.MapTitle);
        }

        /// <summary>
        /// This method takes a quiz Id and/or title and returns a Quiz object which contains all the data for the quiz
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public LogLib.Models.Quiz GetQuiz(int Id = -1, string title = null)
        {
            //make a Title object
            LogLib.Models.Title quizTitle = new LogLib.Models.Title();

            //get needed title object
            if (Id != -1 && !string.IsNullOrEmpty(title))
            {
                quizTitle = GetQuizByNameOrId(Id, title).FirstOrDefault();
            }
            else if (Id != -1)
            {
                quizTitle = GetQuizByNameOrId(Id).FirstOrDefault();
            }
            else if (!string.IsNullOrEmpty(title))
            {
                quizTitle = GetQuizByNameOrId(title:title).FirstOrDefault();
            }
            else
            {
                return null;
            }

            //create a quiz object to return to render. Use Title obj as constructor parameter.
            LogLib.Models.Quiz quiz = new LogLib.Models.Quiz(quizTitle);

            //get all questions with the TitleId 
            var quizQuestions = GetQuestionsFromTitleId(quiz.title.TitleId);

            //load mapped question obj into Quiz.questions List<Question> in foreach loop
            foreach (var item in quizQuestions)
            {
                var insert = Mapper.MapQuestion(item);
                quiz.questions.Add(insert);
            }

            //get all answers to each question in foreach loop
            foreach (var item in quiz.questions)
            {
                //get all answers for this quesiton
                var questionAnswers = GetAnswersFromQuestionId(item.QuestionId);

                //use a loop to add qnswers to quiz.questions.answers( here, x .answers)
                foreach (var x in questionAnswers)
                {
                    item.answers.Add(Mapper.MapAnswer(x)); 
                }
            }

            //Use titleID to get the categories that go along with the Quiz TitleId.
            var categories = GetCategoriesFromTitleId(quiz.title.TitleId);

            //populate the Category array with the categories.
            foreach (var item in categories)
            {
                quiz.category.Add(Mapper.MapCategory(item));
            }
            return quiz;
        }
        
        /// <summary>
        /// This method gets all the categories for a Quiz based on the Quiz TitleId.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Entities.Category> GetCategoriesFromTitleId(int Id)
        {
            return _dbContext.Category.Where(i => i.TitleId == Id).AsNoTracking().ToList();
        }

        /// <summary>
        /// This method gets all the Answers for a Question based on the QuestionId.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Entities.Answer> GetAnswersFromQuestionId(int Id)
        {
            return _dbContext.Answer.Where(i => i.QuestionId == Id).AsNoTracking().ToList();
        }

        /// <summary>
        /// THis method gets all the Questions for a Quiz based on the TitleId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Entities.Question> GetQuestionsFromTitleId(int Id)
        {
            return _dbContext.Question.Where(i => i.TitleId == Id).AsNoTracking().ToList();
        }

        /// <summary>
        /// This method takes an array with userId, TitleId,...questionAnswers...  from Angular model which tool the quiz rew results and populated an Angular Model.
        ///  Then, returns a Result to be rendered.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public /*LogLib.Models.Category*/ void EvaluateQuiz(int[] formValues)
        {
            /***FYI***arr[0] = userId;***/
            /***FYI***arr[1] = titleId;***/
            
            int totalScore = 0;//to hold the total waights of the choices.
            foreach (var item in formValues)
            {
                totalScore += item;
            }
            totalScore -= formValues[0];
            totalScore -= formValues[1];

            //query db for categories based on TitleId





            //This method will.....
            //sum the total score.
            //determine the category acheived by the user.(with GetResultCategory()
            //construct the Results Object.
            //insert the Result to DB
            //
            //
            //
        }

        /// <summary>
        /// This method takes the criteria for evaluating a quiz and returns the Category determined.
        /// </summary>
        /// <param name="titleId"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        private LogLib.Models.Category GetResultCategory(int titleId, int score)
        {

            //TODO
            return null;
        }

        /// <summary>
        /// This saves the state of the DB
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
