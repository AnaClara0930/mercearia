using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Criptografia
{
    public static string CriptografiafarBase64(string senha)
    {
        var textoEmBytes = Encoding.UTF8.GetBytes(senha);
        return Convert.ToBase64String(textoEmBytes);
    }
}
