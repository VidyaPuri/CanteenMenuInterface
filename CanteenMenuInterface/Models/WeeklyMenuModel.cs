using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenMenuInterface.Models
{
    public class WeeklyMenuModel
    {
        public BindableCollection<MenuModel> MondayList { get; set; } = new BindableCollection<MenuModel>();
        public BindableCollection<MenuModel> TusedayList { get; set; } = new BindableCollection<MenuModel>();
        public BindableCollection<MenuModel> WednesdayList { get; set; } = new BindableCollection<MenuModel>();
        public BindableCollection<MenuModel> ThursdayList { get; set; } = new BindableCollection<MenuModel>();
        public BindableCollection<MenuModel> FridayList { get; set; } = new BindableCollection<MenuModel>();
    }
}
