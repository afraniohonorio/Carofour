using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carofour.Models;
using System.Data;

namespace Carofour.DAO
{
    public class ProdutoDAO : GenericoDAO<Produto>
    {
        protected override string SqlSelect
        {
            get
            {
                return @"SELECT Id, Nome, Descricao, Preco, Url_Imagem FROM Produto";
            }
        }

        protected override string SqlSelectPorId
        {
            get
            {
                return @"SELECT Id, Nome, Descricao, Preco, Url_Imagem FROM Produto WHERE Id = ?Id";
            }
        }

        protected override string SqlDelete
        {
            get { return "DELETE FROM Produto WHERE Id = ?Id"; }
        }

        public List<Produto> ObterPorCategoria(int idCategoria)
        {
            string query = @"
                    SELECT 
                        Id, 
                        Nome, 
                        Descricao, 
                        Preco, 
                        Url_Imagem 
                    FROM 
                        Produto 
                    WHERE IdCategoria = ?IdCategoria";


            List<Produto> items = new List<Produto>();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("IdCategoria", idCategoria);

            DataSet ds = BaseDAO.ExecutarQuery(query, parametros);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Produto vo = MapearEntidade(row);

                items.Add(vo);
            }

            return items;
        }

        protected override Produto MapearEntidade(DataRow row)
        {
            Produto vo = new Produto();
            vo.descricao = Convert.ToString(row["Descricao"]);
            vo.id = Convert.ToInt32(row["Id"]);
            vo.nome = Convert.ToString(row["Nome"]);
            vo.preco = Convert.ToDouble(row["Preco"]);
            vo.urlImagem = Convert.ToString(row["Url_Imagem"]);
            return vo;
        }
    }
}