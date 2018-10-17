using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiVitechd.Models
{
    public class ApiContext
    {
        public string ConnectionString { get; set; }
        public ApiContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public IEnumerable<Cliente> AllClientes
        {
            get
            {
                List<Cliente> clientes = new List<Cliente>();
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("Select * from clientes", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente()
                            {
                                id = Convert.ToInt32(reader["Id"]),
                                nombre = Convert.ToString(reader["nombre"]),
                                tipo_identificacion = Convert.ToInt64(reader["tipo_identificacion"]),
                                numero_identificacion = Convert.ToInt64(reader["numero_identificacion"])
                            });
                        }
                    }
                }
                return clientes;
            }
        }
    }
}
