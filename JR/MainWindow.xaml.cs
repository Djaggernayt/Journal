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

namespace JR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sign_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new regist())
            {
                /*User*/
                var usern = db.Performer.FirstOrDefault(u => u.Login == login.Text && u.Password == password.Password);//проверка логина и пароля
                if (usern == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else
                {
                    if (usern.ID_position == 1)
                    {
                        Manager.id = regist.Getcontext().Performer.Where(u => u.Login == login.Text && u.Password == password.Password).Select(ss => ss.ID).First();
                        MessageBox.Show("Hello Admin: " + regist.Getcontext().Performer.Where(u => u.Login == login.Text && u.Password == password.Password).Select(ss => ss.Name).First());//вывод имени пользователя
                        reg admin = new reg();
                        admin.Show();
                        this.Close();

                    }
                    else
                    {
                        Manager.id = regist.Getcontext().Performer.Where(u => u.Login == login.Text && u.Password == password.Password).Select(ss => ss.ID).First();
                        MessageBox.Show("Hello User: " + regist.Getcontext().Performer.Where(u => u.Login == login.Text && u.Password == password.Password).Select(ss => ss.Name).First());
                        reg user = new reg();
                        user.Show();
                        this.Close();
                    }

                }
            }
        }
    }
}
