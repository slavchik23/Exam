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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           

             //Создание в капчи 5 разных символов


            MyCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 5);
            var answer = MyCaptcha.CaptchaText;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             //привязка капчи к кнопки
            var answer = MyCaptcha.CaptchaText;
            if (answer == MyCaptcha.CaptchaText)
            {
                //подключение базы данных
                using (tradeEntities upling = new tradeEntities())
                {
                    var query = upling.User;
                    foreach (var item in query)
                    {
                        //подключения пользователя по ролям
                        if (item.UserLogin == xyoi.Text)
                        {

                            if (item.UserPassword == dcdf.Password)
                            {

                                if (item.UserRole == 1)
                                {
                                    Klient upload = new Klient();
                                    upload.Show();
                                    this.Close();
                                }
                                else if (item.UserRole == 2)
                                {
                                    Manager upload = new Manager();
                                    upload.Show();
                                    this.Close();
                                }
                                else if (item.UserRole == 3)
                                {
                                    Administrator upload = new Administrator();
                                    upload.Show();
                                    this.Close();
                                }
                            }
                        }
                    }

                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //перезапуск капчи

            MyCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 5);
        }
    }
}
