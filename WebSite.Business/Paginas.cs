using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;

namespace WebSite.Business
{
    public class Paginas
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        public Paginas() { }

        public Entities.Paginas[] ListaPaginas()
        {
            return ListaPaginas(null);
        }

        public Entities.Paginas[] ListaPaginas(Entities.Paginas pagina)
        {
            List<Entities.Paginas> lstPaginas = new List<Entities.Paginas>();

            Data.Connection connection = new Data.Connection(this.ConnectionString);
            connection.AbrirConexao();

            StringBuilder sqlString = new StringBuilder();
            sqlString.AppendLine("SELECT * FROM PAGINAS");

            if (pagina != null)
            {
                sqlString.AppendLine("WHERE 1 = 1");

                if (pagina.Id > 0)
                {
                    sqlString.AppendLine("AND ID_PAGINA = " + pagina.Id + "");
                }

                if (!string.IsNullOrEmpty(pagina.Titulo) && pagina.Titulo.Length > 0)
                {
                    sqlString.AppendLine("AND TITULO_PAGINA LIKE '" + pagina.Titulo.Replace("'", "''") + "'");
                }

                if (!string.IsNullOrEmpty(pagina.Texto) && pagina.Texto.Length > 0)
                {
                    sqlString.AppendLine("AND TEXTO_PAGINA LIKE '" + pagina.Texto + "'");
                }
            }

            IDataReader reader = connection.RetornaDados(sqlString.ToString());

            int idxId = reader.GetOrdinal("ID_PAGINA");
            int idxTitulo = reader.GetOrdinal("TITULO_PAGINA");
            int idxTexto = reader.GetOrdinal("TEXTO_PAGINA");
            int idxDataCriacao = reader.GetOrdinal("DATACRIACAO_PAGINA");
            int idxAtivo = reader.GetOrdinal("ATIVO_PAGINA");

            while (reader.Read())
            {
                Entities.Paginas _pagina = new Entities.Paginas();
                _pagina.Id = reader.GetInt32(idxId);
                _pagina.Titulo = reader.GetString(idxTitulo);
                _pagina.Texto = reader.GetString(idxTexto);
                _pagina.DataCriacao = reader.GetDateTime(idxDataCriacao);
                _pagina.Ativo = reader.GetInt32(idxAtivo) == 1;

                lstPaginas.Add(_pagina);
            }

            connection.FechaConexao();

            return lstPaginas.ToArray();
        }

        public bool SalvaPagina(Entities.Paginas pagina)
        {
            bool salvou = false;

            if (pagina != null)
            {
                Data.Connection connection = new Data.Connection(this.ConnectionString);
                connection.AbrirConexao();

                StringBuilder sqlString = new StringBuilder();

                if (pagina.Id > 0)
                {
                    sqlString.AppendLine("UPDATE PAGINAS SET");
                    sqlString.AppendLine("TITULO_PAGINA = '" + pagina.Titulo.Replace("'", "''") + "',");
                    sqlString.AppendLine("TEXTO_PAGINA = '" + pagina.Texto.Replace("'", "''") + "',");
                    sqlString.AppendLine("ATIVO_PAGINA = " + (pagina.Ativo ? 1 : 0) + " ");
                    sqlString.AppendLine("WHERE ID_PAGINA = " + pagina.Id + "");
                }
                else
                {
                    sqlString.AppendLine("INSERT INTO PAGINAS(TITULO_PAGINA, TEXTO_PAGINA, DATACRIACAO_PAGINA, ATIVO_PAGINA)");
                    sqlString.AppendLine("VALUES('" + pagina.Titulo.Replace("'", "''") + "', '" + pagina.Texto.Replace("'", "''") + "', GETDATE(), " + (pagina.Ativo ? 1 : 0) + ")");
                }

                int i = connection.ExecutaComando(sqlString.ToString());
                salvou = i > 0;

                connection.FechaConexao();
            }

            return salvou;
        }

        public bool SalvaPagina(int Id, string Titulo, string Texto, DateTime DataCriacao, bool Ativo)
        {
            return SalvaPagina(new Entities.Paginas(Id, Titulo, Texto, DataCriacao, Ativo));
        }

        public bool ExcluiPagina(Entities.Paginas pagina)
        {
            bool salvou = false;

            if (pagina != null && pagina.Id > 0)
            {
                Data.Connection connection = new Data.Connection(this.ConnectionString);
                connection.AbrirConexao();

                StringBuilder sqlString = new StringBuilder();
                sqlString.AppendLine("DELETE FROM PAGINAS");
                sqlString.AppendLine("WHERE ID_PAGINA = " + pagina.Id + "");

                int i = connection.ExecutaComando(sqlString.ToString());

                connection.FechaConexao();
            }

            return salvou;
        }

        public bool ExcluiPagina(int Id)
        {
            return ExcluiPagina(new Entities.Paginas(Id));
        }
    }
}