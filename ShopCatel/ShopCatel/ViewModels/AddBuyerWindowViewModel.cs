using Catel.Data;
using Catel.MVVM;
using Catel.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopCatel.ViewModels
{
    class AddBuyerWindowViewModel:ViewModelBase
    {
        private readonly IUIVisualizerService _uiiVisualizerService;
        private readonly IPleaseWaitService _pleaseWaitService;

        public AddBuyerWindowViewModel(IUIVisualizerService uiiVisualizerService, IPleaseWaitService pleaseWaitService)
        {
            _uiiVisualizerService = uiiVisualizerService;
            _pleaseWaitService = pleaseWaitService;
        }
        public AddBuyerWindowViewModel()
        {

        }

        public tPeople tPeopleObject
        {
            get { return GetValue<tPeople>(tPeopleObjectProperty); }
            set { SetValue(tPeopleObjectProperty, value); }
        }  
        public static readonly PropertyData tPeopleObjectProperty = RegisterProperty("tPeopleObject", typeof(tPeople), null);

        public string AddFirst_name
        {
            get { return GetValue<string>(AddFirst_nameProperty); }
            set { SetValue(AddFirst_nameProperty, value); }
        }
        public static readonly PropertyData AddFirst_nameProperty = RegisterProperty("AddFirst_name", typeof(string), null);

        public string AddSecond_name
        {
            get { return GetValue<string>(AddSecond_nameProperty); }
            set { SetValue(AddSecond_nameProperty, value); }
        }
        public static readonly PropertyData AddSecond_nameProperty = RegisterProperty("AddSecond_name", typeof(string), null);

        public string AddMiddle_name
        {
            get { return GetValue<string>(AddMiddle_nameProperty); }
            set { SetValue(AddMiddle_nameProperty, value); }
        }
        public static readonly PropertyData AddMiddle_nameProperty = RegisterProperty("AddMiddle_name", typeof(string), null);

        public DateTime AddDate_of_birthday
        {
            get { return GetValue<DateTime>(AddDate_of_birthdayProperty); }
            set { SetValue(AddDate_of_birthdayProperty, value); }
        }
        public static readonly PropertyData AddDate_of_birthdayProperty = RegisterProperty("AddDate_of_birthday", typeof(DateTime), null);

        public string AddSerias_passport
        {
            get { return GetValue<string>(AddSerias_passportProperty); }
            set { SetValue(AddSerias_passportProperty, value); }
        }
        public static readonly PropertyData AddSerias_passportProperty = RegisterProperty("AddSerias_passport", typeof(string), null);

        public int AddID_number
        {
            get { return GetValue<int>(AddID_numberProperty); }
            set { SetValue(AddID_numberProperty, value); }
        }
        public static readonly PropertyData AddID_numberProperty = RegisterProperty("AddID_number", typeof(int), null);

        public short AddIndex_city
        {
            get { return GetValue<short>(AddIndex_cityProperty); }
            set { SetValue(AddIndex_cityProperty, value); }
        }
        public static readonly PropertyData AddIndex_cityProperty = RegisterProperty("AddIndex_city", typeof(short), null);

        public string AddCity
        {
            get { return GetValue<string>(AddCityProperty); }
            set { SetValue(AddCityProperty, value); }
        }     
        public static readonly PropertyData AddCityProperty = RegisterProperty("AddCity", typeof(string), null);

        public string AddStreet
        {
            get { return GetValue<string>(AddStreetProperty); }
            set { SetValue(AddStreetProperty, value); }
        }
        public static readonly PropertyData AddStreetProperty = RegisterProperty("AddStreet", typeof(string), null);

        public string AddHome
        {
            get { return GetValue<string>(AddHomeProperty); }
            set { SetValue(AddHomeProperty, value); }
        }
        public static readonly PropertyData AddHomeProperty = RegisterProperty("AddHome", typeof(string), null);

        public int AddPhone_number
        {
            get { return GetValue<int>(AddPhone_numberProperty); }
            set { SetValue(AddPhone_numberProperty, value); }
        }
        public static readonly PropertyData AddPhone_numberProperty = RegisterProperty("AddPhone_number", typeof(int), null);

        public string AddEmail
        {
            get { return GetValue<string>(AddEmailProperty); }
            set { SetValue(AddEmailProperty, value); }
        }
        public static readonly PropertyData AddEmailProperty = RegisterProperty("AddEmail", typeof(string), null);

        void AddData()
        {
            using (ShopModel db = new ShopModel())
            {
                tPeople pl = new tPeople();
                pl.First_name = AddFirst_name;
                pl.Second_name = AddSecond_name;
                pl.Middle_name = AddMiddle_name;
                pl.Date_of_birthday = AddDate_of_birthday;
                pl.Serias_passport = AddSerias_passport;
                pl.ID_number = AddID_number;
                pl.Index_city = AddIndex_city;
                pl.City = AddCity;
                pl.Street = AddStreet;
                pl.Home = AddHome;
                pl.Phone_number = AddPhone_number;
                pl.Email = AddEmail;
                db.tPeoples.Add(pl);
                db.SaveChanges();                
            }

            using (ShopModel sm = new ShopModel())
            {
                var id = (from t in sm.tPeoples where t.Serias_passport == AddSerias_passport select t.ID_Human).First();
                tBuyer nb = new tBuyer();
                nb.ID_Human = id;
                sm.tBuyers.Add(nb);
                sm.SaveChanges();
            }

        }

        private Command _add;
        public Command Add
        {
            get
            {
                return _add ?? (_add = new Command(() =>
                {
                    AddData();
                    AddFirst_name = " ";
                    AddSecond_name = " ";
                    AddMiddle_name = " ";
                    AddSerias_passport = " ";
                    AddID_number = 0;
                    AddIndex_city = 0;
                    AddCity = " ";
                    AddStreet = " ";
                    AddHome = " ";
                    AddPhone_number = 0;
                    AddEmail = " ";
                }));
            }
        }

        private Command _PreOrderWin;
        public Command PreOrderWin
        {
            get
            {
                return _PreOrderWin ?? (_PreOrderWin = new Command(() =>
                {
                    var viewModel = new PreOrderWindowViewModel();
                    _uiiVisualizerService.Show(viewModel);

                }));
            }
        }

        private Command _MainWin;
        public Command MainWin
        {
            get
            {
                return _MainWin ?? (_MainWin = new Command(() =>
                {
                    var viewModel = new MainWindowViewModel();
                    _uiiVisualizerService.Show(viewModel);

                }));
            }
        }

    }
}
