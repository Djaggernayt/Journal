using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Логика взаимодействия для add1.xaml
    /// </summary>
    /// 
    public partial class add1 : Window
    {

        string FilePic = null;
        public add1()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            user ad = new user();
            ad.Show();
            this.Close();
        }



        private void add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new regist())
            {
                try
                {
                    var usern = new Journal();// заполнение базы данных
                    usern.Date = DateTime.Now;
                    usern.About = tt.Text;

                    usern.clip = FilePic;
                    usern.ID_performer = Manager.id;
                    db.Journal.Add(usern);// сохранение результатов
                    db.SaveChanges();
                    MessageBox.Show("Запись добавлена");
                    user admin = new user();
                    admin.Show();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        private void pr_Click(object sender, RoutedEventArgs e)
        {
            // открытие файла
            OpenFileDialog dPic = new OpenFileDialog();
            dPic.Filter = "Файлы|*.pdf;*.doc;*.docx;*.xls;*.txt|Все файлы|*.*";
            if (dPic.ShowDialog() == true)
            {
                FilePic = dPic.FileName;
            }
            else
            {
                
                return;
            }
            

        }
    }
}
