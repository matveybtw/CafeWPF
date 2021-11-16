using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFbase;
using ProjectCafe;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace ProjectCafe.Viewmodels
{

    public class MainWindowViewmodel
    {
        public static ObservableCollection<ProductCard> AvailableCToBuyProducts { get; set; } = new ObservableCollection<ProductCard>();
        public static ObservableCollection<ProductBoughtCard> OrderedProducts { get; set; } = new ObservableCollection<ProductBoughtCard>();

        public MainWindowViewmodel()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    name = "Кофе",
                    cost = "30 грн",
                    image = new BitmapImage(new Uri("ImageResources/coffee.jpg", UriKind.Relative)),
                    //count = new ChangingItem<string>("20")
                },
                new Product()
                {
                    name = "Мороженное",
                    cost = "28 грн",
                    image=new BitmapImage(new Uri("ImageResources/icecream.png", UriKind.Relative)),
                    //count = new ChangingItem<string>("20")
                }
            };
            foreach (Product item in products)
            {
                AvailableCToBuyProducts.Add(new ProductCard(item));
            }
        }
    }
}
