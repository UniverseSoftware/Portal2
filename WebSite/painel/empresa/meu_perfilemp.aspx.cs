﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsuariosBO = WebSite.Business.Usuarios;
using Usuarios = WebSite.Entities.Usuarios;

public partial class painel_meu_perfil : System.Web.UI.Page
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
                txtUserUsuario.Text = usuario.UserUsuario;
                txtPassUsuario.Text = usuario.PassUsuario;
                txtConfirmaPassUsuario.Text = usuario.PassUsuario;
                txtNomeEP.Text = usuario.NomeEP;
                txtSnomeEP.Text = usuario.SnomeEP;
                txtCGCEP.Text = usuario.CGCEP;
                txtEmailEP.Text = usuario.EmailEP;
                txtTelEP.Text = usuario.TelEP;
                txtEndEP.Text = usuario.EndEP;

                //chkAtivo.Checked = usuario.Ativo;

                txtUserUsuario.Enabled = false;

            }
        }

    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        int IdUsuario;
        int.TryParse(hdfId.Value, out IdUsuario);
        string Login = txtUserUsuario.Text;
        string Senha = txtPassUsuario.Text;
        string Nome = txtNomeEP.Text;
        string Snome = txtSnomeEP.Text;
        string CGCEP = txtCGCEP.Text;
        string Email = txtEmailEP.Text;
        string Tel = txtTelEP.Text;
        string Ende = txtEndEP.Text;
        bool Ativo = chkAtivo.Checked;

        Usuarios usuario = new Usuarios();
        usuario.IdUsuario = IdUsuario;
        usuario.UserUsuario = Login;
        usuario.PassUsuario = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "MD5");
        usuario.NomeEP = Nome;
        usuario.NomeEP = Snome;
        usuario.CGCEP = CGCEP;
        usuario.EmailEP = Email;
        usuario.TelEP = Tel;
        usuario.EndEP = Ende;
        //usuario.Ativo = Ativo;

        UsuariosBO usuariosBO = new UsuariosBO();
        bool Salvou = usuariosBO.SalvaUsuario(usuario);

        if (Salvou)
        {
            Response.Redirect("meu_perfilemp.aspx?id=");
        }
    }
}