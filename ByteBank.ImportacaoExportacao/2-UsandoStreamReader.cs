using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.ImportacaoExportacao
{
    partial class Program
    {
        static void UsandoStreamReader()
        {
            var enderecoArquivo = "contas.txt";

            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();

                    var contaCorrente = ConvertStringParaContaCorrente(linha);

                    Console.WriteLine($"Conta: {contaCorrente.Numero}, Agencia: {contaCorrente.Agencia}, Saldo: {contaCorrente.Saldo}, Titular: {contaCorrente.Titular.Nome}");
                }
            }
        }

        static ContaCorrente ConvertStringParaContaCorrente(string linha)
        {
            string[] campos = linha.Split(',');

            var agencia = int.Parse(campos[0]);
            var conta = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.', ','));
            var nomeTitular = campos[3];

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agencia, conta);
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado;
        }
    }
}
