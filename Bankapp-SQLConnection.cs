using System;
using Microsoft.Data.SqlClient;

namespace BancoSQL;

public class BancoSQL //classe do banco
{
    private string conexaosql = "Server=localhost\\BancoSQL;Database=[Banco do Zeca];Trusted_Connection=True;"; //string padrão de conexão
    public void InserirContaBancaria(string titular) //metodo para inserir titular e saldo bancario
    {
        using (SqlConnection conn = new SqlConnection(conexaosql)) //
        {
            try
            {
                conn.Open();

                string query = "Insert Into ContaBancaria (titular, saldo) values (@Titular, 0)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Titular", titular);
                    cmd.Parameters.AddWithValue("@Saldo", 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

        }
    }


    public decimal ObterSaldo(int id)
    {
        SqlConnection conn = new SqlConnection(conexaosql);
        {
            try
            {
                conn.Open();
                string query = "Select Saldo From Contabancaria where id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                        return Convert.ToDecimal(resultado);
                    else
                        return 0;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return 0;

            }
        }
    }
}
        

