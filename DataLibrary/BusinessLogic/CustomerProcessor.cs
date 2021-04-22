using Dapper;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLibrary.DataAccess.SqlDataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class CustomerProcessor
    {
        public static int CustomerRegister(string custFirstName, string custLastName, string custAddress, string custCity,
                                        string custProv, string custPostal, string custCountry, string custhomePhone, string custBusPhone,
                                        string custEmail, string password, out string error)
        {
            string sql = @"dbo.Customer_Register  @CustFirstName, @CustLastName,@CustAddress,@CustCity,@CustProv,@CustPostal,
                                    @CustCountry,@CustHomePhone, @CustBusPhone, @CustEmail, @Password, @Error OUT";

            var p = new DynamicParameters();
            //p.Add("@CustomerId", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@CustFirstName", custFirstName);
            p.Add("@CustLastName", custLastName);
            p.Add("@CustAddress", custAddress);
            p.Add("@CustCity", custCity);
            p.Add("@CustProv", custProv);
            p.Add("@CustPostal", custPostal);
            p.Add("@CustCountry", custCountry);
            p.Add("@CustHomePhone", custhomePhone);
            p.Add("@CustBusPhone", custBusPhone);
            p.Add("@CustEmail", custEmail);
            p.Add("@Password", password);
            p.Add("@Error", null, DbType.String, ParameterDirection.Output, 100);

            int affectedRows =  EditData(sql, p);
            error = p.Get<string>("@Error");
            return affectedRows;
        }


        public static Customer GetCustomer(string email)
        {
            string sql = @"dbo.Customer_GetByEmail @CustEmail";
            var p = new DynamicParameters();
            p.Add("@CustEmail", email);
            return LoadSingleData<Customer>(sql, p);
        }

        public static int UpdateCustomer(string custFirstName, string custLastName, string custAddress, string custCity,
                                        string custProv, string custPostal, string custCountry, string custhomePhone, string custBusPhone,
                                        string custEmail, int? agentId)
        {
            Customer cust = new Customer
            {
                CustFirstName = custFirstName,
                CustLastName = custLastName,
                CustAddress = custAddress,
                CustCity = custCity,
                CustProv = custProv,
                CustPostal = custPostal,
                CustCountry = custCountry,
                CustHomePhone = custhomePhone,
                CustBusPhone = custBusPhone,
                CustEmail = custEmail,
                AgentId = agentId
            };

            string sql = @"dbo.Customer_Update  @CustFirstName, @CustLastName,@CustAddress,@CustCity,@CustProv,@CustPostal,
                                    @CustCountry,@CustHomePhone, @CustBusPhone, @CustEmail, @AgentId";

            return EditData(sql, cust);

        }

    }
}
