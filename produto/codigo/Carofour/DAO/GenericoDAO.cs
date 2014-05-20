using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Carofour.DAO
{
    public abstract class GenericoDAO<VO>
    {
        protected abstract string SqlSelect { get; }
        protected abstract string SqlSelectPorId { get; }
        protected abstract string SqlDelete { get; }

        public List<VO> ObterTodos()
        {
            List<VO> items = new List<VO>();

            DataSet ds = BaseDAO.ExecutarQuery(SqlSelect);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                VO vo = MapearEntidade(row);

                items.Add(vo);
            }

            return items;
        }

        public VO ObterPorId(int id)
        {
            VO vo = default(VO);

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("Id", id);

            DataSet ds = BaseDAO.ExecutarQuery(SqlSelectPorId, parametros);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                vo = MapearEntidade(row);
            }

            return vo;
        }

        public void Excluir(int id)
        {
            VO vo = default(VO);

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("Id", id);

            BaseDAO.ExecutarComando(SqlDelete, parametros);
        }

        protected abstract VO MapearEntidade(DataRow row);
    }
}