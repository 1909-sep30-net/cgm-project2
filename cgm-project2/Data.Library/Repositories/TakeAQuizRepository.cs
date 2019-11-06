﻿using System;
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
            if (Id != -1 && title != null)
            {
                quizTitle = GetQuizByNameOrId(Id, title).FirstOrDefault();
            }
            else if (Id != -1)
            {
                quizTitle = GetQuizByNameOrId(Id).FirstOrDefault();
            }
            else if (title != null)
            {
                quizTitle = GetQuizByNameOrId(-1,title).FirstOrDefault();
            }
            else
            {
                return null;
            }

            //create a quiz object to return to render. Use Title obj as constructor parameter.
            LogLib.Models.Quiz quiz = new LogLib.Models.Quiz(quizTitle);

            //get all questions with the TitleId and load into Quiz Obj in foreach loop



            //get all answers to each question in foreach loop




            return quiz;
        }

        public 



        /// <summary>
        /// This saves the state of the DB
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
