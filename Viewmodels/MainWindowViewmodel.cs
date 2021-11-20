using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFbase;
using ProjectCafe;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ProjectCafe.Viewmodels;
using Microsoft.Win32;
using System.Drawing;
using System.IO;

namespace ProjectCafe.Viewmodels
{
    public static class BF
    {
        public static string BasicFolder => new DirectoryInfo(".").Parent.Parent.FullName + "\\";
        public static string ImageResources => BasicFolder + "ImageResources\\";
    }
    public  class NewItem
    {
        public ChangingItem<string> Name { get; set; } = new ChangingItem<string>();
        public ChangingItem<int> Cost { get; set; } = new ChangingItem<int>();
        public ChangingItem<BitmapImage> Image { get; set; } = new ChangingItem<BitmapImage>();
        public NewItem()
        {
            Image.Item = new BitmapImage(new Uri(BF.ImageResources + "default.jpg"));
            Name.Item = "";
        }
    }
    public class Order
    {
        public List<BoughtProduct> Products { get; set; } = new List<BoughtProduct>();
        public DateTime DT { get; set; }
        public string DateString => DT.ToString("dd.MM.yyyy HH:mm:ss");
        public string GetProductsString 
        { 
            get
            {
                string s="";
                foreach (var item in Products)
                {
                    s += item.name + " x" + item.count.Item.ToString() + " - " + (item.Cost * item.count.Item).ToString() + " грн\n";
                }
                return s;
            }
        }
    }
    public class MainWindowViewmodel : OnPropertyChangedHandler
    {
        
        public static ObservableCollection<ProductCard> AvailableCToBuyProducts { get; set; } = new ObservableCollection<ProductCard>();
        public static ObservableCollection<ProductBoughtCard> OrderedProducts { get; set; } = new ObservableCollection<ProductBoughtCard>();
        public static ChangingItem<int> TotalCost { get; set; } = new ChangingItem<int>();
        public NewItem NewItem { get; set; } = new NewItem();
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        public MainWindowViewmodel()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    name = "Кофе",
                    Cost = 30,
                    image = new BitmapImage(new Uri(BF.ImageResources+ "coffee.jpg")),
                    //count = new ChangingItem<string>("20")
                },
                new Product()
                {
                    name = "Мороженное",
                    Cost = 28,
                    image=new BitmapImage(new Uri(BF.ImageResources+"icecream.png")),
                    //count = new ChangingItem<string>("20")
                }
            };
            foreach (Product item in products)
            {
                var card = new ProductCard(item);
                card.vm.IsAvailable = true;
                AvailableCToBuyProducts.Add(card);
                var card1 = new ProductCard(item);
                card1.vm.IsAvailable = false;
                Products.Add(card1);
            }

        }
        public ICommand ChooseImage => new RelayCommand(o =>
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image file(*.png;*.jpg)|*.png;*.jpg";
            if (fd.ShowDialog()==true)
            {
                FileInfo f = new FileInfo(fd.FileName);
                string newf = BF.ImageResources + new FileInfo(fd.FileName).Name;
                if (File.Exists(newf))
                {
                   newf= newf.Replace(f.Extension, " copy" + f.Extension);
                }
                File.Copy(fd.FileName, newf);
                NewItem.Image.Item = new BitmapImage(new Uri(fd.FileName));
            }
            
        }, o => true);
        public ICommand Add => new RelayCommand(o =>
        {
            var prod = new Product()
            {
                Cost=NewItem.Cost.Item,
                name= NewItem.Name.Item,
                image = NewItem.Image.Item
            };
            var card = new ProductCard(prod);
            card.vm.IsAvailable = true;
            AvailableCToBuyProducts.Add(card);
            card = new ProductCard(prod);
            card.vm.IsAvailable = false;
            Products.Add(card);
        }, o=>NewItem.Name.Item!="");
        public ObservableCollection<ProductCard> Products { get; set; } = new ObservableCollection<ProductCard>();
        public ICommand Buy => new RelayCommand(o =>
        {
            Orders.Add(new Order()
            {
                Products = OrderedProducts.ToList().ConvertAll(p => p.Product).Distinct().ToList(),
                DT = DateTime.Now
            });
            OrderedProducts.Clear();
            TotalCost.Item = 0;
        }, o => OrderedProducts.Count > 0);
        public ICommand Clear => new RelayCommand(o =>
        {
            OrderedProducts.Clear();
            TotalCost.Item = 0;
        }, o => OrderedProducts.Count > 0);
    }
}