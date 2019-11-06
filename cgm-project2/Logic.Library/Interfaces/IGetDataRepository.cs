using System;
using System.Collections.Generic;
using System.Text;
using LogLib = Logic.Library;

namespace Logic.Library.Interfaces
{
    public interface IGetDataRepository
    {
        public bool IfUserExists(int userId);

        public bool IfTitleExists(int userId);

        public int GetLastTitleId(int creatorId);

        public int GetNumberOfCategories(int titleId);
    }
}
