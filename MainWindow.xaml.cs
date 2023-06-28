using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows;
using System.Windows.Controls;
using Xleb.Forms;
using Xleb.Models;

namespace Xleb
{
    public partial class MainWindow : Window
    {
        private readonly XlebContext dbcontext;
        private static Frame navigationFrame = null!;

        public MainWindow()
        {
            InitializeComponent();

            navigationFrame = mainFrame;
            dbcontext = new XlebContext();
        }

        private void OpenBakeriesForm_Click(object sender, RoutedEventArgs e)
        {

           
        }

        public static Frame GetNavFrame()
        {
            return navigationFrame;
        }

        private void Bakery_Click(object sender, RoutedEventArgs e)
        {
            toRequestsForm();
        }
        private void toRequestsForm(int basket = 0)
        {
            mainFrame.Navigate(new BakeryForm(dbcontext));
        }

        private void toProductForm(int basket = 0)
        {
            mainFrame.Navigate(new ProductForm(dbcontext));
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            toProductForm();
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            toSupplierForm();
        }
        private void toSupplierForm(int basket = 0)
        {
            mainFrame.Navigate(new SupplierForm(dbcontext));
        }

        private void Supply_Click(object sender, RoutedEventArgs e)
        {
            toSupplyForm();
        }

        private void toSupplyForm(int basket = 0)
        {
            mainFrame.Navigate(new SupplyForm(dbcontext));
        }
    }
}