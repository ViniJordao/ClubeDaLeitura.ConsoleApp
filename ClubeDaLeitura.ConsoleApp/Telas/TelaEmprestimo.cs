using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Controladores;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaEmprestimo : TelaBase
    {
        private ControladorCrianca controladorCrianca;
        private ControladorEmprestimo controladoreEmprestimo;
        public TelaEmprestimo(ControladorEmprestimo controlador)
            : base("Cadastro de Crianca")
        {
            controladoreEmprestimo = controlador;
        }
        public override void CadastraRegistro()
        {
            ConfigurarTela("Inserindo um novo empréstimo");
            string opcao = "";
            Console.WriteLine("Já foi cadastrado um amigo? | S:sim ou N:não");

            if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                bool gravou = GravarEmprestimo(0);
            }
            else
            {
                return controladorCrianca.CadastrarCrianca();
            }
        }

        private bool GravarEmprestimo()
        {
            string resultadoValidacao;
            bool gravou = true;

            return gravou;
        }
    }
}
