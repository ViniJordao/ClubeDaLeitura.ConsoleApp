using System;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Telas;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Program
    {
         static void Main(string[] args)
        {
            ControladorRevista controladorRevista = new ControladorRevista();

            TelaRevista telaRevista = new TelaRevista(controladorRevista);

        

            while (true)
            {
                TelaBase telaSelecionada = telaPrincipal.ObterOpcao();

                if (telaSelecionada == null)
                    break;

                Console.Clear();

                Console.WriteLine(telaSelecionada.Titulo); Console.WriteLine();

               

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (opcao == "1")
                    telaSelecionada.CadastraRegistro();

                else if (opcao == "2")
                {
                    telaSelecionada.VisualizarRegistros();
                    Console.ReadLine();
                }

                else if (opcao == "3")
                    telaSelecionada.EditarRegistro();

                else if (opcao == "4")
                    telaSelecionada.ExcluirRegistro();

                Console.Clear();
            }
        }
    }
    }
}
