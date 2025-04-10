using System;


class TesteDeMesa02
{

    static void Main()
    {
        int escolha = 0;

        do
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Escolha qual dos três exercício você quer que seja executado");
            Console.WriteLine("1 - Exercício 01");
            Console.WriteLine("2 - Exercício 02");
            Console.WriteLine("3 - Exercício 03");
            Console.WriteLine("4 - Exercício 04");
            Console.WriteLine("5 - Exercício 05");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("================================================");

            escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    Exercicio01();
                    break;
                case 2:
                    Exercicio02();
                    break;
                case 3:
                    Exercicio03();
                    break;
                case 4:
                    Exercicio04();
                    break;
                case 5:
                    Exercicio05();
                    break;
                case 0:
                    Console.WriteLine("Saindo do programa.");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        } while (escolha != 0);
    }

    static void Exercicio01()
    {
        decimal deposito;
        int meses;
        float taxa;
        decimal rendimento;


        Console.WindowHeight("Seja bem vindo a sua conta bancaria!");
        Console.WindowHeight("Vamos fazer uma simulação de redimento ao mês?");
        Console.WindowHeight("");

        do
        {
            Console.Window("Digite o valor que deseja depositar: ");
            string input = Console.ReadLine();

            if (decimal.TryParse(input, out deposito) && deposito > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Por favor, informe um valor positivo")
            }


        } while (true);
        do
        {
            Console.Window("Digite o valor da taxa do rendimento em %): ");
            string inputTaxa = Console.ReadLine()

        }

        /* for(int i = 0; i <= meses; i++) {
    }*/

}


    string inputTaxa = Console.ReadLine();
        
        // Tenta converter o valor inserido para float
        if (float.TryParse(inputTaxa, out taxa) && taxa >= 0)
        {
            break;  // Sai do loop se a taxa for válida
        }
        else
        {
            Console.WriteLine("Por favor, insira uma taxa válida.");
        }
    } while (true) ;