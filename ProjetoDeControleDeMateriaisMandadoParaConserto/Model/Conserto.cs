using System;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Model
{
    class Conserto
    {
        public int id { get; set; }

        public DateTime Data { get; set; }

        public Produto Produto_id { get; set; }

        public Conserto()
        {
            Produto_id = new Produto(); // Inicializa a propriedade Produto_id
        }
    }
}
