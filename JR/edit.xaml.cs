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
using System.Windows.Shapes;

namespace JR
{
    /// <summary>
    /// Логика взаимодействия для edit.xaml
    /// </summary>
    public partial class edit : Window
    {
        int idf;
        public edit()
        {
            InitializeComponent();
            cb.ItemsSource = regist.Getcontext().Position.Select(ss => ss.ID).ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            regist.Getcontext().Position.First(ss => ss.ID == idf).Name = tb.Text;
            reg ad = new reg();
            regist.Getcontext().SaveChanges();
            ad.Show();
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            reg ad = new reg();
            ad.Show();
            this.Close();
        }

        private void cb_DropDownClosed(object sender, EventArgs e)
        {
            try//загрузка данных в поля для редактирования
            {
                idf = Convert.ToInt32(cb.Text);
                tb.Text = regist.Getcontext().Position.Where(ss => ss.ID == idf).Select(ss => ss.Name).First();

            }
            catch
            {

            }
        }
    }
}
