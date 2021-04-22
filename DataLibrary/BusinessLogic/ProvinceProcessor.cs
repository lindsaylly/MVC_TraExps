using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class ProvinceProcessor
    {
        //public static List<Province> LoadProvince(int countryId)
        //{
        //    string sql = @"dbo.Provinces_GetByCountryId @CountryId";

        //    var p = new DynamicParameters();
        //    p.Add("@CountryId", countryId);

        //    return SqlDataAccess.LoadData<Province>(sql, p);
        //}
        public static List<Province> LoadProvince(string countryName)
        {
            string sql = @"dbo.Provinces_GetByCountryName @CountryName";

            var p = new DynamicParameters();
            p.Add("@CountryName", countryName);

            return SqlDataAccess.LoadData<Province>(sql, p);
        }
    }
}
