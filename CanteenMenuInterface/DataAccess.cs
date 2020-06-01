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
        /// <summary>
        /// Gets us the Menus from DB
        /// </summary>
        /// <returns></returns>
        public List<MenuModel> GetMenus()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("CanteenMenuDB")))
            {
                //var output = connection.Query<MenuModel>("select * from Menu").ToList();
                var output = connection.Query<MenuModel>("dbo.MenuViewAll").ToList();

                return output;
            }
        }

        /// <summary>
        /// Adds a Menu to DB
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void InsertMenu(string name, string description)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("CanteenMenuDB")))
            {
                MenuModel menuModel = new MenuModel
                {
                    Id = 0,
                    Name = name,
                    Description = description
                };

                connection.Execute("dbo.MenuAddOrEdit @Id, @Name, @Description", menuModel);

            }
        }
    }
}
