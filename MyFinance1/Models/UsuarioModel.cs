using MyFinance1.Util;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyFinance1.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe seu Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe  seu e-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe sua data de nascimento!")]
        public String DataNascimento { get; set; }

        public bool ValidarLogin()
        {
            string sql = $"SELECT Id, Nome, DataNascimento FROM Usuario  WHERE Email='{Email}' AND Senha='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString());
                    Nome = dt.Rows[0]["Nome"].ToString();
                    DataNascimento = dt.Rows[0]["DataNascimento"].ToString();
                    return true;
                }
            }

            return false;
        }
        public void RegistrarUsuario()
        {
            var dataNascimento = DateTime.Parse(DataNascimento).ToString("yyyy/MM/dd");
            string sql = $"INSERT INTO Usuario(Nome, Email, Senha, DataNascimento) VALUES('{Nome}','{Email}', '{Senha}', '{dataNascimento}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
