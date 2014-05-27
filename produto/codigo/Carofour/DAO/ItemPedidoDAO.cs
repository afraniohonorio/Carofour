using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carofour.Models;
using System.Data;

namespace Carofour.DAO
{
    public class ItemPedidoDAO : GenericoDAO<ItemPedido>
    {
        protected override string SqlSelect
        {
            get
            {
                return @"SELECT Id, IdProduto, Quantidade, IdPedido FROM Item_Pedido";
            }
        }

        protected override string SqlSelectPorId
        {
            get
            {
                return @"SELECT Id, IdProduto, Quantidade, IdPedido FROM Item_Pedido WHERE Id = ?Id";
            }
        }

        protected override string SqlDelete
        {
            get { return "DELETE FROM Item_Pedido WHERE Id = ?Id"; }
        }

        public bool InserirItemPedido(ItemPedido vo)
        {
            try
            {
                string query = @"
                    INSERT INTO 
                        ITEM_PEDIDO
                            (IDPRODUTO, QUANTIDADE, IDPEDIDO)
                        VALUES
                            (?IDPRODUTO, ?QUANTIDADE, ?IDPEDIDO);";

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("IDPRODUTO", vo.idProduto);
                parametros.Add("QUANTIDADE", vo.quantidade);
                parametros.Add("IDPEDIDO", vo.idPedido);

                BaseDAO.ExecutarComando(query, parametros);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected override ItemPedido MapearEntidade(DataRow row)
        {
            ItemPedido vo = new ItemPedido();
            vo.id = Convert.ToInt32(row["Id"]);
            vo.idPedido = Convert.ToInt32(row["IdPedido"]);
            vo.quantidade = Convert.ToInt32(row["Quantidade"]);
            vo.idProduto = Convert.ToInt32(row["IdProduto"]);

            return vo;
        }
    }
}