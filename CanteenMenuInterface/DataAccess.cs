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
        #region Menu Methods

        /// <summary>
        /// Gets us the Menus from DB
        /// </summary>
        /// <returns></returns>
        public List<MenuModel> GetMenus()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
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
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                MenuModel menuModel = new MenuModel
                {
                    MenuKey = 0,
                    MenuName = name,
                    Description = description
                };

                connection.Execute("dbo.MenuAddOrEdit @MenuKey, @MenuName, @Description", menuModel);

            }
        }

        /// <summary>
        /// Deletes selected menu
        /// </summary>
        /// <param name="selectedMenuIdx"></param>
        public void DeleteMenu(int selectedMenuIdx)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                connection.Execute("dbo.MenuDeleteByID @MenuKey", new { MenuKey = selectedMenuIdx });
            }
        }

        /// <summary>
        /// Edit selected menu
        /// </summary>
        /// <param name="menuKey"></param>
        /// <param name="menuNameInput"></param>
        /// <param name="menuDescriptionInput"></param>
        public void EditMenu(int menuKey, string menuNameInput, string menuDescriptionInput)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                MenuModel menuModel = new MenuModel
                {
                    MenuKey = menuKey,
                    MenuName = menuNameInput,
                    Description = menuDescriptionInput
                };

                connection.Execute("dbo.MenuAddOrEdit @MenuKey, @MenuName, @Description", menuModel);
            }
        }

        #endregion

        #region User Methods

        /// <summary>
        /// Gets us the Menus from DB
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetUsers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                var output = connection.Query<UserModel>("dbo.UserViewAll").ToList();

                return output;
            }
        }

        /// <summary>
        /// Adds a Menu to DB
        /// </summary>
        public void InsertUser(string firstName, string lastName, string email, int userRoleKey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                UserModel userModel = new UserModel
                {
                    UserKey = 0,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserRoleKey = userRoleKey
                };

                connection.Execute("dbo.UserAddOrEdit @UserKey, @FirstName, @LastName, @Email, @UserRoleKey", userModel);

            }
        }

        /// <summary>
        /// Deletes selected menu
        /// </summary>
        public void DeleteUser(int selectedUserKey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                connection.Execute("dbo.UserDeleteByID @UserKey", new { UserKey = selectedUserKey });
            }
        }

        /// <summary>
        /// Edit selected menu
        /// </summary>
        public void EditUser(int userKey, string firstName, string lastName, string email, int userRoleKey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                UserModel userModel = new UserModel
                {
                    UserKey = userKey,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserRoleKey = userRoleKey
                };

                connection.Execute("dbo.UserAddOrEdit @UserKey, @FirstName, @LastName, @Email, @UserRoleKey", userModel);
            }
        }

        #endregion

        #region DateMenu Methods

        /// <summary>
        /// Return the list of all Date Menus in DB
        /// </summary>
        /// <returns></returns>
        public List<DateMenuModel> GetDateMenu()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                var output = connection.Query<DateMenuModel>("dbo.DateMenuViewAll").ToList();

                return output;
            }
        }

        /// <summary>
        /// Return Menus at specified date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public List<MenuModel> GetDateMenuByDateReturnMenus(DateTime dateTime)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                var output = connection.Query<MenuModel>("dbo.DateMenuGetByDateReturnMenus @Date", new { Date = dateTime }).ToList();

                 return output;
            }
        }

        /// <summary>
        /// Return DateMenus at specified date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public List<DateMenuModel> GetDateMenuByDate(DateTime dateTime)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                var output = connection.Query<DateMenuModel>("dbo.DateMenuGetByDate @Date", new { Date = dateTime }).ToList();

                return output;
            }
        }

        /// <summary>
        /// Inserts Date Menu to DB
        /// </summary> 
        /// <param name="date"></param>
        /// <param name="menuKey"></param>
        public void InsertDateMenu(DateTime date, int menuKey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                DateMenuModel dateMenuModel = new DateMenuModel
                {
                    DateMenuKey = 0,
                    Date = date,
                    MenuKey = menuKey
                };

                connection.Execute("dbo.DateMenuAddOrEdit @DateMenuKey, @Date, @MenuKey", dateMenuModel);
            }
        }

        /// <summary>
        /// Delete DateMenu 
        /// </summary>
        /// <param name="dateMenuKey"></param>
        public void DeleteDateMenu(int dateMenuKey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                connection.Execute("dbo.DateMenuDeleteByID @DateMenuKey", new { DateMenuKey = dateMenuKey });
            }
        }

        /// <summary>
        /// Delete DateMenu With Date and MenuKey
        /// </summary>
        public void DeleteDateMenuByDateAndMenuKey(int menuKey, DateTime date)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                connection.Execute("dbo.DateMenuDeleteByDateAndMenuKey @MenuKey, @Date", new { MenuKey = menuKey, Date = date });
            }
        }

        /// <summary>
        /// Edits the selected DateMenuEntry
        /// </summary>
        /// <param name="dateMenuKey"></param>
        /// <param name="date"></param>
        /// <param name="menuKey"></param>
        public void EditDateMenu(int dateMenuKey ,DateTime date, int menuKey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                DateMenuModel dateMenuModel = new DateMenuModel
                {
                    DateMenuKey = dateMenuKey,
                    Date = date,
                    MenuKey = menuKey
                };

                connection.Execute("dbo.DateMenuAddOrEdit @DateMenuKey, @Date, @MenuKey", dateMenuModel);
            }
        }

        #endregion

        #region Order Methods

        /// <summary>
        /// Return the list of all Orders in DB
        /// </summary>
        /// <returns></returns>
        public List<OrderModel> GetOrders()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                var output = connection.Query<OrderModel>("dbo.OrderViewAll").ToList();

                return output;
            }
        }

        /// <summary>
        /// Return the list of all Orders at selected day
        /// </summary>
        /// <returns></returns>
        public List<OrderModelJoined> GetOrdersByDay(DateTime date)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                var output = connection.Query<OrderModelJoined>("dbo.OrderViewByDay @Date", new {Date = date }).ToList();

                return output;
            }
        }

        /// <summary>
        /// Return the list of all Orders between two days (one week)
        /// </summary>
        /// <returns></returns>
        public List<OrderModelJoined> GetOrdersByTwoDays(DateTime date1, DateTime date2)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                var output = connection.Query<OrderModelJoined>("dbo.OrderViewByTwoDays @Date1, @Date2", new { Date1 = date1, Date2 = date2 }).ToList();

                return output;
            }
        }

        /// <summary>
        /// Inserts Order to DB
        /// </summary> 
        /// <param name="date"></param>
        /// <param name="menuKey"></param>
        public void InsertOrder(int dateMenuKey, int userKey, int orderStatusKey, string comment)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                OrderModel orderModel = new OrderModel
                {
                    OrderKey = 0,
                    DateMenuKey = dateMenuKey,
                    UserKey = userKey,
                    OrderStatusKey = orderStatusKey,
                    Comment = comment
                };

                connection.Execute("dbo.OrderAddOrEdit @OrderKey, @DateMenuKey, @UserKey, @OrderStatusKey, @Comment", orderModel);
            }
        }

        /// <summary>
        /// Edits Order at Order ID 
        /// </summary> 
        /// <param name="date"></param>
        /// <param name="menuKey"></param>
        public void EditOrder(int orderKey, int dateMenuKey, int userKey, int orderStatusKey, string comment)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                OrderModel orderModel = new OrderModel
                {
                    OrderKey = orderKey,
                    DateMenuKey = dateMenuKey,
                    UserKey = userKey,
                    OrderStatusKey = orderStatusKey,
                    Comment = comment
                };

                connection.Execute("dbo.OrderAddOrEdit @OrderKey, @DateMenuKey, @UserKey, @OrderStatusKey, @Comment", orderModel);
            }
        }

        /// <summary>
        /// Edits Order at Order ID 
        /// </summary> 
        public void EditOrderByKey(int orderKey, int menuKey, string comment)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.CnnVal("CanteenMenuDB")))
            {
                OrderEditModel orderEditModel = new OrderEditModel
                {
                    OrderKey = orderKey,
                    MenuKey = menuKey,
                    Comment = comment
                };

                connection.Execute("dbo.OrderEditByKey @OrderKey, @MenuKey, @Comment", orderEditModel);
            }
        }

        #endregion

        /// <summary>
        /// TO-DO
        /// </summary>
        private bool CheckPravice()
        {
            return false;
        }

    }
}
