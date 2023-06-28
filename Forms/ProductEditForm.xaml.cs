using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для ProductEditForm.xaml
    /// </summary>
    public partial class ProductEditForm : Page
    {
        private Product currentItem;

        private XlebContext dbcontext;
        public ProductEditForm(XlebContext dbContext, Product item = null)
        {
            InitializeComponent();

            dbcontext = dbContext;

            if (item == null)
            {
                currentItem = new Product() { Name = "Новый продукт", Type = "Новый тип" };
                dbcontext.Products.Add(currentItem);
                try
                {
                    dbcontext.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка записи продукта в базу данных!");
                }


                fmLabel.Content = "Новый продукт";
            }
            else
            {
                currentItem = item;


                fmLabel.Content = "Редактирование продукта";
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            currentItem.Name = fmName.Text;
            currentItem.Type = fmType.Text;
            try
            {

                dbcontext.Products.Update(currentItem);
                dbcontext.SaveChanges();

                MessageBox.Show("Данные сохранены в БД!\n", "Сохранение данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка записи продукта в БД!\n" + e.ToString());
            }
        }


        private void ShowEditProduct()
        {

            fmGrid.DataContext = dbcontext.Suppliers.Find(currentItem.Id);

            fmType.Text = currentItem.Type;
            fmName.Text = currentItem.Name;
        }


        private void EditProduct_Loaded(object sender, RoutedEventArgs e)
        {
            ShowEditProduct();
        }

    }
}
