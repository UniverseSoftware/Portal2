using System;

namespace WebSite.Entities
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string UserUsuario { get; set; }
        public string PassUsuario { get; set; }
        public int StatusUsuario { get; set; }
        public int TipoUsuario { get; set; }
        public int IdEP { get; set; }
        public string NomeEP { get; set; }
        public string SnomeEP { get; set; }
        public string CGCEP { get; set; }
        public string EmailEP { get; set; }
        public string TelEP { get; set; }
        public string EndEP { get; set; }

        public Usuarios()
        {

        }

        public Usuarios(int IdUsuario)
        {
            this.IdUsuario = IdUsuario;
        }

        public Usuarios(string Login)
        {
            this.UserUsuario = Login;
        }

        public Usuarios(string Login, string Senha)
        {
            this.UserUsuario = Login;
            this.PassUsuario = Senha;
        }

        public Usuarios(int IdUsuario, string Nome, string Email, string Login, string Senha)
        {
            this.IdUsuario = IdUsuario;
            this.NomeEP = Nome;
            this.EmailEP = Email;
            this.UserUsuario = Login;
            this.PassUsuario = Senha;

        }
    }
}