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
using MySqlConnector;

namespace Mercearia_do_Sr.João
{
    /// <summary>
    /// Lógica interna para GerenciarUsuario.xaml
    /// </summary>
    public partial class GerenciarUsuario : Window
    {
        public GerenciarUsuario()
        {
            InitializeComponent();
        }

        private void CadastrarUsuario(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos() == true)
            {
                string nome = txtNomeUsuario.Text;
                string email = txtEmailUsuario.Text;
                string senha = txtSenha1.Password;
                CbTipoUsuario.Items.Add("Gerente");
                CbTipoUsuario.Items.Add("Caixa");
                bool usuarioExiste = ConsultasUsuario.VerificaUsuarioExixtente(email);
                if (usuarioExiste == false)
                {
                    bool validarCadastor = ConsultasUsuario.NovoUsuario(nome, email, senha);
                    if (validarCadastor == true)
                    {
                        MessageBoxResult result = MessageBox.Show(
                         "Usuario cadastrado com sucesso !",
                         "Informação",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information
                         );
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(
                    "Email já existe no sistema",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                }
            }
        }

        private bool VerificaCampos()
        {
            if (txtEmailUsuario.Text != "" && txtSenha1.Password != "" && txtConfirmaSenha.Password != "")
            {
                if (txtSenha1.Password == txtConfirmaSenha.Password)
                {
                    return true;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(
                    "Senha e confirma senha não conferem",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                    return false;
                }
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

        private void Alterar(object sender, RoutedEventArgs e)
        {
            bool alterar = cUsuario.AlterarUsuario(txtNomeUsuario.Text, txtEmailUsuario.Text, txtSenha1.Password);
            if (alterar == true)
            {
                cUsuario.AlterarUsuario(txtNomeUsuario.Text, txtEmailUsuario.Text, txtSenha1.Password);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                   "Não foi possivel alterar",
                   "Atenção",
                   MessageBoxButton.OK,
                   MessageBoxImage.Warning
                );
            }
        }
        private void Excluir(object sender, RoutedEventArgs e)
        {
            bool excluir = cUsuario.ExcluirUsuario(txtNomeUsuario.Text, txtEmailUsuario.Text, txtSenha1.Password);
            if (excluir == true)
            {
                cUsuario.ExcluirUsuario(txtNomeUsuario.Text, txtEmailUsuario.Text, txtSenha1.Password);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                   "Não foi possivel excluir",
                   "Atenção",
                   MessageBoxButton.OK,
                   MessageBoxImage.Warning
                );
            }
        }
    }
}