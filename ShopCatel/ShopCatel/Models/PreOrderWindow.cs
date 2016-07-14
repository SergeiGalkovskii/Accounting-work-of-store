using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCatel.Models
{
    public class PreOrderWindow:ModelBase
    {
        public int Count
        {
            get { return GetValue<int>(CountProperty); }
            set { SetValue(CountProperty, value); }
        }
        public static readonly PropertyData CountProperty = RegisterProperty("Count", typeof(int), null);

        public double PrePay
        {
            get { return GetValue<double>(PrePayProperty); }
            set { SetValue(PrePayProperty, value); }
        }
        public static readonly PropertyData PrePayProperty = RegisterProperty("PrePay", typeof(double), null);

        public string Note
        {
            get { return GetValue<string>(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }
        public static readonly PropertyData NoteProperty = RegisterProperty("Note", typeof(string), null);
    }
}
