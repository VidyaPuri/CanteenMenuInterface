using Caliburn.Micro;
using CanteenMenuInterface.Helpers;
using CanteenMenuInterface.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CanteenMenuInterface
{
    public class DataAccess
    {
        public List<MenuModel> GetMenus()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("CanteenMenuDB")))
            {
                var output = connection.Query<MenuModel>("select * from Menu").ToList();

                return output;
            }
        }
    }
}
