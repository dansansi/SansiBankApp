using System; //Usando dependencias

namespace Banco //Namespace para o primeiro banco
{
    public class ContaBancaria //criação da classe e dos metodos da conta bancaria
    {
        public string Titular { get; set; } //metodo get para ler os dados da string, set para alterar os dados da string
        public decimal Saldo { get; private set; }

        public ContaBancaria(string titular, decimal saldoInicial) //construtor para criação da conta bancaria
        {
            Titular = titular; //linha para receber o nome do titular inputado pelo usuario
            Saldo = saldoInicial; //linha para definir o saldo inicial inputado pelo usuario
        }

        public void Depositar(decimal valor) //metodo de depósito
        {
            if (valor <= 0) // se valor menor ou igual a zero, valor do deposito invalido
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");

            Saldo += valor; //adiciona o valor depositado ao saldo
            Console.WriteLine($"Depósito de R${valor:F2} realizado. Saldo atual: R${Saldo:F2}");
        }

        public void Retirar(decimal valor) //metodo de saque
        {
            if (valor <= 0) //se valor menor ou igual a zero, invalido
                throw new ArgumentException("O valor do saque deve ser maior que zero.");
            if (valor > Saldo) //se valor maior que saldo, invalido
                throw new ArgumentException($"Saldo insuficiente para completar, saldo atual é R${Saldo:F2}");

            Saldo -= valor; //subtrai valor sacado do saldo total
            Console.WriteLine($"Retirada de R${valor:F2} realizada com sucesso. Saldo atual: R${Saldo:F2}");
        }
        public decimal ObterSaldo()
        {
            return Saldo; //retorna o valor de saldo atual
        }

        public class Investimento
        {
            public decimal TaxaRetornoAnual { get; set; }
            public Investimento(decimal taxaRetornoAnual) //Construtor para inicializar a classe
            {
                TaxaRetornoAnual = taxaRetornoAnual;
            }
        
        public decimal SimularRetorno(decimal valorInvestido, int anos)
        
            { return valorInvestido * (decimal)Math.Pow((1 + (double)TaxaRetornoAnual), anos); } 
        }
    }
}