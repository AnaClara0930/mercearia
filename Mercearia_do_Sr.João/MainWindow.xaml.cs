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

namespace Mercearia_do_Sr.João
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FazerLogin(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos() == true)
            {
                string email = txtEmail.Text;
                string senha = txtPassword.Password;
                Usuario usuario = ConsultasUsuario.ObterUsuarioPeloEmailSenha(email, senha);
                if (usuario != null)
                {
                    AbrirTelaMenu();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(
                    "Email ou senha incorretos",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                }
            }
        }

        private bool VerificaCampos()
        {
            if (txtEmail.Text != "" && txtPassword.Password != "")
            {
                return true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                   "Preencha todos os campos",
                   "Atenção",
                   MessageBoxButton.OK,
                   MessageBoxImage.Warning
                );
                return false;
            }
        }
    }
}
