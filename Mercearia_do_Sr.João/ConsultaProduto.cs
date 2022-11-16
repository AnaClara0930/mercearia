using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ConsultaProduto
{
    public static bool VerificaProdutoExixtente(string nome)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        bool produtoExistente = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Produto Where nome = nome";
            comando.Parameters.AddWithValue("@nome", nome);
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                produtoExistente = true;
                break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return produtoExistente;
    }

    public static bool NovoProduto(string nome, float precoUnitario, string fornecedor)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        bool foiInserido1 = false;
        
        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Insert Into Produto (nome,precoUnitario,fornecedor) values (@nome,@precoUnitario,@fornecedor)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@precoUnitario", precoUnitario);
            comando.Parameters.AddWithValue("@fornecedor", fornecedor);
            var leitura = comando.ExecuteReader();
            foiInserido1 = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiInserido1;
    }
    public static bool AlterarProduto(string nome, float precoUnitario, string fornecedor)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        bool foiInserido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Insert Into Produto (nome,precoUnitario,fornecedor) values (@nome,@precoUnitario,@fornecedor)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@precoUnitario", precoUnitario);
            comando.Parameters.AddWithValue("@fornecedor", fornecedor);
            var leitura = comando.ExecuteReader();
            foiInserido = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiInserido;
    }

    public static bool ExcluirProduto(string nome, float precoUnitario, string fornecedor)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        bool foiInserido = false;       

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Delete from Produto (nome,precoUnitario,fornecedor) values (@nome,@precoUnitario,@fornecedor)";
            var leitura = comando.ExecuteReader();
            foiInserido = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiInserido;
    }
}
