using Microsoft.AspNetCore.Http;
using MyFinance1.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyFinance1.Models
{
    public class ContaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome da Conta")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o seu saldo")]
        public double Saldo { get; set; }
        public int Usuario_Id { get; set; }
        public IHttpContextAccessor HttpContextAccessor {get; set;}


        public ContaModel()
        {

        }

        public ContaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

       public List<ContaModel> ListaConta()
       {
            List<ContaModel> lista = new List<ContaModel>();
            ContaModel item;

            string id_usario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"SELECT Id, Nome, Saldo, Usuario_Id FROM Conta WHERE Usuario_Id = {id_usario_logado}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ContaModel();
                item.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                item.Nome = dt.Rows[i]["Nome"].ToString();
                item.Saldo = double.Parse(dt.Rows[i]["Saldo"].ToString());
                item.Usuario_Id = int.Parse(dt.Rows[i]["Usuario_Id"].ToString());
                lista.Add(item);

            }
            return lista; 
       }

        public void Insert()
        {
            string id_usario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"INSERT INTO Conta(Nome, Saldo, Usuario_Id) VALUES('{Nome}','{Saldo}','{id_usario_logado}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir (int id_conta)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM Conta WHERE Id =" + id_conta);

        }

    }
    
}
