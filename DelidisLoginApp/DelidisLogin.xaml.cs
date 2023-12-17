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

namespace DelidisLoginApp
{
    /// <summary>
    /// Interaction logic for DelidisLogin.xaml
    /// </summary>
    public partial class DelidisLogin : Window
    {
        public DelidisLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Gebruikersnaam = textGebruikersnaam.Text;
            var Paswoord = textPaswoord.Password;
            
            using (LoginDataContext context = new LoginDataContext())
            {
                bool gebruikerGevonden = context.Gebruikers.Any(user => user.Gebruikersnaam == Gebruikersnaam && user.Paswoord == Paswoord);

                if (gebruikerGevonden)
                {
                    ToegangVerlenen();
                    Close();
                }
                else
                {
                    MessageBox.Show("Gebruiker niet gevonden");
                }

            }

        }

        public void ToegangVerlenen()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DelidisRegistreren window = new DelidisRegistreren();
            window.Show();
            Close();
        }
    }
}
