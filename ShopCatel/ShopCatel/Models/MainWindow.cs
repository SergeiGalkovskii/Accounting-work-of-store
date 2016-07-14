using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCatel.Models
{
    public class MainWindow:ModelBase
    {

        public int Count
        {
            get { return GetValue<int>(CountProperty); }
            set { SetValue(CountProperty, value); }
        }
        public static readonly PropertyData CountProperty = RegisterProperty("Count", typeof(int), null);

        public double Price
        {
            get { return GetValue<double>(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
        public static readonly PropertyData PriceProperty = RegisterProperty("Price", typeof(double), null);
    
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if(Count<1)
            {
                validationResults.Add(FieldValidationResult.CreateError(CountProperty, "Необходимо, чтобы кол-во было больше 1"));
            }
        }
    }
}
