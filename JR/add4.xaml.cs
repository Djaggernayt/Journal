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
    /// Логика взаимодействия для add4.xaml
    /// </summary>
    public partial class add4 : Window
    {
        public add4()
        {
            InitializeComponent();
            use.ItemsSource = regist.Getcontext().Position.ToList();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            reg ad = new reg();
            ad.Show();
            this.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new regist())
            {
                try
                {
                    var usern = new Position();
                    usern.Name = tb.Text;
                    db.Position.Add(usern);// сохранение результатов
                    db.SaveChanges();
                    MessageBox.Show("Запись добавлена");
                    use.ItemsSource = regist.Getcontext().Position.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }
    }
}
