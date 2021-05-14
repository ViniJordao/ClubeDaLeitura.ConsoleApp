using System;
using System.Collections.Generic;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorBase
    {
        const int CAPACIDADE_REGISTROS = 100;

        protected object[] registros;

        protected object[] SelecionarTodosRegistros()
        {
            object[] registrosAux = new object[QtdRegistrosCadastrados()];

            int i = 0;

            foreach (object registro in registros)
            {
                if (registro != null)
                    registrosAux[i++] = registro;
            }

            return registrosAux;
        }
        protected int QtdRegistrosCadastrados()
        {
            int numeroRegistrosCadastrados = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    numeroRegistrosCadastrados++;
                }
            }

            return numeroRegistrosCadastrados;
        }
        protected int ObterPosicaoVaga()
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        protected int ObterPosicaoOcupada(object obj)
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj)) //editando...
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public object SelecionarRegistroPorId(object obj)
        {
            object registro = null;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    registro = registros[i];

                    break;
                }
            }

            return registro;
        }
        protected bool ExcluirRegistro(object obj)
        {
            bool excluiu = false;

            for (int i = 0; i < registros.Length; i++)
            {
                object registro = registros[i];

                if (registro != null && registro.Equals(obj)) //registro.id == id
                {
                    registros[i] = null;
                    excluiu = true;
                    break;
                }
            }
            return excluiu;
        }
    }
}
