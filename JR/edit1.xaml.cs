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
    /// Логика взаимодействия для edit1.xaml
    /// </summary>
    public partial class edit1 : Window
    {
        string FilePic = null;
        int idf;
        public edit1()
        {
            InitializeComponent();
            cbi.ItemsSource = regist.Getcontext().Journal.Select(ss => ss.ID).ToList();
        }

        private void op_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FilePic != null)
                {
                    var proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = FilePic;
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                    
                }
                else
                {
                    MessageBox.Show("Файла нет в наличии");
                }
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

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                regist.Getcontext().Journal.First(ss => ss.ID == idf).Date = dp.DisplayDate;
                regist.Getcontext().Journal.First(ss => ss.ID == idf).ID_performer = regist.Getcontext().Performer.Where(u => u.Famaly == cb.Text).Select(ss => ss.ID).First();
                regist.Getcontext().Journal.First(ss => ss.ID == idf).About = tb.Text;
                regist.Getcontext().Journal.First(ss => ss.ID == idf).clip = FilePic;
                regist.Getcontext().SaveChanges();
                reg ad = new reg();
                
                ad.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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

        private void cbi_DropDownClosed(object sender, EventArgs e)
        {
            try//загрузка данных в поля для редактирования
            {
                idf = Convert.ToInt32(cbi.Text);
                dp.SelectedDate = regist.Getcontext().Journal.Where(ss => ss.ID == idf).Select(ss => ss.Date).First();
                tb.Text = regist.Getcontext().Journal.Where(ss => ss.ID == idf).Select(ss => ss.About).First();
                FilePic = regist.Getcontext().Journal.Where(ss => ss.ID == idf).Select(ss => ss.clip).First();
                using (var db = new regist())
                {
                    var List = db.Performer.Select(p => p.Famaly).ToList();
                    cb.ItemsSource = List;
                }
                int ops = regist.Getcontext().Journal.Where(ss => ss.ID == idf).Select(sss => sss.ID_performer).First();
                cb.Text = regist.Getcontext().Performer.Where(u => u.ID == ops).Select(s => s.Famaly).First();
            }
            catch
            {

            }
        }
    }
}
