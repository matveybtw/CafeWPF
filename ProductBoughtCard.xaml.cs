using ProjectCafe.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectCafe
{
    /// <summary>
    /// Логика взаимодействия для ProductBoughtCard.xaml
    /// </summary>
    public partial class ProductBoughtCard : UserControl
    {
        public BoughtProduct Product { get; set; }
        public ProductBoughtCard(BoughtProduct p)
        {
            Product = p;
            InitializeComponent();
            DataContext = new BoughtProductViewmodel(Product);
        }
    }
}
