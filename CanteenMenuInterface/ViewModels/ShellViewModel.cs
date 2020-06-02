using Caliburn.Micro;
using CanteenMenuInterface.Helpers;
using CanteenMenuInterface.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenMenuInterface.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            ShowMenus();
            ShowUsers();
            FillTheList();

            CurrentDate = DateTime.Today;
            CurrentWeek = DateHelper.GetCurrentWeek();
            CurrentDaysDate = DateHelper.GetThisWeekDays();
            MondayDate = DateHelper.GetThisWeekDays()[0];
            TuesdayDate = DateHelper.GetThisWeekDays()[1];
            WednesdayDate = DateHelper.GetThisWeekDays()[2];
            ThursdayDate = DateHelper.GetThisWeekDays()[3];
            FridayDate = DateHelper.GetThisWeekDays()[4];

            UpdateWeeklyMenuTable();

        }

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
            set => Set(ref _SelectedUser, value);
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
            db.InsertUser(UserFirstName, UserLastName, UserEmail);
            ShowUsers();
        }

        /// <summary>
        /// Edit menu data to database
        /// </summary>
        public void EditSelectedUser()
        {
            if(SelectedUser != null)
                db.EditUser(SelectedUser.UserKey , UserFirstName, UserLastName, UserEmail);
            ShowUsers();
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

        #endregion

        #endregion

        #region Menu Selection 

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
                    TuesdayMenu.Add(menuModel);
                    db.InsertDateMenu(TuesdayDate, menuModel.MenuKey);

                    break;
                case "Wednesday":
                    WednesdayMenu.Add(menuModel);
                    db.InsertDateMenu(WednesdayDate, menuModel.MenuKey);

                    break;
                case "Thursday":
                    ThursdayMenu.Add(menuModel);
                    db.InsertDateMenu(ThursdayDate, menuModel.MenuKey);

                    break;
                case "Friday":
                    FridayMenu.Add(menuModel);
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
            MondayMenu.Clear();
            TuesdayMenu.Clear();
            WednesdayMenu.Clear();
            ThursdayMenu.Clear();
            FridayMenu.Clear();
            for (int i = 0; i < CurrentDaysDate.Count(); i++)
            {
                var menuList = db.GetDateMenuByDate(CurrentDaysDate[i]);
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
            }
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
                    MondayMenu.Remove(menuModel);
                    db.DeleteDateMenuByDateAndMenuKey(menuModel.MenuKey, MondayDate);
                    break;
                case "Tuesday":
                    TuesdayMenu.Remove(menuModel);
                    db.DeleteDateMenuByDateAndMenuKey(menuModel.MenuKey, TuesdayDate);
                    break;
                case "Wednesday":
                    WednesdayMenu.Remove(menuModel);
                    db.DeleteDateMenuByDateAndMenuKey(menuModel.MenuKey, WednesdayDate);
                    break;
                case "Thursday":
                    ThursdayMenu.Remove(menuModel);
                    db.DeleteDateMenuByDateAndMenuKey(menuModel.MenuKey, ThursdayDate);
                    break;
                case "Friday":
                    FridayMenu.Remove(menuModel);
                    db.DeleteDateMenuByDateAndMenuKey(menuModel.MenuKey, FridayDate);
                    break;
            }

            //db.DeleteDateMenu(menuModel.MenuKey);
            UpdateWeeklyMenuTable();
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
            ChangedDate();
            UpdateWeeklyMenuTable();
        }

        /// <summary>
        /// Operator Next Week
        /// </summary>
        public void NextWeek()
        {
            CurrentDate = CurrentDate.AddDays(7);
            ChangedDate();
            UpdateWeeklyMenuTable();
        }

        /// <summary>
        /// Changed Date Method Call
        /// </summary>
        private void ChangedDate()
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
