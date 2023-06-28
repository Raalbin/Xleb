using Microsoft.EntityFrameworkCore;
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
using Xleb.Models;

namespace Xleb.Forms
{
    
    /// <summary>
    /// Логика взаимодействия для ProductForm.xaml
    /// </summary>
    public partial class ProductForm : Page
    {
        private XlebContext dbcontext;
        private ContextMenu contextMenu;
        public ProductForm(XlebContext dbContext)
        {
            InitializeComponent();
            dbcontext = dbContext;

            contextMenu = new ContextMenu();

            MenuItem mi = new MenuItem();


            mi = new MenuItem();
            mi.Header = "Добавить";
            mi.Tag = 2;
            mi.Click += Menu_AddItem;
            contextMenu.Items.Add(mi);

            mi = new MenuItem();
            mi.Header = "Удалить";
            mi.Tag = 3;
            mi.Click += Menu_DeleteItem;
            contextMenu.Items.Add(mi);
            //}

            fDataGrid.ContextMenu = contextMenu;

        }

        private void Menu_AddItem(object sender, RoutedEventArgs e)
        {
            OpenEditForm(1);
        }

        private void OpenEditForm(int addnew = 0)
        {
            Product req = (Product)fDataGrid.SelectedItem;

            if ((addnew == 1) || (req == null))
            {
                MainWindow.GetNavFrame().Navigate(new ProductEditForm(dbcontext));
            }
            else
            {
                MainWindow.GetNavFrame().Navigate(new ProductEditForm(dbcontext));
            }
        }

        private void Menu_DeleteItem(object sender, RoutedEventArgs e)
        {
            Product product = (Product)fDataGrid.SelectedItem;

            if (product != null)
            {

                MessageBoxResult rez = MessageBox.Show("Вы действительно хотите удалить запись " + product.Name + "?", "Винимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (rez != MessageBoxResult.Yes) { return; }

                dbcontext.Products.Remove(product);

                try
                {
                    dbcontext.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    System.Windows.MessageBox.Show("Произошла ошибка при удалении строки!\n" + e);
                }

            }

            ShowProduct();
        }

        private void ShowProduct()
        {
            List<Product> product;

            string searchStr = tbSearch.Text.ToLower().Trim();

            product = dbcontext.Products
                //.Include(d => d.Address)
                //.ToList()
                .Where(d => d.Name!.ToLower().Contains(searchStr)
                            || d.Type!.ToLower().Contains(searchStr)
                        )
                .ToList();

            fDataGrid.ItemsSource = product;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenEditForm(1);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowProduct();
        }
    


    private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        ShowProduct();
    }

        private void fDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void fDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenEditForm(1);
        }
    }
}
