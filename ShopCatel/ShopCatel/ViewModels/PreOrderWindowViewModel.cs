using Catel.Data;
using Catel.MVVM;
using Catel.Services;
using ShopCatel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopCatel.ViewModels
{
    public class PreOrderWindowViewModel:ViewModelBase
    {
        private readonly IUIVisualizerService _uiiVisualizerService;
        private readonly IPleaseWaitService _pleaseWaitService;

        public PreOrderWindowViewModel(IUIVisualizerService uiiVisualizerService, IPleaseWaitService pleaseWaitService)
        {
            _uiiVisualizerService = uiiVisualizerService;
            _pleaseWaitService = pleaseWaitService;

            ComboIdProd = new List<int>();
            ComboIdBuyer = new List<int>();
            ComboState = new List<string>();
            using (ShopModel db = new ShopModel())
            {
                db.tPre_orders.Load();
                ProductCollection = db.tProducts.Local;
                PreOrders = db.tPre_orders.Local;

                var listIdProd = db.tProducts.Select(p => new { ID_Product = p.ID_Product });
                var listIdBuyer = db.tBuyers.Select(p => new { ID_Buyer = p.ID_Buyer });
                var listState = db.tPre_orders.Select(p => new { State = p.State });

                foreach (var a in listIdProd)
                {
                    ComboIdProd.Add(a.ID_Product);
                }

                foreach (var a in listIdBuyer)
                {
                    ComboIdBuyer.Add(a.ID_Buyer);
                }

                foreach (var a in listState)
                {
                    ComboState.Add(a.State);
                }
            }
        }

        public PreOrderWindowViewModel()
        {
        }

        public override string Title { get { return "ShopCatel"; } }

        [Model]
        public PreOrderWindow PreOrderWindowObject
        {
            get { return GetValue<PreOrderWindow>(PreOrderWindowObjectProperty); }
            set { SetValue(PreOrderWindowObjectProperty, value); }
        }
        public static readonly PropertyData PreOrderWindowObjectProperty = RegisterProperty("PreOrderWindowObject", typeof(PreOrderWindow), null);

        [ViewModelToModel("PreOrderWindowObject", "Count")]
        public int PreOrderWindowCount
        {
            get { return GetValue<int>(PreOrderWindowCountProperty); }
            set { SetValue(PreOrderWindowCountProperty, value); }
        }
        public static readonly PropertyData PreOrderWindowCountProperty = RegisterProperty("PreOrderWindowCount", typeof(int), null);

        [ViewModelToModel("PreOrderWindowObject", "PrePay")]
        public double PreOrderWindowPrePay
        {
            get { return GetValue<double>(PreOrderWindowPrePayProperty); }
            set { SetValue(PreOrderWindowPrePayProperty, value); }
        }
        public static readonly PropertyData PreOrderWindowPrePayProperty = RegisterProperty("PreOrderWindowPrePay", typeof(double), null);

        [ViewModelToModel("PreOrderWindowObject", "Note")]
        public string PreOrderWindowNote
        {
            get { return GetValue<string>(PreOrderWindowNoteProperty); }
            set { SetValue(PreOrderWindowNoteProperty, value); }
        }
        public static readonly PropertyData PreOrderWindowNoteProperty = RegisterProperty("PreOrderWindowNote", typeof(string), null);

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

        public List<string> ComboState
        {
            get { return GetValue<List<string>>(ComboStateProperty); }
            set { SetValue(ComboStateProperty, value); }
        }
        public static readonly PropertyData ComboStateProperty = RegisterProperty("ComboState", typeof(List<string>), null);

        public string SelectedState
        {
            get { return GetValue<string>(SelectedStateProperty); }
            set { SetValue(SelectedStateProperty, value); }
        }
        public static readonly PropertyData SelectedStateProperty = RegisterProperty("SelectedState", typeof(string), null);


        public ObservableCollection<tProduct> ProductCollection
        {
            get { return GetValue<ObservableCollection<tProduct>>(ProductCollectionProperty); }
            set { SetValue(ProductCollectionProperty, value); }
        }
        public static readonly PropertyData ProductCollectionProperty = RegisterProperty("ProductCollection", typeof(ObservableCollection<tProduct>), null);


        public ObservableCollection<tPre_orders> PreOrders
        {
            get { return GetValue<ObservableCollection<tPre_orders>>(PreOrdersProperty); }
            set { SetValue(PreOrdersProperty, value); }
        }
        public static readonly PropertyData PreOrdersProperty = RegisterProperty("PreOrders", typeof(ObservableCollection<tPre_orders>), null);

        public void AddData()
        {
            using (ShopModel db = new ShopModel())
            {
                tPre_orders preord = new tPre_orders();
                preord.ID_Product = SelectedIdProd;
                preord.ID_Buyer = SelectedIdBuyer;
                preord.Count_of_pre_order = PreOrderWindowCount;
                var a = (from t in db.tProducts where t.ID_Product == SelectedIdProd select t);
                double S = 1;
                foreach (var aa in a)
                {
                    S = aa.Price_of_product * PreOrderWindowCount;
                }
                preord.Total_price = S;
                preord.Paid = PreOrderWindowPrePay;
                preord.Pre_date = DateTime.Now;
                preord.State = SelectedState;
                preord.Note = PreOrderWindowNote;
                db.tPre_orders.Add(preord);
                db.SaveChanges();
            }
        }
        private Command _confirm;
        public Command Confirm
        {
            get
            {
                return _confirm ?? (_confirm = new Command(() =>
                {
                     AddData();
                    _pleaseWaitService.Show("Оформление предзаказа...");
                    Thread.Sleep(2000);
                    SelectedIdProd = 0;
                    SelectedIdBuyer = 0;
                    PreOrderWindowCount = 0;
                    PreOrderWindowPrePay = 0;
                    SelectedState = " ";
                    PreOrderWindowNote = " ";
                    _pleaseWaitService.Hide();
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
