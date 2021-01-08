using System;

namespace ApiItau.Domain
{
    public class Login
    {
        public Login(string senha, string usuario)
        {
            Senha = senha;
            Usuario = usuario;
        }
        public string Senha { get; set; }
        public string Usuario { get; set; }
    }
}