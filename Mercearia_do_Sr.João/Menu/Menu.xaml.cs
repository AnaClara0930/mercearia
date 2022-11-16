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
    /// Lógica interna para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {        
        public Menu(string nome, string tipo)
        {
            InitializeComponent();       

            if (tipo == "Gerente")
            {
                VisualizacaoGerente();
            }
            else
            {
                VisualizacaoCaixa();
            }

            var data = new DateOnly();

            txtMensagem.Text = $"Olá {nome} hoje é dia {data}"; 
            
        }
        public void VisualizacaoGerente()
        {
            btnProduto.Visibility = Visibility.Visible;
            btnUsuario.Visibility = Visibility.Visible;
            btnVenda.Visibility = Visibility.Visible;
        }

        public void VisualizacaoCaixa()
        {
            btnProduto.Visibility = Visibility.Hidden;
            btnUsuario.Visibility = Visibility.Hidden;
            btnVenda.Visibility = Visibility.Visible;
        }

        private void Click_Produto(object sender, RoutedEventArgs e)
        {
            GerenciarProduto tela = new GerenciarProduto();
            tela.Show();
        }

        private void Click_Usuario(object sender, RoutedEventArgs e)
        {
            GerenciarUsuario tela = new GerenciarUsuario();
            tela.Show();
        }

        private void Click_EfetuarVenda(object sender, RoutedEventArgs e)
        {
            VenderProduto tela = new VenderProduto();
            tela.Show();
        }

        private void Click_Sair(object sender, RoutedEventArgs e)
        {         
            MainWindow tela = new MainWindow();
            tela.Show();
            Close();
        }
    }
}
