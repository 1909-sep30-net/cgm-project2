using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Library
{
    public static class Mapper
    {

        /// <summary>
        /// Map Db Entities to Logs
        /// </summary>
        /// <param name="testItem"></param>
        /// <returns></returns>
        public static LogLib.TestClass MapTest(Entities.Testtable testItem)
        {
            return new LogLib.TestClass { TestId = testItem.Testid };
        }

        //entity to Class
        public static LogLib.Models.User MapUser(Entities.User user)
        {
            return new LogLib.Models.User
            {
                user.UserId,
                user.FirstName,
                user.LastName,
                user.Street,
                user.City,
                user.State,
                user.Zip
            };
        }

        //class to entity
        public static Entities.User MapUser(LogLib.Models.User user)
        {
            return new Entities.User
            {
                //user.UserId,
                user.FirstName,
                user.LastName,
                user.Street,
                user.City,
                user.State,
                user.Zip
            };
        }

        //entity to class
        public static LogLib.Models.Title MapTitle(Entities.Title title)
        {
            return new LogLib.Models.Title
            {
                title.TitleId,
                title.TitleString,
                title.CreatorId
            };
        }

        //class to entity
        public static Entities.Title MapTitle(LogLib.Models.Title title)
        {
            return new Entities.Title
            {
                //title.TitleId,
                title.TitleString,
                title.CreatorId
            };
        }

        //entity to class
        public static LogLib.Models.Result MapResult(Entities.Result result)
        {
            return new LogLib.Models.Result
            {
                result.ResultId,
                result.Score,
                result.TakerId,
                result.TitleId
            };
        }

        //class to entity
        public static Entities.Result MapResult(LogLib.Models.Result result)
        {
            return new Entities.Result
            {
                //result.ResultId,
                result.Score,
                result.TakerId,
                result.TitleId
            };
        }

        //entity to class
        public static LogLib.Models.Question MapQuestion(Entities.Question question)
        {
            return new LogLib.Models.Question
            {
                result.QuestionId,
                question.TitleId,      //this needs to be manually searched and inserted before getting here.
                question.QuestionString,
            };
        }

        //class to entity
        public static Entities.Question MapQuestion(LogLib.Models.Question question)
        {
            return new Entities.Question
            {
                //question.QuestionId,
                question.TitleId,  
                question.QuestionString,
            };
        }

        //entity to class
        public static LogLib.Models.Category MapCategory(Entities.Category category)
        {
            return new LogLib.Models.Category
            {
                category.CategoryId,
                category.TitleId,      //this needs to be manually searched and inserted before getting here.
                category.Rank,
                category.CategoryString,
                category.CategoryDescription
            };
        }

        //class to entity
        public static Entities.Category MapCategory(LogLib.Models.Category category)
        {
            return new Entities.Category
            {
                //category.CategoryId,
                category.TitleId,      //this needs to be manually searched and inserted before getting here.
                category.Rank,
                category.CategoryString,
                category.CategoryDescription
            };
        }

        //entity to class
        public static LogLib.Models.Answer MapAnswer(Entities.Answer answer)
        {
            return new LogLib.Models.Answer
            {
                answer.AnswerId,
                answer.AnswerString,      
                answer.Weight,
                answer.CategoryId,          //this needs to be manually searched and inserted before getting here.
                answer.QuestionId           //this needs to be manually searched and inserted before getting here.
            };
        }

        //class to entity
        public static Entities.Answer MapAnswer(LogLib.Models.Answer answer)
        {
            return new Entities.Answer
            {
                //answer.AnswerId,
                answer.AnswerString,
                answer.Weight,
                answer.CategoryId,
                answer.QuestionId
            };
        }
    }
}
