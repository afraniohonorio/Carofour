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
                return @"SELECT Id, Nome, Descricao, Preco, UrlImagem FROM Produto";
            }
        }

        protected override string SqlSelectPorId
        {
            get
            {
                return @"SELECT Id, Nome, Descricao, Preco, UrlImagem FROM Produto WHERE Id = ?Id";
            }
        }

        protected override string SqlDelete
        {
            get { return "DELETE FROM Produto WHERE Id = ?Id"; }
        }

        protected override Produto MapearEntidade(DataRow row)
        {
            Produto vo = new Produto();
            vo.descricao = Convert.ToString(row["Descricao"]);
            vo.id = Convert.ToInt32(row["Id"]);
            vo.nome = Convert.ToString(row["Nome"]);
            vo.preco = Convert.ToDouble(row["Preco"]);
            vo.urlImagem = Convert.ToString(row["UrlImagem"]);
            return vo;
        }
    }
}