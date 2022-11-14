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

        private void AbrirMenu(string nome, string tipo)
        {
            Menu frmMenu = new Menu(nome, tipo);
            frmMenu.Show();
            Close();
        }

        private void FazerLogin(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtPassword.Password;
            Usuario usuario = ConsultasUsuario.ObterUsuarioPeloEmailSenha(email, senha);
            if (usuario != null)
            {
                AbrirMenu(usuario.nome, usuario.tipoUsuario);
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


        private void Click_Entrar(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtPassword.Password;
            Usuario usuario = ConsultasUsuario.ObterUsuarioPeloEmailSenha(email, senha);
            if (usuario != null)
            {
                AbrirMenu(usuario.nome, usuario.tipoUsuario);
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

        private void Click_EsqueceuSenha(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Contate o seu Gerente",
                "Informação",
                MessageBoxButton.OK,
                MessageBoxImage.Warning
                );
        }
    }
}
