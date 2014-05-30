using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carofour.Models;
using System.Data;

namespace Carofour.DAO
{
    public class PedidoDAO : GenericoDAO<Pedido>
    {
        protected override string SqlSelect
        {
            get
            {
                return @"SELECT Id, Data, IdCliente FROM Pedido";
            }
        }

        protected override string SqlSelectPorId
        {
            get
            {
                return @"SELECT Id, Data, IdCliente FROM Pedido WHERE Id = ?Id";
            }
        }

        protected override string SqlDelete
        {
            get { return "DELETE FROM Pedido WHERE Id = ?Id"; }
        }

        public int InserirPedido(int idCliente)
        {
            try
            {
                string query = @"
                    INSERT INTO 
                        PEDIDO
                            (DATA, IDCLIENTE)
                        VALUES
                            (?DATA, ?IDCLIENTE);

                    SELECT LAST_INSERT_ID() as ID";

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("DATA", DateTime.Now);
                parametros.Add("IDCLIENTE", idCliente);

                DataSet ds = BaseDAO.ExecutarQuery(query, parametros);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    return Convert.ToInt32(row["ID"]);
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public PedidoView ObterDetalhesPedido(int idPedido)
        {
            string query = @"
                    SELECT p.Id, c.Nome, c.Endereco, c.Email, c.Telefone
                    FROM pedido p
                    INNER JOIN cliente c on p.idcliente = c.id
                    WHERE p.Id = ?IdPedido;";


            List<PedidoView> itens = new List<PedidoView>();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("IdPedido", idPedido);

            DataSet ds = BaseDAO.ExecutarQuery(query, parametros);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                PedidoView vo = MapearDetalhesPedido(row);

                itens.Add(vo);
            }

            return itens.FirstOrDefault();
        }

        public List<Produto> ObterItensPedido(int idPedido)
        {
            string query = @"
                SELECT P.NOME, P.DESCRICAO, P.PRECO, I.Quantidade
                FROM item_pedido I
                INNER JOIN PRODUTO P ON P.Id = I.IdProduto
                WHERE I.IdPedido = ?IdPedido;";


            List<Produto> itens = new List<Produto>();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("IdPedido", idPedido);

            DataSet ds = BaseDAO.ExecutarQuery(query, parametros);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Produto vo = MapearItensPedido(row);

                itens.Add(vo);
            }

            return itens;
        }

        protected Produto MapearItensPedido(DataRow row)
        {
            Produto vo = new Produto();

            vo.nome = Convert.ToString(row["NOME"]);
            vo.descricao = Convert.ToString(row["DESCRICAO"]);
            vo.preco = Convert.ToDouble(row["PRECO"]);
            vo.quantidade = Convert.ToInt32(row["Quantidade"]);

            return vo;
        }

        protected PedidoView MapearDetalhesPedido(DataRow row)
        {
            PedidoView vo = new PedidoView();
            vo.idPedido = Convert.ToInt32(row["Id"]);
            vo.nomeCompletoCliente = Convert.ToString(row["Nome"]);
            vo.enderecoCliente = Convert.ToString(row["Endereco"]);
            vo.emailCliente = Convert.ToString(row["Email"]);
            vo.telefoneCliente = Convert.ToString(row["Telefone"]);

            vo.listaProdutos = this.ObterItensPedido(vo.idPedido);

            return vo;
        }

        protected override Pedido MapearEntidade(DataRow row)
        {
            Pedido vo = new Pedido();

            vo.data = Convert.ToDateTime(row["DATA"]);
            vo.id = Convert.ToInt32(row["ID"]);
            vo.idCliente = Convert.ToInt32(row["IDCLIENTE"]);

            return vo;
        }
    }
}