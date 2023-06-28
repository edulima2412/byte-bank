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
        static void CriarArquivo()
        {
            var caminhoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Create))
            {
                var contaString = "456,78954,2345.40,Jose Silva";

                var enconding = Encoding.UTF8;

                var bytes = enconding.GetBytes(contaString);
                
                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoWriter()
        {
            var caminhoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write("456,78954,2345.40,Maria Silva");
            }
        }
    }
}
