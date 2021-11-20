using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFbase;
using ProjectCafe.Viewmodels;
using System.Windows.Input;

namespace ProjectCafe.Viewmodels
{
    namespace ProjectCafe.Viewmodels
    {
        public class BoughtProductViewmodel : OnPropertyChangedHandler
        {
            public BoughtProduct Product { get; set; }
            public BoughtProductViewmodel(BoughtProduct product)
            {
                Product = product;
            }
            public ICommand Command => new RelayCommand(o =>
            {
                if (MainWindowViewmodel.OrderedProducts[IndexOfSelected].Product.count.Item == 1)
                {
                    MainWindowViewmodel.OrderedProducts.Remove(MainWindowViewmodel.OrderedProducts[IndexOfSelected]);
                    UpdateTotalCost();
                }
                else
                {
                    MainWindowViewmodel.OrderedProducts[IndexOfSelected].Product.count.Item -= 1;
                    UpdateTotalCost();
                    
                }
            }, o => true);
            void UpdateTotalCost()
            {
                int count = 0;
                foreach (var item in MainWindowViewmodel.OrderedProducts)
                {
                    count += item.Product.Cost * item.Product.count.Item;
                }
                MainWindowViewmodel.TotalCost.Item = count;

            }
            int IndexOfSelected
            {
                get
                {
                    int i = 0;
                    foreach (var item in MainWindowViewmodel.OrderedProducts)
                    {
                        if (item.Product.name == Product.name)
                        {
                            return i;
                        }
                        i++;
                    }
                    return -1;
                }
            }
        }
    }
}
