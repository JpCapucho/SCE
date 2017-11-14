using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloSubCategoria
    {
        public ModeloSubCategoria()
        {
            this.subcat_cod = 0;
            this.subcat_nome = "";
            this.cat_cod = 0;
        }

        public ModeloSubCategoria(int subcat_cod, int cat_cod, String subcat_nome)
        {
            this.subcat_cod = this.subcat_cod;
            this.subcat_nome = subcat_nome;
            this.cat_cod = cat_cod;
        }

        public int subcat_cod { get; set; }

        public String subcat_nome { get; set; }

        public int cat_cod { get; set; }
    }
}
