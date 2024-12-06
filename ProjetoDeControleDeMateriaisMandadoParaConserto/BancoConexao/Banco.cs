using MySql.Data.MySqlClient;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.BancoConexao
{
    class Banco
    {
        private string ConexaoPlanilhas = "Data Source=localhost;Username=root;Password=;Database=planilhas;";
        private string ConexaoPcs = "Data Source=localhost;Username=root;Password=;Database=pcs;";
        public MySqlConnection Conexao()
        {
            return new MySqlConnection(ConexaoPlanilhas);
        }

        public MySqlConnection Conexaopcs()
        {
            return new MySqlConnection(ConexaoPcs);
        }
    }
}
