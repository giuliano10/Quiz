using System;
using System.Collections.Generic;

class Program
{
    class Pergunta
    {
        public string Texto { get; set; }
        public List<string> Opcoes { get; set; }
        public int RespostaCorreta { get; set; }

        public Pergunta(string texto, List<string> opcoes, int respostaCorreta)
        {
            Texto = texto;
            Opcoes = opcoes;
            RespostaCorreta = respostaCorreta;
        }

        public bool FazerPergunta()
        {
            Console.WriteLine(Texto);
            for (int i = 0; i < Opcoes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Opcoes[i]}");
            }

            Console.Write("Escolha uma opção: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int respostaUsuario) &&
                respostaUsuario >= 1 && respostaUsuario <= 4)
            {
                if (respostaUsuario - 1 == RespostaCorreta)
                {
                    Console.WriteLine(" Correto\n");
                    return true;
                }
                else
                {
                    Console.WriteLine($" Errado. A resposta correta era: {Opcoes[RespostaCorreta]}\n");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida!\n");
            }

            return false;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine(" QUIZ DO MICHAEL JACKSON \n");

        List<Pergunta> perguntas = new List<Pergunta>()
        {
            new Pergunta(
                "1. Qual dessas músicas é do Michael Jackson?",
                new List<string>() { "Like a Prayer", "Thriller", "Purple Rain", "Imagine" },
                1
            ),
            new Pergunta(
                "2. Em que ano foi lançado o álbum 'Bad'?",
                new List<string>() { "1987", "1982", "1991", "1979" },
                0
            ),
            new Pergunta(
                "3. Qual é o nome do passo de dança de Michael Jackson?",
                new List<string>() { "Breakdance", "Moonwalk", "Robot", "Spin Drop" },
                1
            ),
            new Pergunta(
                "4. Qual era o nome do rancho onde Michael Jackson morou?",
                new List<string>() { "Neverland", "Wonderland", "Graceland", "Dreamland" },
                0
            ),
            new Pergunta(
                "5. Qual clipe musical é conhecido por ter zumbis dançando?",
                new List<string>() { "Smooth Criminal", "Bad", "Thriller", "Beat It" },
                2
            )
        };

        int pontuacao = 0;

        foreach (var pergunta in perguntas)
        {
            if (pergunta.FazerPergunta())
            {
                pontuacao++;
            }
        }

        Console.WriteLine($" Fim do quiz! Você acertou {pontuacao} de {perguntas.Count} perguntas.");
        Console.WriteLine(pontuacao >= 4 ? " Você é um fã de verdade!" : " Continue ouvindo Michael!");
    }
}
