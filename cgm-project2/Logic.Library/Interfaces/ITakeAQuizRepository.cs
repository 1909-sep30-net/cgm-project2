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

        public void Save();

    }
}
