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
    /// Логика взаимодействия для edit2.xaml
    /// </summary>
    public partial class edit2 : Window
    {
        int idf;
        public edit2()
        {
            InitializeComponent();
            cb1.ItemsSource = regist.Getcontext().Performer.Select(ss => ss.ID).ToList();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            reg ad = new reg();
            ad.Show();
            this.Close();
        }

        private void cb1_DropDownClosed(object sender, EventArgs e)
        {
            try//загрузка данных в поля для редактирования
            {
                idf = Convert.ToInt32(cb1.Text);
                fm.Text = regist.Getcontext().Performer.Where(ss => ss.ID == idf).Select(ss => ss.Famaly).First();
                nm.Text = regist.Getcontext().Performer.Where(ss => ss.ID == idf).Select(ss => ss.Name).First();
                pt.Text = regist.Getcontext().Performer.Where(ss => ss.ID == idf).Select(ss => ss.Patronymic).First();
                dp.SelectedDate = regist.Getcontext().Performer.Where(ss => ss.ID == idf).Select(ss => ss.Birthday).First();
                tl.Text = regist.Getcontext().Performer.Where(ss => ss.ID == idf).Select(ss => ss.Telephone).First();
                em.Text = regist.Getcontext().Performer.Where(ss => ss.ID == idf).Select(ss => ss.Email).First();
                lg.Text = regist.Getcontext().Performer.Where(ss => ss.ID == idf).Select(ss => ss.Login).First();
                ps.Text = regist.Getcontext().Performer.Where(ss => ss.ID == idf).Select(ss => ss.Password).First();
                using (var db = new regist())
                {
                    var List = db.Position.Select(p => p.Name).ToList();
                    cb.ItemsSource = List;
                }
                int ops = regist.Getcontext().Performer.Where(ss => ss.ID == idf).Select(sss => sss.ID_position).First();
                cb.Text = regist.Getcontext().Position.Where(u => u.ID == ops).Select(s => s.Name).First();
            }
            catch
            {

            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                regist.Getcontext().Performer.First(ss => ss.ID == idf).Famaly = fm.Text;
                regist.Getcontext().Performer.First(ss => ss.ID == idf).Name = nm.Text;
                regist.Getcontext().Performer.First(ss => ss.ID == idf).Patronymic = pt.Text;
                regist.Getcontext().Performer.First(ss => ss.ID == idf).Telephone = tl.Text;
                if (dp.DisplayDate == null)
                {
                    regist.Getcontext().Performer.First(ss => ss.ID == idf).Birthday = null;

                    regist.Getcontext().Performer.First(ss => ss.ID == idf).Email = em.Text;
                    
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
                                regist.Getcontext().Performer.First(ss => ss.ID == idf).Login = lg.Text;
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
                                        regist.Getcontext().Performer.First(ss => ss.ID == idf).Password = ps.Text;
                                        regist.Getcontext().Performer.First(ss => ss.ID == idf).ID_position = regist.Getcontext().Position.Where(u => u.Name == cb.Text).Select(ss => ss.ID).First();
                                        // сохранение результатов
                                        regist.Getcontext().SaveChanges();
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
                else if (dp.DisplayDate < DateTime.Now)
                {
                    regist.Getcontext().Performer.First(ss => ss.ID == idf).Birthday = dp.DisplayDate;

                    regist.Getcontext().Performer.First(ss => ss.ID == idf).Email = em.Text;
                    
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
                                regist.Getcontext().Performer.First(ss => ss.ID == idf).Login = lg.Text;
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
                                        regist.Getcontext().Performer.First(ss => ss.ID == idf).Password = ps.Text;
                                        regist.Getcontext().Performer.First(ss => ss.ID == idf).ID_position = regist.Getcontext().Position.Where(u => u.Name == cb.Text).Select(ss => ss.ID).First();
                                        // сохранение результатов
                                        regist.Getcontext().SaveChanges();
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
                else { MessageBox.Show("Выберите корректную дату"); }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
