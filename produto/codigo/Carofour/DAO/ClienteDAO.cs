using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carofour.Models;
using System.Data;

namespace Carofour.DAO
{
    public class ClienteDAO : GenericoDAO<Cliente>
    {
        protected override string SqlSelect
        {
            get
            {
                return @"SELECT Id, Nome, Email, Senha, Data_Nascimento, Sexo, Endereco, Telefone FROM Cliente";
            }
        }

        protected override string SqlSelectPorId
        {
            get
            {
                return @"SELECT Id, Nome, Email, Senha, Data_Nascimento, Sexo, Endereco, Telefone FROM Cliente WHERE Id = ?Id";
            }
        }

        protected override string SqlDelete
        {
            get { return "DELETE FROM Cliente WHERE Id = ?Id"; }
        }

        public int InserirCliente(Cliente vo)
        {
            try
            {
                string query = @"
                    INSERT INTO 
                        CLIENTE
                            (Nome, Email, Senha, Data_Nascimento, Sexo, Endereco, Telefone)
                        VALUES
                            (?Nome, ?Email, ?Senha, ?Data_Nascimento, ?Sexo, ?Endereco, ?Telefone);

                    SELECT LAST_INSERT_ID() as ID";

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("Nome", vo.nomeCompleto);
                parametros.Add("Email", vo.email);
                parametros.Add("Senha", vo.senha);
                parametros.Add("Data_Nascimento", vo.dataNascimento);
                parametros.Add("Sexo", vo.sexo);
                parametros.Add("Endereco", vo.endereco);
                parametros.Add("Telefone", vo.telefone);

                DataSet ds = BaseDAO.ExecutarQuery(query, parametros);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    return Convert.ToInt32(row["ID"]);
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        protected override Cliente MapearEntidade(DataRow row)
        {
            Cliente vo = new Cliente();

            vo.dataNascimento = Convert.ToDateTime(row["DATA_NASCIMENTO"]);
            vo.email = Convert.ToString(row["EMAIL"]);
            vo.endereco = Convert.ToString(row["ENDERECO"]);
            vo.id = Convert.ToInt32(row["ID"]);
            vo.nomeCompleto = Convert.ToString(row["NOME"]);
            vo.senha = Convert.ToString(row["SENHA"]);
            vo.sexo = Convert.ToChar(row["SEXO"]);
            vo.telefone = Convert.ToString(row["TELEFONE"]);

            return vo;
        }
    }
}