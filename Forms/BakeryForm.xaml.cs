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
    /// Логика взаимодействия для BakeryForm.xaml
    /// </summary>
    public partial class BakeryForm : Page
    {
        private XlebContext dbcontext;
        private ContextMenu contextMenu;
        public BakeryForm(XlebContext dbContext)
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
            Bakery req = (Bakery)fDataGrid.SelectedItem;

            if ((addnew == 1) || (req == null))
            {
                MainWindow.GetNavFrame().Navigate(new BakeryEditForm(dbcontext));
            }
            else
            {
                MainWindow.GetNavFrame().Navigate(new BakeryEditForm(dbcontext, req));
            }
        }

        private void Menu_DeleteItem(object sender, RoutedEventArgs e)
        {
            Bakery drg = (Bakery)fDataGrid.SelectedItem;

            if (drg != null)
            {

                MessageBoxResult rez = MessageBox.Show("Вы действительно хотите удалить запись " + drg.Name + "?", "Винимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (rez != MessageBoxResult.Yes) { return; }

                dbcontext.Bakeries.Remove(drg);

                try
                {
                    dbcontext.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    System.Windows.MessageBox.Show("Произошла ошибка при удалении строки!\n" + e);
                }

            }

            ShowBakeries();
        }

        //вот это и есть запрос. 
        private void ShowBakeries()
        {
            List<Bakery> bakery;

            string searchStr = tbSearch.Text.ToLower().Trim();

            bakery = dbcontext.Bakeries
                //.Include(d => d.Address)
                //.ToList()
                .Where(d => d.Name!.ToLower().Contains(searchStr)
                            || d.Address!.ToLower().Contains(searchStr)
                        )
                .ToList();

            fDataGrid.ItemsSource = bakery;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenEditForm(1);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowBakeries();
        }

        private void fDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Ну неужели в аптечке не посмотреть было?
        private void Bakery_Loaded(object sender, RoutedEventArgs e)
        {
            ShowBakeries();
        }

        private void fBakery_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenEditForm(1);
        }
    }

}
