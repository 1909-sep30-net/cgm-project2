﻿using System;
using System.Collections.Generic;
using System.Text;
using LogLib = Logic.Library;

namespace Logic.Library.Interfaces
{
    public interface IGetDataRepository
    {
        public bool UserExists(int userId);

        public bool TitleExists(int userId);

        public bool CategoryExists(int categoryId);

        public bool QuestionExists(int questionId);

        public int GetLastTitleId(int creatorId);

        public int GetNumberOfCategories(int titleId);
        public int GetNumberOfQuestions(int titleId);
        public int GetLastQuestionId(int titleId);
        public int GetLastCategoryId(int titleId);
        public IEnumerable<LogLib.Models.Answer> GetAnswers(int titleId);
    }
}
