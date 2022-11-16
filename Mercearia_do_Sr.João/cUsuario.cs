using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class cUsuario
{
    public static bool VerificaUsuarioExixtente(string email)
    {
        return ConsultasUsuario.VerificaUsuarioExixtente(email);
    }
    public static bool NovoUsuario(string nome, string email, string senha)
    {
        return ConsultasUsuario.NovoUsuario(nome, email, senha);
    }
    public static bool AlterarUsuario(string nome, string email, string senha)
    {
        return ConsultasUsuario.NovoUsuario(nome, email, senha);
    }
    public static bool ExcluirUsuario(string nome, string email, string senha)
    {
        return ConsultasUsuario.NovoUsuario(nome, email, senha);
    }
    public static Usuario ObterUsuarioPeloEmailSenha(string senha, string email)
    {
        return ConsultasUsuario.ObterUsuarioPeloEmailSenha(senha, email);
    }
}

