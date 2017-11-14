using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLSubCategoria
    {
        private DALConexao conexao;

        public BLLSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloSubCategoria modeloSubCategoria)
        {
            try
            {
                if (modeloSubCategoria.subcat_nome.Trim().Length == 0)
                {
                    throw new Exception("O nome da categoria é obrigatório!");
                }
                if (modeloSubCategoria.cat_cod <= 0)
                {
                    throw new Exception("O codigo da categoria é obrigátorio!");
                }

                DALSubCategoria dALSub = new DALSubCategoria(conexao);
                dALSub.Incluir(modeloSubCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(ModeloSubCategoria modeloSubCategoria)
        {
            try
            {
                if (modeloSubCategoria.subcat_nome.Trim().Length == 0)
                {
                    throw new Exception("O nome da subcategoria é obrigatorio");
                }
                if (modeloSubCategoria.cat_cod <= 0)
                {
                    throw new Exception("O codigo da categoria é obrigatorio");
                }
                if (modeloSubCategoria.subcat_cod <= 0)
                {
                    throw new Exception("O codigo da subcategoria é obrigatorio");
                }
                DALSubCategoria dALSubCategoria = new DALSubCategoria(conexao);
                dALSubCategoria.Alterar(modeloSubCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Exluir(int codigo)
        {
            DALSubCategoria dALSubCategoria = new DALSubCategoria(conexao);
            dALSubCategoria.Exluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALSubCategoria dALSubCategoria = new DALSubCategoria(conexao);
            return dALSubCategoria.Localizar(valor);
        }

        public ModeloSubCategoria CarregaModeloSubcategoria(int codigo)
        {
            DALSubCategoria dALSubCategoria = new DALSubCategoria(conexao);
            return dALSubCategoria.CarregaModeloSubCategoria(codigo);
        }
    }
}