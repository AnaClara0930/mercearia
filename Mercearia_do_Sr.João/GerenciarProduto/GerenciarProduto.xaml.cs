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

namespace Mercearia_do_Sr.João
{
    /// <summary>
    /// Lógica interna para GerenciarProduto.xaml
    /// </summary>
    public partial class GerenciarProduto : Window
    {
        public GerenciarProduto()
        {
            InitializeComponent();
        }

        private void CadastrarProduto(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos() == true)
            {
                string nome = txtNomeProduto.Text;
                string precoUnitario = txtPrecoUnid.Text;
                string quantidade = txtQtdProduto.Text;
                string fornecedor = txtFornecedor.Text;
                bool produtoExiste = ConsultasUsuario.VerificaUsuarioExixtente(nome);
                if (produtoExiste == false)
                {
                    bool validarCadastor = ConsultaProduto.NovoProduto(nome, precoUnitario, fornecedor);
                    if (validarCadastor == true)
                    {
                        MessageBoxResult result = MessageBox.Show(
                         "Produto cadastrado com sucesso !",
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
            if (txtNomeProduto.Text != "" && txtFornecedor.Text != "" )
            {
                 return false;            
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
