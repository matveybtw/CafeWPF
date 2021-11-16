using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFbase;

namespace ProjectCafe
{
    public class Product
    {
        //public ChangingItem<string> name { get; set; } = new ChangingItem<string>();
        //public ChangingItem<string> imageurl { get; set; } = new ChangingItem<string>();
        //public ChangingItem<string> cost { get; set; } = new ChangingItem<string>();\
        public string name { get; set; }
        public BitmapImage image { get; set; }
        public string cost { get; set; }
    }
    public class BoughtProduct:Product
    {
        public ChangingItem<string> count { get; set; }
    }
}
