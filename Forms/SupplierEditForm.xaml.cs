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
    /// Логика взаимодействия для SupplierEditForm.xaml
    /// </summary>
    public partial class SupplierEditForm : Page
    {
        private Supplier currentItem;

        private XlebContext dbcontext;
        public SupplierEditForm(XlebContext dbContext, Supplier item = null)
        {
            InitializeComponent();


            dbcontext = dbContext;

            if (item == null)
            {
                currentItem = new Supplier() { Name = "Новый поставщик", Address = "Новый адрес" };
                dbcontext.Suppliers.Add(currentItem);
                try
                {
                    dbcontext.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка записи пекарни в базу данных!");
                }


                fmLabel.Content = "Новый поставщик";
            }
            else
            {
                currentItem = item;


                fmLabel.Content = "Редактирование поставщика";
            }


        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            currentItem.Name = fmName.Text;
            currentItem.Address = fmAddress.Text;
            try
            {

                dbcontext.Suppliers.Update(currentItem);
                dbcontext.SaveChanges();

                MessageBox.Show("Данные сохранены в БД!\n", "Сохранение данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка записи поставщика в БД!\n" + e.ToString());
            }


        }
        private void ShowEditSupplier()
        {

            fmGrid.DataContext = dbcontext.Suppliers.Find(currentItem.Id);

            fmAddress.Text = currentItem.Address;
            fmName.Text = currentItem.Name;
        }

        private void EditSupplier_Loaded(object sender, RoutedEventArgs e)
        {
            ShowEditSupplier();
        }
    }
}
