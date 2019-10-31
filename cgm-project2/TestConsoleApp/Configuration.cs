using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsoleApp
{
    public static class Configuration
    {
        private static string connectionString = "Host=salt.db.elephantsql.com;Port=5432;Database=ecgbhozp;Username=ecgbhozp;Password=3YKSZmIYGnqvKceoPKMZzc0n1h5CU_g0;";
        
        public static string GetConnectionString(string mockString)
        {
            return connectionString;
        }
    }
}
