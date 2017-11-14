using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALCategoria
    {
        private DALConexao conexao;
        public DALCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCategoria categoria)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into categoria(cat_nome) values (@nome); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("nome", categoria.cat_nome);
                conexao.Conectar();
                categoria.cat_cod = Convert.ToInt32(cmd.ExecuteScalar());
                conexao.Desconectar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(ModeloCategoria categoria)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update categoria set cat_nome = @nome where cat_cod = @codigo;";
                cmd.Parameters.AddWithValue("@nome", categoria.cat_nome);
                cmd.Parameters.AddWithValue("@codigo", categoria.cat_cod);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete from categoria where cat_cod = @codigo;";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from categoria where cat_nome like '%" +
                valor + "%'", conexao.StringConexao);
            dataAdapter.Fill(tabela);
            return tabela;
        }

        public ModeloCategoria CarregaModeloCategoria(int codigo)
        {
            try
            {
                ModeloCategoria categoria = new ModeloCategoria();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "select * from categoria where cat_cod = @codigo";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                conexao.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                try
                {
                    if (registro.HasRows)
                    {
                        registro.Read();
                        categoria.cat_cod = Convert.ToInt32(registro["cat_cod"]);
                        categoria.cat_nome = Convert.ToString(registro["cat_nome"]);
                    }
                }catch (Exception ex)
                {
                    throw ex;
                }
                conexao.Desconectar();
                return categoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
