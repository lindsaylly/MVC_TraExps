using Dapper;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class CountryProcessor
    {
        public static List<Country> LoadCountry()
        {
            string sql = "dbo.Countries_Get";
            
            return SqlDataAccess.LoadData<Country>(sql);
        }
    }
}
