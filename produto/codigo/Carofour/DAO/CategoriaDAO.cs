using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carofour.Models;
using System.Data;

namespace Carofour.DAO
{
    public class CategoriaDAO : GenericoDAO<Categoria>
    {
        protected override string SqlSelect
        {
            get
            {
                return @"SELECT Id, Nome, UrlImagem, Href FROM Categoria";
            }
        }

        protected override string SqlSelectPorId
        {
            get
            {
                return @"SELECT Id, Nome, UrlImagem, Href FROM Categoria WHERE Id = ?Id";
            }
        }

        protected override string SqlDelete
        {
            get { return "DELETE FROM Categoria WHERE Id = ?Id"; }
        }

        protected override Categoria MapearEntidade(DataRow row)
        {
            Categoria vo = new Categoria();
            vo.href = Convert.ToString(row["Href"]);
            vo.id = Convert.ToInt32(row["Id"]);
            vo.nome = Convert.ToString(row["Nome"]);
            vo.urlImagem = Convert.ToString(row["UrlImagem"]);
            return vo;
        }
    }
}