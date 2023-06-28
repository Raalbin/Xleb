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
    /// Логика взаимодействия для SupplyForm.xaml
    /// </summary>
    public partial class SupplyForm : Page
    {
        private XlebContext dbcontext;
        private ContextMenu contextMenu;
        public SupplyForm(XlebContext dbContext)
        {
            InitializeComponent();

            dbcontext = dbContext;



            // Создаём контекстное меню для элемента DataGrid
            //{
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
            Supply supply = (Supply)fDataGrid.SelectedItem;

            if ((addnew == 1) || (supply == null))
            {
                MainWindow.GetNavFrame().Navigate(new SupplyEditForm(dbcontext));
            }
            else
            {
                MainWindow.GetNavFrame().Navigate(new SupplyEditForm(dbcontext));
            }
        }

        private void Menu_DeleteItem(object sender, RoutedEventArgs e)
        {
            Supply supply = (Supply)fDataGrid.SelectedItem;

            if (supply != null)
            {

                MessageBoxResult rez = MessageBox.Show("Вы действительно хотите удалить запись " + supply.BakeriesId + "?", "Винимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (rez != MessageBoxResult.Yes) { return; }

                dbcontext.Supplies.Remove(supply);

                try
                {
                    dbcontext.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    System.Windows.MessageBox.Show("Произошла ошибка при удалении строки!\n" + e);
                }

            }

            ShowSupply();
        }

        private void ShowSupply()
        {
            List<Supply> supplies;

            string searchStr = tbSearch.Text.ToLower().Trim();

            supplies = dbcontext.Supplies
                //.Include(d => d.Address)
                //.ToList()
                .Where(d => d.Bakeries!.Name.ToLower().Contains(searchStr)
                            || d.Products!.Name.ToLower().Contains(searchStr)
                            || d.Suppliers!.Name.ToLower().Contains(searchStr)

                        )
                .ToList();

            fDataGrid.ItemsSource = supplies;
        }

        private void Supply_Loaded(object sender, RoutedEventArgs e)
        {
            ShowSupply();
        }

        private void fDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Supply_Click(object sender, RoutedEventArgs e)
        {
            OpenEditForm(1);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowSupply();
        }

        private void fSupply_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenEditForm(1);
        }
    }
}
