using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
using System.Xml.Linq;
using Xleb.Models;

namespace Xleb.Forms
{
    /// <summary>
    /// Логика взаимодействия для SupplyEditForm.xaml
    /// </summary>
    public partial class SupplyEditForm : Page
    {
        private Supply currentItem;

        private XlebContext dbcontext;
        public SupplyEditForm(XlebContext dbContext, Supply item = null)
        {
            InitializeComponent();

            dbcontext = dbContext;

            if (item == null)
            {
                currentItem = new Supply() { BakeriesId = 1, SuppliersId = 1, ProductsId = 1};
                dbcontext.Supplies.Add(currentItem);
                try
                {
                    dbcontext.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка записи поставки в базу данных!");
                }


                fmLabel.Content = "Новая поставка";
            }
            else
            {
                currentItem = item;


                fmLabel.Content = "Редактирование поставки";
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                currentItem.ProductsId = ((Product)fmProduct.SelectedItem).Id;
                currentItem.SuppliersId = ((Supplier)fmSupplier.SelectedItem).Id;
                currentItem.BakeriesId = ((Bakery)fmBakery.SelectedItem).Id;

                dbcontext.SaveChanges();

                MessageBox.Show("Данные сохранены в БД!\n", "Сохранение данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка записи поставки в БД!\n" + e.ToString());
            }


        }
    }
}
