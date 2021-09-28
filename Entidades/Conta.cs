using DIO.Bank.Enum;
using System;

namespace DIO.Bank.Entidades
{
    public class Conta
    {
        private string Nome { get; set; }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        
        public Conta(string nome, TipoConta tipoConta, double saldo, double credito)
        {
            this.Nome = nome;
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public bool Sacar (double valorSaque)
        {
            if (Saldo - valorSaque < (Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);

            return true;
		}

        public void Depositar(double valorDeposito)
		{
			Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
		}

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(Sacar(valorTransferencia))
            contaDestino.Depositar(valorTransferencia);
        }

        public override string ToString()
        {
            return "Nome: " + Nome + " | Tipo da Conta: " + TipoConta + " | Saldo: " + Saldo + " | Crédito: " + Credito;
        }
    }
}