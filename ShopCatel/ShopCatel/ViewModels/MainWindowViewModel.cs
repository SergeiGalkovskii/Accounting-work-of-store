namespace ShopCatel.ViewModels
{
    using Catel.Data;
    using System.Collections.ObjectModel;
    using Catel.MVVM;
    using System.Linq;
    using Models;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System;
    using Catel.Services;
    using System.Threading;
 
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiiVisualizerService;
        private readonly IPleaseWaitService _pleaseWaitService;

        public MainWindowViewModel(IUIVisualizerService uiiVisualizerService, IPleaseWaitService pleaseWaitService)
        {
            _uiiVisualizerService = uiiVisualizerService;
            _pleaseWaitService = pleaseWaitService;

            ComboIdProd = new List<int>();
            ComboIdBuyer = new List<int>();
            using (ShopModel db = new ShopModel())
            {
                db.tProducts.Load();
                ProductCollection = db.tProducts.Local;
                var listIdProd = db.tProducts.Select(p => new { ID_Product = p.ID_Product });
                var listIdBuyer = db.tBuyers.Select(p => new { ID_Buyer = p.ID_Buyer });


                foreach (var a in listIdProd)
                {
                    ComboIdProd.Add(a.ID_Product);
                }

                foreach (var a in listIdBuyer)
                {
                    ComboIdBuyer.Add(a.ID_Buyer);
                }
            }
        }

        public MainWindowViewModel()
        {
        }

        public override string Title { get { return "ShopCatel"; } }


        public int SelectedIdProd
        {
            get { return GetValue<int>(SelectedIdProdProperty); }
            set { SetValue(SelectedIdProdProperty, value); }
        }
        public static readonly PropertyData SelectedIdProdProperty = RegisterProperty("SelectedIdProd", typeof(int), null);

        public int SelectedIdBuyer
        {
            get { return GetValue<int>(SelectedIdBuyerProperty); }
            set { SetValue(SelectedIdBuyerProperty, value); }
        }
        public static readonly PropertyData SelectedIdBuyerProperty = RegisterProperty("SelectedIdBuyer", typeof(int), null);

        public List<int> ComboIdProd
        {
            get { return GetValue<List<int>>(ComboIdProdProperty); }
            set { SetValue(ComboIdProdProperty, value); }
        }
        public static readonly PropertyData ComboIdProdProperty = RegisterProperty("ComboId", typeof(List<int>), null);

        public List<int> ComboIdBuyer
        {
            get { return GetValue<List<int>>(ComboIdBuyerProperty); }
            set { SetValue(ComboIdBuyerProperty, value); }
        }
        public static readonly PropertyData ComboIdBuyerProperty = RegisterProperty("ComboIdBuyer", typeof(List<int>), null);

        public ObservableCollection<tProduct> ProductCollection
        {
            get { return GetValue<ObservableCollection<tProduct>>(ProductCollectionProperty); }
            set { SetValue(ProductCollectionProperty, value); }
        }
        public static readonly PropertyData ProductCollectionProperty = RegisterProperty("ProductCollection", typeof(ObservableCollection<tProduct>), null);

        [Model]
        public MainWindow MainWindowObject
        {
            get { return GetValue<MainWindow>(MainWindowObjectProperty); }
            set { SetValue(MainWindowObjectProperty, value); }
        }
        public static readonly PropertyData MainWindowObjectProperty = RegisterProperty("MainWindowObject", typeof(MainWindow), null);
      

        [ViewModelToModel("MainWindowObject", "Count")]
        public int MainWindowCount
        {
            get { return GetValue<int>(MainWindowCountProperty); }
            set { SetValue(MainWindowCountProperty, value); }
        }
        public static readonly PropertyData MainWindowCountProperty = RegisterProperty("MainWindowCount", typeof(int), null);

        [ViewModelToModel("MainWindowObject", "Price")]
        public double MainWindowPrice
        {
            get { return GetValue<double>(MainWindowPriceProperty); }
            set { SetValue(MainWindowPriceProperty, value); }
        }
        public static readonly PropertyData MainWindowPriceProperty = RegisterProperty("MainWindowPrice", typeof(double), null);

        public void AddData()
        {
            using (ShopModel db = new ShopModel())
            {
                tSold_prod sold = new tSold_prod();
                sold.ID_Product = SelectedIdProd;
                sold.Count_of_prod = MainWindowCount;
                sold.Sold_date = DateTime.Now;
                sold.ID_Co_worker = 1;
                sold.ID_Buyer = SelectedIdBuyer;
                var a = (from t in db.tProducts where t.ID_Product == SelectedIdProd select t);
                double S = 1;
                foreach (var aa in a)
                {
                    S = aa.Price_of_product * MainWindowCount;
                }
                sold.Total_price = S;
                db.tSold_prod.Add(sold);
                db.SaveChanges();
            }

        }

        private Command _checkout;
        public Command Checkout
        {
            get
            {
                return _checkout ?? (_checkout = new Command(() =>
                {
                    AddData();
                    _pleaseWaitService.Show("Оформление покупки...");
                    Thread.Sleep(2000);
                    SelectedIdProd = 0;
                    MainWindowCount = 0;
                    SelectedIdBuyer = 0;
                    _pleaseWaitService.Hide();

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

        private Command _AddWin;
        public Command AddWin
        {
            get
            {
                return _AddWin ?? (_AddWin = new Command(() =>
                {
                    var viewModel = new AddBuyerWindowViewModel();
                    _uiiVisualizerService.Show(viewModel);

                }));
            }
        }
    }
}

