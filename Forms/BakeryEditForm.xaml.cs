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
    /// Логика взаимодействия для BakeryEditForm.xaml
    /// </summary>
    public partial class BakeryEditForm : Page
    {
        private Bakery currentItem;

        private XlebContext dbcontext;
        public BakeryEditForm(XlebContext dbContext, Bakery item = null)
        {
            InitializeComponent();

            dbcontext = dbContext;

            if (item == null)
            {
                currentItem = new Bakery() { Name = "Новая пекарня", Address = "Новый адрес"};
                dbcontext.Bakeries.Add(currentItem);
                try
                {
                    dbcontext.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка записи пекарни в базу данных!");
                }

               
                fmLabel.Content = "Новая пекарня";
            }
            else
            {
                currentItem = item;

               
                fmLabel.Content = "Редактирование пекарни";
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            currentItem.Name = fmName.Text;
            currentItem.Address = fmAddress.Text;
            try
            {

                dbcontext.Bakeries.Update(currentItem);
                dbcontext.SaveChanges();

                MessageBox.Show("Данные сохранены в БД!\n", "Сохранение данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка записи пекарни в БД!\n" + e.ToString());
            }
        }

        private void ShowEditBakery()
        {
            
            fmGrid.DataContext = dbcontext.Bakeries.Find(currentItem.Id);

            fmAddress.Text = currentItem.Address;
            fmName.Text = currentItem.Name;
        }

        private void EditBakery_Loaded(object sender, RoutedEventArgs e)
        {
            ShowEditBakery();
        }
    }
}


