using Microsoft.AspNetCore.Http;
using MyFinance1.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyFinance1.Models
{
    public class PlanoContasModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe a Descrição!")]
        public string Descricao { get; set; }       
        public string Tipo { get; set; }
        public int Usuario_Id { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public PlanoContasModel()
        {

        }
        //Recebe o contexto para acesso as variáveis de sessão
        public PlanoContasModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<PlanoContasModel> ListaPlanoContas()
        {
            List<PlanoContasModel> lista = new List<PlanoContasModel>();
            PlanoContasModel item;

            string id_usario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"SELECT Id, Descricao, Tipo, Usuario_Id FROM Plano_Contas WHERE Usuario_Id = {id_usario_logado}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new PlanoContasModel();
                item.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                item.Descricao = dt.Rows[i]["Descricao"].ToString();
                item.Tipo = dt.Rows[i]["Tipo"].ToString();
                item.Usuario_Id = int.Parse(dt.Rows[i]["Usuario_Id"].ToString());
                lista.Add(item);

            }
            return lista;

        }
        public PlanoContasModel CarregarRegistro(int? id)
        {
            PlanoContasModel item = new PlanoContasModel();

            string id_usario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"Select Id, Descricao, Tipo, Usuario_Id From Plano_Contas Where Usuario_Id = {id_usario_logado} and Id={id}";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            DataTable dt = objDAL.RetDataTable(sql);


            item.Id = int.Parse(dt.Rows[0]["Id"].ToString());
            item.Descricao = dt.Rows[0]["Descricao"].ToString();
            item.Tipo = dt.Rows[0]["Tipo"].ToString();
            item.Usuario_Id = int.Parse(dt.Rows[0]["Usuario_Id"].ToString());
           
            return item;
        }

        public void Insert()
        {
            string id_usario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"INSERT INTO Plano_Contas(Descricao, Tipo, Usuario_Id) VALUES('{Descricao}','{Tipo}','{id_usario_logado}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
        
        public void Excluir(int id_conta)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM Plano_Contas WHERE Id =" + id_conta);

        }
    }
}
