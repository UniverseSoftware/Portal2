using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsuariosBO = WebSite.Business.Usuarios;
using Usuarios = WebSite.Entities.Usuarios;

public partial class painel_editar_usuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int IdUsuario;
                int.TryParse(Request.QueryString["id"], out IdUsuario);

                UsuariosBO usuariosBO = new UsuariosBO();
                Usuarios usuario = usuariosBO.ListaUsuarios(new Usuarios(IdUsuario)).FirstOrDefault();

                hdfId.Value = usuario.IdUsuario.ToString();
                txtNome.Text = usuario.NomeEP;
                txtEmail.Text = usuario.EmailEP;
                txtLogin.Text = usuario.UserUsuario;
                txtSenha.Text = usuario.PassUsuario;
                txtConfirmaSenha.Text = usuario.PassUsuario;
                //chkAtivo.Checked = usuario.Ativo;

                txtLogin.Enabled = false;
                txtSenha.Enabled = false;
                txtConfirmaSenha.Enabled = false;
            }
        }
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        int IdUsuario;
        int.TryParse(hdfId.Value, out IdUsuario);
        string Nome = txtNome.Text;
        string Email = txtEmail.Text;
        string Login = txtLogin.Text;
        string Senha = txtSenha.Text;
        bool Ativo = chkAtivo.Checked;

        Usuarios usuario = new Usuarios();
        usuario.IdUsuario = IdUsuario;
        usuario.NomeEP = Nome;
        usuario.EmailEP = Email;
        usuario.UserUsuario = Login;
        usuario.PassUsuario = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "MD5");
        //usuario.Ativo = Ativo;

        UsuariosBO usuariosBO = new UsuariosBO();
        bool Salvou = usuariosBO.SalvaUsuario(usuario);

        if (Salvou)
        {
            Response.Redirect("gerenciar_usuario.aspx");
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("gerenciar_usuario.aspx");
    }
}