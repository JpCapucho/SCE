using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALSubCategoria
    {
        private DALConexao conexao;

        public DALSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloSubCategoria subcategoria)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into subcategoria(cat_cod, scat_nome) values (@catcod, @nome); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@catcod", subcategoria.cat_cod);
                cmd.Parameters.AddWithValue("@nome", subcategoria.subcat_nome);
                conexao.Conectar();
                subcategoria.subcat_cod = Convert.ToInt32(cmd.ExecuteScalar());
                conexao.Desconectar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Alterar(ModeloSubCategoria subCategoria)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update subcategoria set scat_nome = @nome, cat_cod = @catcod where scat_cod = @scatcod;";
                cmd.Parameters.AddWithValue("@nome", subCategoria.subcat_nome);
                cmd.Parameters.AddWithValue("@catcod", subCategoria.cat_cod);
                cmd.Parameters.AddWithValue("@scatcod", subCategoria.subcat_cod);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Exluir(int codigo)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexao.ObjetoConexao;
                sqlCommand.CommandText = "delete from subcategoria where scat_cod = @codigo";
                sqlCommand.Parameters.AddWithValue("@codigo", codigo);
                conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public DataTable Localizar(String valor)
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from subcategoria where scat_nome like '%" +
                    valor + "%'", conexao.StringConexao);
                adapter.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModeloSubCategoria CarregaModeloSubCategoria(int codigo)
        {
            try
            {
                ModeloSubCategoria subCategoria = new ModeloSubCategoria();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexao.ObjetoConexao;
                sqlCommand.CommandText = "select * from subcategoria where scat_cod = @codigo";
                sqlCommand.Parameters.AddWithValue("@codigo", codigo);
                conexao.Conectar();
                SqlDataReader registro = sqlCommand.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    subCategoria.cat_cod = Convert.ToInt32(registro["cat_cod"]);
                    subCategoria.subcat_nome = Convert.ToString(registro["cat_nome"]);
                    subCategoria.subcat_cod = Convert.ToInt32(registro["scat_cod"]);
                }
                conexao.Desconectar();
                return subCategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}
