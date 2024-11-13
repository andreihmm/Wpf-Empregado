using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Empregado
    {

        public int Matricula { get; set; } = 0;
        public string CPF { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public Empregado() { }

        public Empregado(int matricula, string cPF, string nome, string endereco)
        {
            Matricula = matricula;
            CPF = cPF;
            Nome = nome;
            Endereco = endereco;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Salvar(SqlConnection conexao) 
        {
            Console.WriteLine("== Salvando empregado..... ==");
            var Cmd = conexao.CreateCommand();
            Cmd.CommandText = "INSERT INTO Empregado (Cpf, Nome, Endereco) VALUES (@cpf, @nome, @endereco)";

            Cmd.Parameters.Add(new SqlParameter("cpf", CPF));
            Cmd.Parameters.Add(new SqlParameter("nome", Nome));
            Cmd.Parameters.Add(new SqlParameter("endereco", Endereco));

            Cmd.ExecuteNonQuery();

        }
        public void Pesquisar() { }

        public void Excluir() { }


    }
}
