using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для add3.xaml
    /// </summary>
    public partial class add3 : Window
    {
        string FilePic = null;
        public add3()
        {
            InitializeComponent();
            dp.SelectedDate = DateTime.Now;
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
                    var usern = new Journal();// заполнение базы данных
                    
                        usern.Date = dp.DisplayDate;
                        usern.About = tb.Text;

                        usern.clip = FilePic;
                        usern.ID_performer = regist.Getcontext().Performer.Where(u => u.Famaly==cb.Text).Select(ss => ss.ID).First();
                        db.Journal.Add(usern);// сохранение результатов
                        db.SaveChanges();
                        MessageBox.Show("Запись добавлена");
                        reg admin = new reg();
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

        private void cb_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new regist())
            {
                var List = db.Performer.Select(p => p.Famaly).ToList();
                cb.ItemsSource = List;
            }
        }
    }
}
