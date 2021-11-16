using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ProjectCafe.Viewmodels;
namespace ProjectCafe
{
    public partial class ProductCard : UserControl
    {
        public Product product { get; set; }
        public ProductCard(Product p)
        {
            InitializeComponent();
            product = p;
            DataContext = new ProductCardViewmodel(product);
        }
    }
}
