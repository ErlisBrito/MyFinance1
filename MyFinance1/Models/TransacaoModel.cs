using Microsoft.AspNetCore.Http;
using MyFinance1.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace MyFinance1.Models
{
    public class TransacaoModel
    {
        public int Id { get; set; }

        public string Data { get; set; }

        public string Tipo { get; set; }

        [Required(ErrorMessage = "Informe o Valor da Transação")]
        public double Valor { get; set; }

        public int Conta_Id { get; set; }
        public string NomeConta { get; set; }

        public string Descricao { get; set; }

        public int Plano_Contas_Id { get; set; }
        public string DescricaoPlanoConta { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }


        public TransacaoModel()
        {

        }

        public TransacaoModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<TransacaoModel> ListaTransacao()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();
            TransacaoModel item;

            string id_usario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = "select t.Id, Data, t.Tipo, t.Valor, t.Descricao as Historico, t.Conta_Id, " +
                                    " c.Nome as Conta, t.Plano_Conta_Id, p.Descricao as Plano_Conta" +
                                    " from Transacao as t inner join Conta c" +
                                    " on t.Conta_Id = c.Id inner join Plano_Contas as p" +
                                    " on t.Plano_Conta_Id = p.Id " +
                                    $"where t.Usuario_Id = {id_usario_logado} order by t.Data desc limit 10";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new TransacaoModel();
                item.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                item.Data = DateTime.Parse(dt.Rows[i]["Data"].ToString()).ToString("dd/MM/yyyy");
                item.Descricao = dt.Rows[i]["Historico"].ToString();
                item.Tipo = dt.Rows[i]["Tipo"].ToString();
                item.Valor = double.Parse(dt.Rows[i]["Valor"].ToString());
                item.Conta_Id = int.Parse(dt.Rows[i]["Conta_Id"].ToString());
                item.NomeConta = dt.Rows[i]["Tipo"].ToString();
                item.Plano_Contas_Id = int.Parse(dt.Rows[i]["Plano_Conta_Id"].ToString());
                item.DescricaoPlanoConta = dt.Rows[i]["Plano_conta"].ToString();
                lista.Add(item);

            }
            return lista;
        }
    }
}
