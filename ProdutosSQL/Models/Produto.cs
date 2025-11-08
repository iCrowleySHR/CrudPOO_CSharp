using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosSQL.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome_Produto { get; set; }
        public decimal Preco_Desconto { get; set; }
        public decimal Preco_Normal { get; set; }
    }
}
