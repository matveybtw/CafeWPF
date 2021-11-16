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
    public class ProductCardViewmodel:OnPropertyChangedHandler
    {
        public Product Product { get; set; }
        public ProductCardViewmodel(Product product)
        {
            Product = product;
        }
        //public ICommand Butt => new RelayCommand(o =>
        //{
        //    Product.count.Item = (int.Parse(Product.count.Item) - 1).ToString();
        //    Predicate<ProductCard> pred = new Predicate<ProductCard>(o => o.product.name == Product.name);
        //    if (!MainWindowViewmodel.OrderedProducts.Contains(new ProductCard(new Product() { name = Product.name }))&& MainWindowViewmodel.AvailableCToBuyProducts.Contains(new ProductCard(new Product() { name = Product.name })))
        //    {
        //        MainWindowViewmodel.OrderedProducts.Add(MainWindowViewmodel.AvailableCToBuyProducts[MainWindowViewmodel.AvailableCToBuyProducts.IndexOf(new ProductCard(new Product() { name = Product.name }))]);
        //        MainWindowViewmodel.OrderedProducts.Last().product.count.Item = "1";
        //    }
        //    else
        //    {
        //        int i = MainWindowViewmodel.OrderedProducts.IndexOf(new ProductCard(new Product() { name = Product.name }));
        //        var p = MainWindowViewmodel.OrderedProducts[i].product;
        //        MainWindowViewmodel.OrderedProducts[i].product.count.Item = (int.Parse(p.count.Item) + 1).ToString();
        //    }
        //    OnPropertyChanged(nameof(MainWindowViewmodel.OrderedProducts));
        //    OnPropertyChanged(nameof(MainWindowViewmodel.AvailableCToBuyProducts));
        //}, o => true);
    }
}
