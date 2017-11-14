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
    public class BLLCategoria
    {
        private DALConexao conexao;
        public BLLCategoria(DALConexao conexao)
        {
            this.conexao = conexao;
        }

        public void Incluir(ModeloCategoria categoria)
        {
            if (categoria.cat_nome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatório!");
            }
            else
            {
                categoria.cat_nome.ToUpper();
                DALCategoria insert = new DALCategoria(conexao);
                insert.Incluir(categoria);
            }
        }
        public void Alterar(ModeloCategoria categoria)
        {
            if (categoria.cat_cod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório!");
            }
            else if (categoria.cat_nome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatório!");
            }
            else
            {
                categoria.cat_nome.ToUpper();
                DALCategoria alter = new DALCategoria(conexao);
                alter.Alterar(categoria);
            }
        }
        public void Excluir(int codigo)
        {
            DALCategoria delete = new DALCategoria(conexao);
            delete.Excluir(codigo);
        }
        public DataTable Localizar(String valor)
        {
            DALCategoria search = new DALCategoria(conexao);
            return search.Localizar(valor);
        }

        public ModeloCategoria CarregaMOdeloCategoria(int codigo)
        {
            DALCategoria load = new DALCategoria(conexao);
            return load.CarregaModeloCategoria(codigo);
        }
    }
}
