using System;
using System.Collections.Generic;
using System.Text;
using LogLib = Logic.Library.Models;
using Data.Library;


namespace Data.Library
{
    public static class Mapper
    {

        //entity to Class
        public static LogLib.User MapUser(Entities.User user)
        {
            return new LogLib.User()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Street = user.Street,
                City = user.City,
                State = user.State,
                Zip = user.Zip
            };
        }

        //class to entity
        public static Entities.User MapUser(LogLib.User user)
        {
            return new Entities.User
            {
                //user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Street = user.Street,
                City = user.City,
                State = user.State,
                Zip = user.Zip
            };
        }

        //entity to class
        public static LogLib.Title MapTitle(Entities.Title title)
        {
            return new LogLib.Title(title.TitleId,title.TitleString, title.CreatorId);
        }

        //class to entity
        public static Entities.Title MapTitle(LogLib.Title title)
        {
            return new Entities.Title
            {
                //title.TitleId,
                TitleString = title.TitleString,
                CreatorId = title.CreatorId
            };
        }

        //entity to class
        public static LogLib.Result MapResult(Entities.Result result)
        {
            return new LogLib.Result(result.ResultId, result.Score, result.TakerId, result.TitleId);
        }

        //class to entity
        public static Entities.Result MapResult(LogLib.Result result)
        {
            return new Entities.Result
            {
                //result.ResultId,
                Score = result.Score,
                TakerId = result.TakerId,
                TitleId = result.TitleId
            };
        }

        //entity to class
        public static LogLib.Question MapQuestion(Entities.Question question)
        {
            return new LogLib.Question(question.QuestionId, question.TitleId, question.QuestionString);
        }

        //class to entity
        public static Entities.Question MapQuestion(LogLib.Question question)
        {
            return new Entities.Question
            {
                //question.QuestionId,
                TitleId = question.TitleId,
                QuestionString = question.QuestionString,
            };
        }

        //entity to class
        public static LogLib.Category MapCategory(Entities.Category category)
        {
            return new LogLib.Category(category.CategoryId, category.TitleId, category.Rank, category.CategoryString, category.CategoryDescription);
        }

        //class to entity
        public static Entities.Category MapCategory(LogLib.Category category)
        {
            return new Entities.Category
            {
                //category.CategoryId,
                TitleId = category.TitleId,      //this needs to be manually searched and inserted before getting here.
                Rank = category.Rank,
                CategoryString = category.CategoryString,
                CategoryDescription = category.CategoryDescription
            };
        }

        //entity to class
        public static LogLib.Answer MapAnswer(Entities.Answer answer)
        {
            return new LogLib.Answer(answer.AnswerId, answer.AnswerString, answer.Weight, answer.CategoryId, answer.QuestionId);
        }

        //class to entity
        public static Entities.Answer MapAnswer(LogLib.Answer answer)
        {
            return new Entities.Answer
            {
                //answer.AnswerId,
                AnswerString = answer.AnswerString,
                Weight = answer.Weight,
                CategoryId = answer.CategoryId,
                QuestionId = answer.QuestionId
            };
        }
    }
}
