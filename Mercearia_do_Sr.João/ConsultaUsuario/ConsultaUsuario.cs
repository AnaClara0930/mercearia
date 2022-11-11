using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ConsultasUsuario
{
    public static Usuario ObterUsuarioPeloEmailSenha (string senha, string email)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        Usuario usuario = null;
        string senhaCriptografada = Criptografia.CriptografiafarBase64(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Uauario Where email = @email and senha = @senha";
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
