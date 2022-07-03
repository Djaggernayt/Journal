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
    /// Логика взаимодействия для add2.xaml
    /// </summary>
    public partial class add2 : Window
    {
        public add2()
        {
            InitializeComponent();
        }

        private void cb_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new regist())
            {
                var List = db.Position.Select(p => p.Name).ToList();
                cb.ItemsSource = List;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new regist())
            {
                try
                {
                    var usern = new Performer();// заполнение базы данных
                    usern.Famaly = fm.Text;
                    usern.Name = nm.Text;
                    usern.Patronymic = pt.Text;
                    usern.Telephone = tl.Text;
                    if(dp.DisplayDate==null)
                    {
                        usern.Birthday = null;

                        usern.Email = em.Text;
                        var tct = db.Performer.FirstOrDefault(c => c.Login == lg.Text);
                        if (tct == null)
                        {
                            if (lg.Text.Length >= 6)
                            {
                                bool en = false; // английская раскладка
                                bool symbol = false; // символ
                                bool number = false; // цифра

                                for (int i = 0; i < lg.Text.Length; i++) // перебираем символы
                                {
                                    if ((lg.Text[i] >= 'A' && lg.Text[i] <= 'Z') || (lg.Text[i] >= 'a' && lg.Text[i] <= 'z')) en = true; // если русская раскладка
                                    if (lg.Text[i] >= '0' && lg.Text[i] <= '9') number = true; // если цифры
                                    if (lg.Text[i] == '_' || lg.Text[i] == '-' || lg.Text[i] == '!') symbol = true; // если символ
                                }

                                if (!en)
                                    MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                                else if (!symbol)
                                    MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                                else if (!number)
                                    MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                                if (en && symbol && number) // проверяем соответствие
                                {
                                    usern.Login = lg.Text;
                                    if (ps.Text.Length >= 6)
                                    {
                                        bool enn = false; // английская раскладка
                                        bool symboln = false; // символ
                                        bool numbern = false; // цифра

                                        for (int i = 0; i < ps.Text.Length; i++) // перебираем символы
                                        {
                                            if ((ps.Text[i] >= 'A' && ps.Text[i] <= 'Z') || (ps.Text[i] >= 'a' && ps.Text[i] <= 'z')) enn = true; // если русская раскладка
                                            if (ps.Text[i] >= '0' && ps.Text[i] <= '9') numbern = true; // если цифры
                                            if (ps.Text[i] == '_' || ps.Text[i] == '-' || ps.Text[i] == '!') symboln = true; // если символ
                                        }

                                        if (!enn)
                                            MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                                        else if (!symboln)
                                            MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                                        else if (!numbern)
                                            MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                                        if (enn && symboln && numbern) // проверяем соответствие
                                        {
                                            usern.Password = ps.Text;
                                            usern.ID_position = regist.Getcontext().Position.Where(u => u.Name == cb.Text).Select(ss => ss.ID).First();
                                            db.Performer.Add(usern);// сохранение результатов
                                            db.SaveChanges();
                                            MessageBox.Show("Запись добавлена");
                                            reg admin = new reg();
                                            admin.Show();
                                            this.Close();

                                        }

                                    }
                                    else MessageBox.Show("Пароль слишком короткий, минимум 6 символов");
                                }

                            }
                            else MessageBox.Show("Логин слишком короткий, минимум 6 символов");

                        }
                        else { MessageBox.Show("Такой логин существует"); }
                    }
                    else if(dp.DisplayDate < DateTime.Now)
                    {
                        usern.Birthday = dp.DisplayDate;

                        usern.Email = em.Text;
                        var tct = db.Performer.FirstOrDefault(c => c.Login == lg.Text);
                        if (tct == null)
                        {
                            if (lg.Text.Length >= 6)
                            {
                                bool en = false; // английская раскладка
                                bool symbol = false; // символ
                                bool number = false; // цифра

                                for (int i = 0; i < lg.Text.Length; i++) // перебираем символы
                                {
                                    if ((lg.Text[i] >= 'A' && lg.Text[i] <= 'Z') || (lg.Text[i] >= 'a' && lg.Text[i] <= 'z')) en = true; // если русская раскладка
                                    if (lg.Text[i] >= '0' && lg.Text[i] <= '9') number = true; // если цифры
                                    if (lg.Text[i] == '_' || lg.Text[i] == '-' || lg.Text[i] == '!') symbol = true; // если символ
                                }

                                if (!en)
                                    MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                                else if (!symbol)
                                    MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                                else if (!number)
                                    MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                                if (en && symbol && number) // проверяем соответствие
                                {
                                    usern.Login = lg.Text;
                                    if (ps.Text.Length >= 6)
                                    {
                                        bool enn = false; // английская раскладка
                                        bool symboln = false; // символ
                                        bool numbern = false; // цифра

                                        for (int i = 0; i < ps.Text.Length; i++) // перебираем символы
                                        {
                                            if ((ps.Text[i] >= 'A' && ps.Text[i] <= 'Z') || (ps.Text[i] >= 'a' && ps.Text[i] <= 'z')) enn = true; // если русская раскладка
                                            if (ps.Text[i] >= '0' && ps.Text[i] <= '9') numbern = true; // если цифры
                                            if (ps.Text[i] == '_' || ps.Text[i] == '-' || ps.Text[i] == '!') symboln = true; // если символ
                                        }

                                        if (!enn)
                                            MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                                        else if (!symboln)
                                            MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                                        else if (!numbern)
                                            MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                                        if (enn && symboln && numbern) // проверяем соответствие
                                        {
                                            usern.Password = ps.Text;
                                            usern.ID_position = regist.Getcontext().Position.Where(u => u.Name == cb.Text).Select(ss => ss.ID).First();
                                            db.Performer.Add(usern);// сохранение результатов
                                            db.SaveChanges();
                                            MessageBox.Show("Запись добавлена");
                                            reg admin = new reg();
                                            admin.Show();
                                            this.Close();

                                        }

                                    }
                                    else MessageBox.Show("Пароль слишком короткий, минимум 6 символов");
                                }
                                
                            }
                            else MessageBox.Show("Логин слишком короткий, минимум 6 символов");
                            
                        }
                        else { MessageBox.Show("Такой логин существует"); }
                        
                    }
                    else { MessageBox.Show("Выберите корректную дату"); }
                        

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            reg ad = new reg();
            ad.Show();
            this.Close();
        }
    }
}
