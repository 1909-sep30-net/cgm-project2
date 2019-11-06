﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Models
{
    public class AnswerModel
    {
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string AnswerString { get; set; }
        public int Weight { get; set; }
    }
}
