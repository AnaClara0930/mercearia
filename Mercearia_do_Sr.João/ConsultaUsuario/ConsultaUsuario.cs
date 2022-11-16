using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ConsultasUsuario
{
    public static bool VerificaUsuarioExixtente(string email)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        bool usuarioExistente = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Usuario Where email = @email";
            comando.Parameters.AddWithValue("@email", email);
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                usuarioExistente = true;
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
        return usuarioExistente;
    }
    public static bool NovoUsuario(string nome, string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        bool foiInserido = false;
        string senhaCriptografada = Criptografia.CriptografiafarBase64(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Insert Into Usuario (nome,email,senha) values (@nome,@email,@senha)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
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

    public static bool AlterarUsuario(string nome, string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        bool foiInserido = false;
        string senhaCriptografada = Criptografia.CriptografiafarBase64(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Update Usuario (nome,email,senha) values (@email,@senha)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
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

    public static bool ExcluirUsuario(string nome, string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        bool foiInserido = false;
        string senhaCriptografada = Criptografia.CriptografiafarBase64(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Delete from Usuario (nome,email,senha) values (@email,@senha)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
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

    public static Usuario ObterUsuarioPeloEmailSenha(string senha, string email)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        Usuario usuario = null;
        string senhaCriptografada = Criptografia.CriptografiafarBase64(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Usuario Where email = @email and senha = @senha";
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                usuario = new Usuario();
                usuario.id = leitura.GetInt32("id");
                usuario.email = leitura.GetString("email");
                usuario.senha = leitura.GetString("senha");
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
        return usuario;
    }
}
