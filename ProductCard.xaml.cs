using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectCafe.Viewmodels;
namespace ProjectCafe
{
    public partial class ProductCard : UserControl
    {
        public Product product { get; set; }
        public ProductCardViewmodel vm;
        public ProductCard(Product p)
        {
            InitializeComponent();
            product = p;
            vm = new ProductCardViewmodel(product);
            DataContext = vm;
        }
    }
}
