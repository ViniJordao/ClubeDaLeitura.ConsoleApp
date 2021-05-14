using System;
using System.Collections.Generic;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorEmprestimo : ControladorBase
    {
        public string RegistrarEmprestimo(int id, string nome, double preco,
           string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            Equipamento equipamento = null;

            int posicao;

            if (id == 0)
            {
                equipamento = new Equipamento();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Equipamento(id));
                equipamento = (Equipamento)registros[posicao];
            }

            equipamento.nome = nome;
            equipamento.preco = preco;
            equipamento.numeroSerie = numeroSerie;
            equipamento.dataFabricacao = dataFabricacao;
            equipamento.fabricante = fabricante;

            string resultadoValidacao = equipamento.Validar();

            if (resultadoValidacao == "EQUIPAMENTO_VALIDO")
                registros[posicao] = equipamento;

            return resultadoValidacao;
        }
    }
}
