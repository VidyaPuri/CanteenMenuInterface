using Caliburn.Micro;
using CanteenMenuInterface.Helpers;
using CanteenMenuInterface.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CanteenMenuInterface.ViewModels
{
    public class ShellViewModel : Screen
    {
        #region Window Control

        private WindowState windowState;
        public WindowState WindowState
        {
            get { return windowState; }
            set
            {
                windowState = value;
                NotifyOfPropertyChange(() => WindowState);
            }
        }

        public void MaximizeWindow()
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        public void MinimizeWindow()
        {
            WindowState = WindowState.Minimized;
        }

        public bool myCondition { get { return (false); } }

        public void CloseWindow()
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region Constructor

        public ShellViewModel()
        {
            ShowMenus();
            ShowUsers();
            FillTheList();
            CurrentDate = DateTime.Today;
            DateChanged();
            UpdateWeeklyMenuTable();
        }

        #endregion

        DataAccess db = new DataAccess();

        #region MENUS

        #region Menu Properties

        private string _MenuNameInput;
        private string _MenuDescriptionInput;
        private List<MenuModel> _MenuList;
        private int _SelectedMenuIdx;
        private MenuModel _SelectedMenu;

        /// <summary>
        /// Menu Name Input initialisation 
        /// </summary>
        public string MenuNameInput
        {
            get { return _MenuNameInput; }
            set => Set(ref _MenuNameInput, value);
        }

        /// <summary>
        /// Menu Description Input initialisation
        /// </summary>
        public string MenuDescriptionInput
        {
            get { return _MenuDescriptionInput; }
            set => Set(ref _MenuDescriptionInput, value);
        }

        /// <summary>
        /// MenumodelsList Init
        /// </summary>
        public List<MenuModel> MenuList
        {
            get { return _MenuList; }
            set => Set(ref _MenuList, value);
        }

        /// <summary>
        /// Selected Menu Idx Initializer
        /// </summary>
        public int SelectedMenuIdx
        {
            get { return _SelectedMenuIdx; }
            set => Set(ref _SelectedMenuIdx, value);
        }

        /// <summary>
        /// Selected Menu
        /// </summary>
        public MenuModel SelectedMenu
        {
            get { return _SelectedMenu; }
            set => Set(ref _SelectedMenu, value);
        }

        private BindableCollection<List<MenuModel>> _SelectedMenusList = new BindableCollection<List<MenuModel>>();

        public BindableCollection<List<MenuModel>> SelectedMenusList
        {
            get { return _SelectedMenusList; }
            set => Set(ref _SelectedMenusList, value);
        }

        private void FillTheList()
        {
            for (int i = 0; i < 5; i++)
            {
                SelectedMenusList.Add(MenuList);
            }
        }

        #endregion

        #region Menu Methods

        /// <summary>
        /// Show Menu List
        /// </summary>
        public void ShowMenus()
        {
            MenuList = db.GetMenus();
        }

        /// <summary>
        /// Adds menu data to database
        /// </summary>
        public void AddMenu()
        {
            db.InsertMenu(MenuNameInput, MenuDescriptionInput);
            ShowMenus();
        }

        /// <summary>
        /// Edit menu data to database
        /// </summary>
        public void EditSelectedMenu()
        {
            if (SelectedMenu != null)
                db.EditMenu(SelectedMenu.MenuKey, MenuNameInput, MenuDescriptionInput);
            ShowMenus();
        }

        /// <summary>
        /// Delete selected menu method
        /// </summary>
        public void DeleteSelectedMenu()
        {
            if (SelectedMenu != null)
                db.DeleteMenu(SelectedMenu.MenuKey);
            ShowMenus();
        }


        #endregion

        #endregion

        #region USERS

        #region User Properties

        private List<UserModel> _UserList = new List<UserModel>();
        private string _UserFirstName;
        private string _UserLastName;
        private string _UserEmail;
        private UserModel _SelectedUser;
        private int _UserRoleKey;
        private int _SelectedUserRoleKey;

        /// <summary>
        /// User List Properties
        /// </summary>
        public List<UserModel> UserList
        {
            get { return _UserList; }
            set => Set(ref _UserList, value);
        }

        /// <summary>
        /// User First Name Properties
        /// </summary>
        public string UserFirstName
        {
            get { return _UserFirstName; }
            set => Set(ref _UserFirstName, value);
        }

        /// <summary>
        /// User Last Name properties
        /// </summary>
        public string UserLastName
        {
            get { return _UserLastName; }
            set => Set(ref _UserLastName, value);
        }

        /// <summary>
        /// User Email Properties
        /// </summary>
        public string UserEmail
        {
            get { return _UserEmail; }
            set => Set(ref _UserEmail, value);
        }

        /// <summary>
        /// Selected User
        /// </summary>
        public UserModel SelectedUser
        {
            get { return _SelectedUser; }
            set
            {
                _SelectedUser = value;
                NotifyOfPropertyChange(() => SelectedUser);
                SelectedUserRoleKey = SelectedUser.UserRoleKey;
            }
        }

        /// <summary>
        /// Selected User Role Key Init
        /// </summary>
        public int SelectedUserRoleKey
        {
            get { return _SelectedUserRoleKey; }
            set => Set(ref _SelectedUserRoleKey, value);
        }

        /// <summary>
        /// User Role Key Init
        /// </summary>
        public int UserRoleKey
        {
            get { return _UserRoleKey; }
            set => Set(ref _UserRoleKey, value);
        }

        #endregion

        #region User Methods 

        /// <summary>
        /// Show Menu List
        /// </summary>
        public void ShowUsers()
        {
            UserList = db.GetUsers();
        }

        /// <summary>
        /// Adds menu data to database
        /// </summary>
        public void AddUser()
        {
            db.InsertUser(UserFirstName, UserLastName, UserEmail, UserRoleKey);
            ShowUsers();
        }

        /// <summary>
        /// Edit menu data to database
        /// </summary>
        public void EditSelectedUser()
        {
            try
            {
                if (SelectedUser != null)
                    db.EditUser(SelectedUser.UserKey, UserFirstName, UserLastName, UserEmail, UserRoleKey);
                ShowUsers();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Delete selected menu method
        /// </summary>
        public void DeleteSelectedUser()
        {
            if (SelectedUser != null)
                db.DeleteUser(SelectedUser.UserKey);
            ShowUsers();
        }

        /// <summary>
        /// Sets the user type key
        /// </summary>
        /// <param name="type"></param>
        public void UserRoleSelector(string type)
        {
            switch (type)
            {
                case "Operator":
                    UserRoleKey = 1;
                    break;
                case "User":
                    UserRoleKey = 2;
                    break;
            }
        }

        /// <summary>
        /// Fills the User form
        /// </summary>
        /// <param name="source"></param>
        public void FillUserForm(object source)
        {
            if (!(source is UserModel menuModel))
                return;

            UserFirstName = menuModel.FirstName;
            UserLastName = menuModel.LastName;
            UserEmail = menuModel.Email;
        }

        #endregion

        #endregion

        #region USER selected MENUs

        #region Selected Item MenuModel

        private MenuModel _SelectedItemMonday;
        private MenuModel _SelectedItemTuesday;
        private MenuModel _SelectedItemWednesday;
        private MenuModel _SelectedItemThursday;
        private MenuModel _SelectedItemFriday;


        public MenuModel SelectedItemMonday
        {
            get { return _SelectedItemMonday; }
            set => Set(ref _SelectedItemMonday, value);
        }

        public MenuModel SelectedItemTuesday
        {
            get { return _SelectedItemTuesday; }
            set => Set(ref _SelectedItemTuesday, value);
        }

        public MenuModel SelectedItemWednesday
        {
            get { return _SelectedItemWednesday; }
            set => Set(ref _SelectedItemWednesday, value);
        }

        public MenuModel SelectedItemThursday
        {
            get { return _SelectedItemThursday; }
            set => Set(ref _SelectedItemThursday, value);
        }

        public MenuModel SelectedItemFriday
        {
            get { return _SelectedItemFriday; }
            set => Set(ref _SelectedItemFriday, value);
        }

        #endregion

        #region Selected Item DateMenuModel

        private DateMenuModel _SelectedDateMenuItemMonday;
        private DateMenuModel _SelectedDateMenuItemTuesday;
        private DateMenuModel _SelectedDateMenuItemWednesday;
        private DateMenuModel _SelectedDateMenuItemThursday;
        private DateMenuModel _SelectedDateMenuItemFriday;

        public DateMenuModel SelectedDateMenuItemMonday
        {
            get { return _SelectedDateMenuItemMonday; }
            set => Set(ref _SelectedDateMenuItemMonday, value);
        }

        public DateMenuModel SelectedDateMenuItemTuesday
        {
            get { return _SelectedDateMenuItemTuesday; }
            set => Set(ref _SelectedDateMenuItemTuesday, value);
        }

        public DateMenuModel SelectedDateMenuItemWednesday
        {
            get { return _SelectedDateMenuItemWednesday; }
            set => Set(ref _SelectedDateMenuItemWednesday, value);
        }

        public DateMenuModel SelectedDateMenuItemThursday
        {
            get { return _SelectedDateMenuItemThursday; }
            set => Set(ref _SelectedDateMenuItemThursday, value);
        }

        public DateMenuModel SelectedDateMenuItemFriday
        {
            get { return _SelectedDateMenuItemFriday; }
            set => Set(ref _SelectedDateMenuItemFriday, value);
        }

        #endregion

        public void UserSelectMenu(object source, string day)
        {
            if (!(source is MenuModel menuModel))
                return;

            switch (day)
            {
                case "Monday":
                    SelectedItemMonday = menuModel;
                    break;
                case "Tuesday":
                    SelectedItemTuesday = menuModel;
                    break;
                case "Wednesday":
                    SelectedItemWednesday = menuModel;
                    break;
                case "Thursday":
                    SelectedItemThursday = menuModel;
                    break;
                case "Friday":
                    SelectedItemFriday = menuModel;
                    break;
            }

            GetSelectedDateMenu(menuModel, day);
        }

        /// <summary>
        /// Gets selected DateMenu
        /// </summary>
        /// <param name="menuModel"></param>
        /// <param name="day"></param>
        public void GetSelectedDateMenu(MenuModel menuModel, string day)
        {
            switch (day)
            {
                case "Monday":
                    foreach (var item in MondayDateMenu)
                    {
                        if (item.MenuKey == menuModel.MenuKey)
                            SelectedDateMenuItemMonday = item;
                    }
                    break;
                case "Tuesday":
                    foreach (var item in TuesdayDateMenu)
                    {
                        if (item.MenuKey == menuModel.MenuKey)
                            SelectedDateMenuItemTuesday = item;
                    }
                    break;
                case "Wednesday":
                    foreach (var item in WednesdayDateMenu)
                    {
                        if (item.MenuKey == menuModel.MenuKey)
                            SelectedDateMenuItemWednesday = item;
                    }
                    break;
                case "Thursday":
                    foreach (var item in ThursdayDateMenu)
                    {
                        if (item.MenuKey == menuModel.MenuKey)
                            SelectedDateMenuItemThursday = item;
                    }
                    break;
                case "Friday":
                    foreach (var item in FridayDateMenu)
                    {
                        if (item.MenuKey == menuModel.MenuKey)
                            SelectedDateMenuItemFriday = item;
                    }
                    break;
            }
        }

        #endregion

        #region Menu Selection 

        #region Weekly Menu Properties

        private BindableCollection<MenuModel> _MondayMenu = new BindableCollection<MenuModel>();
        private BindableCollection<MenuModel> _TuesdayMenu = new BindableCollection<MenuModel>();
        private BindableCollection<MenuModel> _WednesdayMenu = new BindableCollection<MenuModel>();
        private BindableCollection<MenuModel> _ThursdayMenu = new BindableCollection<MenuModel>();
        private BindableCollection<MenuModel> _FridayMenu = new BindableCollection<MenuModel>();

        public BindableCollection<MenuModel> MondayMenu
        {
            get { return _MondayMenu; }
            set => Set(ref _MondayMenu, value);
        }

        public BindableCollection<MenuModel> TuesdayMenu
        {
            get { return _TuesdayMenu; }
            set => Set(ref _TuesdayMenu, value);
        }

        public BindableCollection<MenuModel> WednesdayMenu
        {
            get { return _WednesdayMenu; }
            set => Set(ref _WednesdayMenu, value);
        }

        public BindableCollection<MenuModel> ThursdayMenu
        {
            get { return _ThursdayMenu; }
            set => Set(ref _ThursdayMenu, value);
        }

        public BindableCollection<MenuModel> FridayMenu
        {
            get { return _FridayMenu; }
            set => Set(ref _FridayMenu, value);
        }

        #endregion

        #region Weekly DateMenu Properties
        private BindableCollection<DateMenuModel> _MondayDateMenu = new BindableCollection<DateMenuModel>();
        private BindableCollection<DateMenuModel> _TuesdayDateMenu = new BindableCollection<DateMenuModel>();
        private BindableCollection<DateMenuModel> _WednesdayDateMenu = new BindableCollection<DateMenuModel>();
        private BindableCollection<DateMenuModel> _ThursdayDateMenu = new BindableCollection<DateMenuModel>();
        private BindableCollection<DateMenuModel> _FridayDateMenu = new BindableCollection<DateMenuModel>();

        public BindableCollection<DateMenuModel> MondayDateMenu
        {
            get { return _MondayDateMenu; }
            set => Set(ref _MondayDateMenu, value);
        }

        public BindableCollection<DateMenuModel> TuesdayDateMenu
        {
            get { return _TuesdayDateMenu; }
            set => Set(ref _TuesdayDateMenu, value);
        }

        public BindableCollection<DateMenuModel> WednesdayDateMenu
        {
            get { return _WednesdayDateMenu; }
            set => Set(ref _WednesdayDateMenu, value);
        }

        public BindableCollection<DateMenuModel> ThursdayDateMenu
        {
            get { return _ThursdayDateMenu; }
            set => Set(ref _ThursdayDateMenu, value);
        }

        public BindableCollection<DateMenuModel> FridayDateMenu
        {
            get { return _FridayDateMenu; }
            set => Set(ref _FridayDateMenu, value);
        }

        #endregion

        /// <summary>
        /// Adds selected menus to corespondend menu list
        /// </summary>
        public void MenuSelector(object source, string day)
        {
            if (!(source is MenuModel menuModel))
                return;

            switch (day)
            {
                case "Monday":
                    //MondayMenu.Add(menuModel);
                    db.InsertDateMenu(MondayDate, menuModel.MenuKey);
                    break;
                case "Tuesday":
                    db.InsertDateMenu(TuesdayDate, menuModel.MenuKey);

                    break;
                case "Wednesday":
                    db.InsertDateMenu(WednesdayDate, menuModel.MenuKey);

                    break;
                case "Thursday":
                    db.InsertDateMenu(ThursdayDate, menuModel.MenuKey);

                    break;
                case "Friday":
                    db.InsertDateMenu(FridayDate, menuModel.MenuKey);
                    break;
            }
            UpdateWeeklyMenuTable();
        }

        /// <summary>
        /// Updates the Weekly Menu table
        /// </summary>
        private void UpdateWeeklyMenuTable()
        {
            ClearLists();

            for (int i = 0; i < CurrentDaysDate.Count(); i++)
            {
                var menuList = db.GetDateMenuByDateReturnMenus(CurrentDaysDate[i]);
                var dateMenuList = db.GetDateMenuByDate(CurrentDaysDate[i]);

                // Loop throughs Menu List 
                foreach (var item in menuList)
                {
                    switch (CurrentDaysDate[i].DayOfWeek.ToString())
                    {
                        case "Monday":
                            MondayMenu.Add(item);
                            break;
                        case "Tuesday":
                            TuesdayMenu.Add(item);
                            break;
                        case "Wednesday":
                            WednesdayMenu.Add(item);
                            break;
                        case "Thursday":
                            ThursdayMenu.Add(item);
                            break;
                        case "Friday":
                            FridayMenu.Add(item);
                            break;
                    }
                }

                // Loop through Date Menu List 
                foreach (var item in dateMenuList)
                {
                    switch (CurrentDaysDate[i].DayOfWeek.ToString())
                    {
                        case "Monday":
                            MondayDateMenu.Add(item);
                            break;
                        case "Tuesday":
                            TuesdayDateMenu.Add(item);
                            break;
                        case "Wednesday":
                            WednesdayDateMenu.Add(item);
                            break;
                        case "Thursday":
                            ThursdayDateMenu.Add(item);
                            break;
                        case "Friday":
                            FridayDateMenu.Add(item);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Clears DateMenu and Menu Lists
        /// </summary>
        private void ClearLists()
        {
            MondayMenu.Clear();
            TuesdayMenu.Clear();
            WednesdayMenu.Clear();
            ThursdayMenu.Clear();
            FridayMenu.Clear();

            MondayDateMenu.Clear();
            TuesdayDateMenu.Clear();
            WednesdayDateMenu.Clear();
            ThursdayDateMenu.Clear();
            FridayDateMenu.Clear();
        }

        /// <summary>
        /// Removes deselected menus from the list 
        /// </summary>
        public void MenuDeselector(object source, string day)
        {
            if (!(source is MenuModel menuModel))
                return;

            switch (day)
            {
                case "Monday":
                    db.DeleteDateMenuByDateAndMenuKey(menuModel.MenuKey, MondayDate);
                    break;
                case "Tuesday":
                    db.DeleteDateMenuByDateAndMenuKey(menuModel.MenuKey, TuesdayDate);
                    break;
                case "Wednesday":
                    db.DeleteDateMenuByDateAndMenuKey(menuModel.MenuKey, WednesdayDate);
                    break;
                case "Thursday":
                    db.DeleteDateMenuByDateAndMenuKey(menuModel.MenuKey, ThursdayDate);
                    break;
                case "Friday":
                    db.DeleteDateMenuByDateAndMenuKey(menuModel.MenuKey, FridayDate);
                    break;
            }

            //db.DeleteDateMenu(menuModel.MenuKey);
            UpdateWeeklyMenuTable();
        }


        #endregion

        #region Orders

        #region Order Properties

        private List<OrderModel> _OrderModelList;
        private DateTime _SelectedDateOrder = DateTime.Today;
        private List<OrderModelJoined> _OrderModelJoinedList;
        private int _ChosenWeek; 
        private int _ChosenMonth;
        private OrderModelJoined _SelectedOrder;
        private string _OrderComment = "";
        private int _NewOrderMenuKey;


        public List<OrderModel> OrderModelList
        {
            get { return _OrderModelList; }
            set => Set(ref _OrderModelList, value);
        }

        public DateTime SelectedDateOrder
        {
            get { return _SelectedDateOrder; }
            set => Set(ref _SelectedDateOrder, value);
        }

        public List<OrderModelJoined> OrderModelJoinedList
        {
            get { return _OrderModelJoinedList; }
            set => Set(ref _OrderModelJoinedList, value);
        }
        public int ChosenWeek
        {
            get { return _ChosenWeek; }
            set => Set(ref _ChosenWeek, value);
        }

        public int ChosenMonth
        {
            get { return _ChosenMonth; }
            set => Set(ref _ChosenMonth, value);
        }

        public OrderModelJoined SelectedOrder
        {
            get { return _SelectedOrder; }
            set => Set(ref _SelectedOrder, value);
        }

        public string OrderComment
        {
            get { return _OrderComment; }
            set => Set(ref _OrderComment, value);
        }

        public int NewOrderMenuKey
        {
            get { return _NewOrderMenuKey; }
            set => Set(ref _NewOrderMenuKey, value);
        }


        #endregion

        /// <summary>
        /// Submit Order
        /// </summary>
        public void SubmitOrder()
        {
            try
            {
                db.InsertOrder(SelectedDateMenuItemMonday.DateMenuKey, SelectedUser.UserKey, 1, "");
                db.InsertOrder(SelectedDateMenuItemTuesday.DateMenuKey, SelectedUser.UserKey, 1, "");
                db.InsertOrder(SelectedDateMenuItemWednesday.DateMenuKey, SelectedUser.UserKey, 1, "");
                db.InsertOrder(SelectedDateMenuItemThursday.DateMenuKey, SelectedUser.UserKey, 1, "");
                db.InsertOrder(SelectedDateMenuItemFriday.DateMenuKey, SelectedUser.UserKey, 1, "");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Searching Orders
        /// </summary>
        public void OrderSearchButton()
        {
            OrderModelList = db.GetOrders();
        }

        /// <summary>
        /// Gets the selected day Orders
        /// </summary>
        public void GetOrdersByDay()
        {
            OrderModelJoinedList =  db.GetOrdersByDay(SelectedDateOrder);
        }

        /// TO-DO Clean this Date mess 
        /// <summary>
        /// Gets the Orders by selected week
        /// </summary>
        public void GetOrdersByWeek()
        {
            if (ChosenWeek < 1 && ChosenWeek > 52)
                return;
            DateTime dt1 = DateHelper.GetDateFromWeekNumberAndDayOfWeek(ChosenWeek, 0);
            DateTime dt2 = dt1.AddDays(6);
            OrderModelJoinedList = db.GetOrdersByTwoDays(dt1, dt2);
        }

        /// <summary>
        /// Gets The ORders by selected month
        /// </summary>
        public void GetOrdersByMonth()
        {
            if (ChosenMonth < 1 || ChosenMonth > 12)
                return;
            var firstDayOfMonth = new DateTime(2020, ChosenMonth, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            DateTime dt1 = firstDayOfMonth;
            DateTime dt2 = lastDayOfMonth;
            OrderModelJoinedList = db.GetOrdersByTwoDays(dt1, dt2);
        }

        /// <summary>
        /// Edits the selected order
        /// </summary>
        public void EditSelectedOrderByKey()
        {
            try
            {
                db.EditOrderByKey(SelectedOrder.OrderKey, NewOrderMenuKey, OrderComment);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        #endregion

        #region Date Methods

        #region Date Properties

        private int _CurrentWeek;
        private DateTime _CurrentDate;
        private DateTime _MondayDate;
        private DateTime _TuesdayDate;
        private DateTime _WednesdayDate;
        private DateTime _ThursdayDate;
        private DateTime _FridayDate;
        private List<DateTime> _CurrentDaysDate = new List<DateTime>();

        public int CurrentWeek
        {
            get { return _CurrentWeek; }
            set => Set(ref _CurrentWeek, value);
        }

        public DateTime CurrentDate
        {
            get { return _CurrentDate; }
            set => Set(ref _CurrentDate, value);
        }

        public DateTime MondayDate
        {
            get { return _MondayDate; }
            set => Set(ref _MondayDate, value);
        }

        public DateTime TuesdayDate
        {
            get { return _TuesdayDate; }
            set => Set(ref _TuesdayDate, value);
        }

        public DateTime WednesdayDate
        {
            get { return _WednesdayDate; }
            set => Set(ref _WednesdayDate, value);
        }

        public DateTime ThursdayDate
        {
            get { return _ThursdayDate; }
            set => Set(ref _ThursdayDate, value);
        }

        public DateTime FridayDate
        {
            get { return _FridayDate; }
            set => Set(ref _FridayDate, value);
        }

        public List<DateTime> CurrentDaysDate
        {
            get { return _CurrentDaysDate; }
            set => Set(ref _CurrentDaysDate, value);
        }

        #endregion

        /// <summary>
        /// Operator Previous Week
        /// </summary>
        public void PreviousWeek()
        {
            CurrentDate = CurrentDate.AddDays(-7);
            DateChanged();
            UpdateWeeklyMenuTable();
        }

        /// <summary>
        /// Operator Next Week
        /// </summary>
        public void NextWeek()
        {
            CurrentDate = CurrentDate.AddDays(7);
            DateChanged();
            UpdateWeeklyMenuTable();
        }

        /// <summary>
        /// Changed Date Method Call
        /// </summary>
        private void DateChanged()
        {
            CurrentWeek = DateHelper.GetChangedWeek(CurrentDate);
            CurrentDaysDate = DateHelper.GetSelectedWeekDays(CurrentDate);
            MondayDate = DateHelper.GetSelectedWeekDays(CurrentDate)[0];
            TuesdayDate = DateHelper.GetSelectedWeekDays(CurrentDate)[1];
            WednesdayDate = DateHelper.GetSelectedWeekDays(CurrentDate)[2];
            ThursdayDate = DateHelper.GetSelectedWeekDays(CurrentDate)[3];
            FridayDate = DateHelper.GetSelectedWeekDays(CurrentDate)[4];
        }

        #endregion



    }
}
