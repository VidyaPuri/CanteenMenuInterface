using Caliburn.Micro;
using CanteenMenuInterface.Models;
using System;
using System.Collections.Generic;
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

        private WeeklyMenuModel _WeeklyMenu = new WeeklyMenuModel();

        public WeeklyMenuModel WeeklyMenu
        {
            get { return _WeeklyMenu; }
            set => Set(ref _WeeklyMenu, value);

        }

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
                    WeeklyMenu.MondayList.Add(menuModel);
                    MondayMenu.Add(menuModel);
                    break;
                case "Tuesday":
                    WeeklyMenu.TusedayList.Add(menuModel);
                    TuesdayMenu.Add(menuModel);
                    break;
                case "Wednesday":
                    WeeklyMenu.WednesdayList.Add(menuModel);
                    WednesdayMenu.Add(menuModel);
                    break;
                case "Thursday":
                    WeeklyMenu.ThursdayList.Add(menuModel);
                    ThursdayMenu.Add(menuModel);
                    break;
                case "Friday":
                    WeeklyMenu.FridayList.Add(menuModel);
                    FridayMenu.Add(menuModel);
                    break;
            }
            WeeklyMenu.MondayList.Refresh();
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
                    WeeklyMenu.MondayList.Remove(menuModel);
                    MondayMenu.Remove(menuModel);
                    break;
                case "Tuesday":
                    WeeklyMenu.TusedayList.Remove(menuModel);
                    TuesdayMenu.Remove(menuModel);
                    break;
                case "Wednesday":
                    WeeklyMenu.WednesdayList.Remove(menuModel);
                    WednesdayMenu.Remove(menuModel);
                    break;
                case "Thursday":
                    WeeklyMenu.ThursdayList.Remove(menuModel);
                    ThursdayMenu.Remove(menuModel);
                    break;
                case "Friday":
                    WeeklyMenu.FridayList.Remove(menuModel);
                    FridayMenu.Remove(menuModel);
                    break;
            }
         }

        #endregion
    }
}
