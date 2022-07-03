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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.SqlClient;

namespace JR
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : System.Windows.Window
    {
        public reg()
        {
            InitializeComponent();
            use.ItemsSource = regist.Getcontext().Journal.ToList();
        }

        private void FormatTable(dynamic table)
        {
            dynamic borders = table.Borders;
            //wdBorderLeft
            borders[-2].LineStyle = 1;//wdLineStyleSingle
            borders[-2].LineWidth = 12;//wdLineWidth150pt
            borders[-2].Color = -16777216;
            //wdBorderRight
            borders[-4].LineStyle = 1;//wdLineStyleSingle
            borders[-4].LineWidth = 12;//wdLineWidth150pt
            borders[-4].Color = -16777216;
            //wdBorderTop
            borders[-1].LineStyle = 1;//wdLineStyleSingle
            borders[-1].LineWidth = 12;//wdLineWidth150pt
            borders[-1].Color = -16777216;
            //wdBorderBottom
            borders[-3].LineStyle = 1;//wdLineStyleSingle
            borders[-3].LineWidth = 12;//wdLineWidth150pt
            borders[-3].Color = -16777216;
            //wdBorderHorizontal
            borders[-5].LineStyle = 1;//wdLineStyleSingle
            borders[-5].LineWidth = 6;//wdLineWidth075pt 
            borders[-5].Color = -16777216;
            //wdBorderVertical
            borders[-6].LineStyle = 1;//wdLineStyleSingle
            borders[-6].LineWidth = 12;//wdLineWidth150pt
            borders[-6].Color = -16777216;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (cb.SelectedIndex == 1)
            {
                add2 ada = new add2();
                ada.Show();
                this.Close();
            }
            else if (cb.SelectedIndex == 2)
            {
                add4 ada = new add4();
                ada.Show();
                this.Close();
            }
            else
            {
                add3 ad = new add3();
                ad.Show();
                this.Close();
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (cb.SelectedIndex == 1)
            {
                edit2 ada = new edit2();
                ada.Show();
                this.Close();
            }
            else if (cb.SelectedIndex == 2)
            {
                edit ada = new edit();
                ada.Show();
                this.Close();
            }
            else
            {
                edit1 ad = new edit1();
                ad.Show();
                this.Close();
            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            if (cb.SelectedIndex == 1)
            {
                var ho = use.SelectedItems.Cast<Performer>().ToList();// удаление выбранной строки  
                if (MessageBox.Show($"Вы точно хотите удалить следующие {ho.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        regist.Getcontext().Performer.RemoveRange(ho);
                        regist.Getcontext().SaveChanges();
                        use.ItemsSource = regist.Getcontext().Performer.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else if (cb.SelectedIndex == 2)
            {
                var ho = use.SelectedItems.Cast<Position>().ToList();// удаление выбранной строки  
                if (MessageBox.Show($"Вы точно хотите удалить следующие {ho.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        regist.Getcontext().Position.RemoveRange(ho);
                        regist.Getcontext().SaveChanges();
                        use.ItemsSource = regist.Getcontext().Position.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else if (cb.SelectedIndex == 0)
            {
                var ho = use.SelectedItems.Cast<Journal>().ToList();// удаление выбранной строки  
                if (MessageBox.Show($"Вы точно хотите удалить следующие {ho.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        regist.Getcontext().Journal.RemoveRange(ho);
                        regist.Getcontext().SaveChanges();
                        use.ItemsSource = regist.Getcontext().Journal.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void ex_Click(object sender, RoutedEventArgs e)
        {
            Manager.id = -1;
            MainWindow ad = new MainWindow();
            ad.Show();
            this.Close();
        }

        private void word_Click(object sender, RoutedEventArgs e)
        {
            if (use.ItemsSource != null)
            {
                use.SelectAllCells();
                use.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, use);
                use.UnselectAllCells();
                var result = (string)Clipboard.GetData(DataFormats.Text);
                dynamic wordApp = null;
                try
                {
                    var sw = new StreamWriter("export.doc");
                    sw.WriteLine(result);
                    sw.Close();
                    //var proc = Process.Start("export.doc");
                    Type wordType = Type.GetTypeFromProgID("Word.Application");
                    wordApp = Activator.CreateInstance(wordType);
                    wordApp.Documents.Add(System.AppDomain.CurrentDomain.BaseDirectory + "export.doc");
                    dynamic wdTable = wordApp.ActiveDocument.Range.ConvertToTable(1, use.Items.Count, use.Columns.Count);
                    FormatTable(wdTable);
                    wordApp.Visible = true;
                }
                catch (Exception ex)
                {
                    if (wordApp != null)
                    {
                        wordApp.Quit();
                    }
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else { MessageBox.Show("Выберите таблицу"); }
        }

        private void exc_Click(object sender, RoutedEventArgs e)
        {
            if (use.ItemsSource != null)
            {
                Excel.Application excel = new Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                for (int j = 0; j < use.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[1, j + 1];
                    sheet1.Cells[1, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 15;
                    myRange.Value = use.Columns[j].Header;
                }
                for (int i = 0; i < use.Columns.Count; i++)
                {
                    for (int j = 0; j < use.Items.Count; j++)
                    {
                        TextBlock b = use.Columns[i].GetCellContent(use.Items[j]) as TextBlock;
                        if (b != null)
                        { 
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                        myRange.Value = b.Text;
                        }
                    }
                }
            }
            else { MessageBox.Show("Выберите таблицу"); }
        }

        private void cb_DropDownClosed(object sender, EventArgs e)
        {
            if (cb.SelectedIndex == 0)
            {
                use.ItemsSource = regist.Getcontext().Journal.ToList();
            }
            else if (cb.SelectedIndex == 1)
            {
                use.ItemsSource = regist.Getcontext().Performer.ToList();
            }
            else if (cb.SelectedIndex == 2)
            {
                use.ItemsSource = regist.Getcontext().Position.ToList();
            }
        }

        private void copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            string path = @"C:\";
            string subpath = @"Backup";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=register;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = @"BACKUP DATABASE [register] TO  DISK = N'C:\Backup\register.bak' WITH NOFORMAT, NOINIT,  NAME = N'register-Полная База данных Резервное копирование', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                command.Connection = connection;
                command.ExecuteReader();
            }
            MessageBox.Show("Файл создан по пути: C:/Backup/register.bak");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
