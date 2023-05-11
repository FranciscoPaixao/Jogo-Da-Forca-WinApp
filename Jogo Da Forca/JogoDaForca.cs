using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_Da_Forca
{
    internal class JogoDaForca
    {
        private String[] apenasPalavras;
        private string palavraSorteada;
        private Char[] resultado;
        private int tentativas;
        private bool statusErro;
        private String[] listaImagens;
        public JogoDaForca()
        {
            tentativas = 0;
            apenasPalavras = new String[] { "casa", "carro", "moto", "bicicleta", "computador", "notebook", "celular", "tablet", "teclado", "mouse", "monitor" };
            resultado = "_".ToCharArray();
            listaImagens = new String[] { "https://www.cjdinfo.com.br/images/diversao/forca/vazia.png", "https://www.cjdinfo.com.br/images/diversao/forca/cabeca.png", "https://www.cjdinfo.com.br/images/diversao/forca/corpo.png", "https://www.cjdinfo.com.br/images/diversao/forca/braco1.png", "https://www.cjdinfo.com.br/images/diversao/forca/braco2.png", "https://www.cjdinfo.com.br/images/diversao/forca/perna1.png", "https://www.cjdinfo.com.br/images/diversao/forca/perna2.png", "https://www.cjdinfo.com.br/images/diversao/forca/morto.png" };
            statusErro = true;
        }
        public void SortearPalavra()
        {
            Random random = new Random();
            int indice = random.Next(0, apenasPalavras.Length);
            palavraSorteada = apenasPalavras[indice];
            String preencheUnderline = "";
            this.resultado = preencheUnderline.PadLeft(palavraSorteada.Length, '_').ToCharArray();
            tentativas = 0;
        }
        public void CompararPalavra(string letra)
        {
            letra = letra.ToLower();
            statusErro = true;
            if (palavraSorteada.Contains(letra))
            {
                for (int i = 0; i < palavraSorteada.Length; i++)
                {
                    if (palavraSorteada[i] == letra[0])
                    {
                        resultado[i] = letra[0];
                    }
                }
                statusErro = false;
            }
            if (statusErro)
            {
                tentativas++;
            }
        }
        public string ObterResultadoFormatado()
        {
            string tempresultadoStr = new string(resultado);
            string resultadoStr = "";
            for (int i = 0; i < tempresultadoStr.Length; i++)
            {
                resultadoStr += tempresultadoStr[i] + " ";
            }
            return resultadoStr;
        }
        public String ObterResultado() => new string(resultado);
        public String ObterImagem() => listaImagens[tentativas];
        public int ObterTentativas() =>  tentativas;
        public String ObterPalavraSorteada() => palavraSorteada;
    }
}
