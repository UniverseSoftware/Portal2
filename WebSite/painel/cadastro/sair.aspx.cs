using System;

public partial class painel_sair : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("PainelAutenticado");
        Session.Remove("Usuario");
        Response.Redirect("~/painel/login.aspx");
    }
}