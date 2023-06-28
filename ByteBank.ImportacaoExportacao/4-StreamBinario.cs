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
        static void EscritaBinaria()
        {
            var caminhoArquivo = "contaCorrente.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Create))
            using (var escritor = new BinaryWriter(fluxoDeArquivo))
            {
                escritor.Write(412);
                escritor.Write(213452);
                escritor.Write(2541.50);
                escritor.Write("Maria Silva");
            }
        }

        static void LeituraBinaria()
        {
            using (var fluxoDeArquivo = new FileStream("contaCorrente.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fluxoDeArquivo))
            {
                var agencia = leitor.ReadInt32();
                var conta = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Console.WriteLine($"{agencia}/{conta} {titular}:{saldo}");
            }
        }
    }
}
