using System;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Model
{
    public class Produto
    {
        public int id { get; set; }
        public String Nome { get; set; }
        public String Numero { get; set; }
        public int quantidade_conserto { get; set; }
    }
}
