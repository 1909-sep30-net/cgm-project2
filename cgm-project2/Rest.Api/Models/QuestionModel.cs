using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Models
{
    /// <summary>
    /// Compare to Domains.Library.Models.Question
    /// </summary>
    public class QuestionModel
    {
        public int TitleId { get; set; }
        public string QuestionString { get; set; }
    }
}
