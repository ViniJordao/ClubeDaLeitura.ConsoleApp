using System;
using System.Collections.Generic;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    public class GeradorId
    {
        private static int idRevista = 0;

        private static int idCaixa = 0;

  

        public static int GerarIdRevista()
        {
            return ++idRevista;
        }
        public static int GerarIdCaixa()
        {
            return ++idCaixa;
        }
    }
}
