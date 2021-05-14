using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Controladores;
using System.Collections.Generic;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaCrianca : TelaBase
    {
        private ControladorCrianca controladorCrianca;
        public TelaCrianca(ControladorCrianca controlador)
            : base("Cadastro de Crianca")
        {
            controladorCrianca = controlador;
        }

        public override void CadastraRegistro()
        {
            ConfigurarTela("Inserindo um nova crianca...");

            bool gravou = GravarCrianca(0);

            if (gravou)
                ApresentarMensagem("Amiguinho inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir um Amiguinho ", TipoMensagem.Erro);
                CadastraRegistro();
            }
        }

        public override void EditarRegistro()
        {
            ConfigurarTela("Editando um Amiguinho ...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do Amiguinho  que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool gravou = GravarCrianca(id);

            if (gravou)
                ApresentarMensagem("Amiguinho editado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar o Amiguinho ", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public override void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um Amiguinho ...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do Amiguinho que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool excluiu = controladorCrianca.ExcluirCrianca(idSelecionado);

            if (excluiu)
                ApresentarMensagem("Amiguinho excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir o Amiguinho ", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Amiguinho ...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35} | {3,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Crianca[] crianca = controladorCrianca.SelecionarTodasCriancas();

            if (crianca.Length == 0)
            {
                ApresentarMensagem("Nenhuma Amiguinho cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < crianca.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   crianca[i].id, crianca[i].nome, crianca[i].nome, crianca[i].nomeDoResponsavel, crianca[i].telefone, crianca[i].ondeEh);
            }
        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Tipo Coleção", "Nuemero Edição", "Ano da Revista", "Caixa onde está");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarCrianca(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o tipo da coleção: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a caixa onde está: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o ano do revista: ");
            int telefone = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a caixa onde está: ");
            string ondeEh = Console.ReadLine();

            resultadoValidacao = controladorCrianca.RegistrarCrianca(id, nome, nomeResponsavel, telefone, ondeEh);

            if (resultadoValidacao != "CRIANCA_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }



        #endregion
    }
}
