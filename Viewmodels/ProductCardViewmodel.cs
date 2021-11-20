using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WPFbase;
using ProjectCafe.Viewmodels;
using System.Text.RegularExpressions;

namespace ProjectCafe.Viewmodels
{
    public class ProductCardViewmodel : OnPropertyChangedHandler
    {
        public bool IsAvailable { get; set; } = true;
        public Product Product { get; set; }
        public ProductCardViewmodel(Product product)
        {
            Product = product;
        }
        public ICommand Command => new RelayCommand(o =>
        {
            if (!Exists)
            {
                MainWindowViewmodel.OrderedProducts.Add(new ProductBoughtCard(new BoughtProduct()
                {
                    image=Product.image,
                    name = Product.name,
                    Cost = Product.Cost,
                    count = new ChangingItem<int>(1)
                }));
                UpdateTotalCost();
            }
            else
            {
                MainWindowViewmodel.OrderedProducts[IndexOfSelected].Product.count.Item += 1;
                UpdateTotalCost();
            }

        }, o => IsAvailable);
        void UpdateTotalCost()
        {
            int count = 0;
            foreach (var item in MainWindowViewmodel.OrderedProducts)
            {
                count += item.Product.Cost * item.Product.count.Item;
            }
            MainWindowViewmodel.TotalCost.Item = count;
        }
        bool Exists
        {
            get
            {
                foreach (var item in MainWindowViewmodel.OrderedProducts)
                {
                    if (item.Product.name == Product.name)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        int IndexOfSelected
        {
            get
            {
                int i = 0;
                foreach (var item in MainWindowViewmodel.OrderedProducts)
                {
                    if (item.Product.name==Product.name)
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
