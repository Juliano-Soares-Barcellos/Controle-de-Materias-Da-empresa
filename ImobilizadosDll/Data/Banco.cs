﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadosDll.Data
{
    public class Banco
    {
        private string ConexaoPlanilhas = "Data Source=localhost;Username=root;Password=;Database=planilhas;";
        public MySqlConnection conexao()
        {
            return new MySqlConnection(ConexaoPlanilhas);
        }
    }
}
