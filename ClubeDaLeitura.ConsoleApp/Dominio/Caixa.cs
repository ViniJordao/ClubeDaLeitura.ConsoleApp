using System;
using System.Collections.Generic;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Caixa
    {
        public int id;
        public string cor;
        public string etiqueta;
        public int numero;

        public Caixa()
        {
            id = GeradorId.GerarIdCaixa();
        }

        public Caixa(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";
            return resultadoValidacao;
        }
    }
}

