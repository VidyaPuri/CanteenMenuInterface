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
           

        }

        #region Private Members
        DataAccess db = new DataAccess();
        private string _MenuNameInput;
        private string _MenuDescriptionInput;
        private List<MenuModel> _MenuList;

        #endregion

        #region Property Initialisations

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


        #endregion

        #region Methods 

        /// <summary>
        /// Adds menu data to database
        /// </summary>
        public void AddMenuToDB()
        {
            db.InsertMenu(MenuNameInput, MenuDescriptionInput);
        }

        public void ShowMenus()
        {

            MenuList = db.GetMenus();
        }

        #endregion

    }
}
