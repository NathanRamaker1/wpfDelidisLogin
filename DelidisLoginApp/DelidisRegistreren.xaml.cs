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
    /// Interaction logic for DelidisRegistreren.xaml
    /// </summary>
    public partial class DelidisRegistreren : Window
    {
        public DelidisRegistreren()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (LoginDataContext context = new LoginDataContext())
            {
                context.Database.EnsureCreated();

                if (textPaswoordRegistreren.Password == textPaswoordHerhalen.Password)
                {
                    int teller = context.Gebruikers.Count();
                    context.Gebruikers.Add(new Gebruiker
                    {
                        Id = $"{teller + 1}",
                        Gebruikersnaam = textGebruikersnaamRegistreren.Text,
                        Paswoord = textPaswoordRegistreren.Password
                    }) ;

                    context.SaveChanges();

                    MessageBox.Show("Gebruiker aangemaakt!");
                }
                else
                {
                    MessageBox.Show("Paswoorden komen niet overeen");
                }

                DelidisLogin delidisLogin = new DelidisLogin();
                delidisLogin.Show();
                Close();

            }
        }
    }
}
