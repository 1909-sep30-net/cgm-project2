using System;
using System.Collections.Generic;
using System.Text;
using LogLibMod = Logic.Library.Models;

namespace Logic.Library.Interfaces
{
    public interface IResultRepository
    {
        public IEnumerable<LogLibMod.Result> GetResults(int userId = -1);

        public void CalculateDemographics();
    }
}
