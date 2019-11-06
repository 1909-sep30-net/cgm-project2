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
            
            //place title obj into quiz obj.
            quiz.title = quizTitle;

            //get all questions with the TitleId 
            IQueryable<Entities.Question> quizQuestions = _dbContext.Question
                .Where(i => i.TitleId == quiz.title.TitleId).AsNoTracking();

            //load mapped question obj into Quiz.questions List<Question> in foreach loop
            foreach (var item in quizQuestions)
            {
                quiz.questions.Add(Mapper.MapQuestion(item));
            }

            //get all answers to each question in foreach loop
            foreach (var item in quiz.questions)
            {
                //get all answers for this quesiton
                IQueryable<Entities.Answer> questionAnswers = _dbContext.Answer
                    .Where(i => i.QuestionId == item.QuestionId).AsNoTracking();

                //use a loop to add qnswers to quiz.questions.answers( here, x .answers)
                foreach (var x in questionAnswers)
                {
                    item.answers.Add(Mapper.MapAnswer(x)); 
                }
            }
            return quiz;
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
