using System;

class TesteDeMesa02
{
    static void Main()
    {
        int escolha = 0;

        do
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Deseja executar a simulação de rendimento?");
            Console.WriteLine("1 - Executar simulação");
            Console.WriteLine("2 - Executar simulação");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("================================================");

            if (!int.TryParse(Console.ReadLine(), out escolha))
            {
                Console.WriteLine("Entrada inválida! Por favor, digite um número.");
                continue;
            }

            if (escolha == 1)
            {
                Exercicio01();
            }
            if (escolha == 2)
            {
                Exercicio02();
            }
            else if (escolha == 0)
            {
                Console.WriteLine("Saindo do programa.");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }

        } while (true);
    }

    static void Exercicio01()
    {
        decimal deposito;
        int meses;
        decimal rendimentoMensal;
        decimal rendimentoLiquido = 0;
        decimal taxa;
        decimal rendimento;
        decimal rendimentoFinal;
        decimal rendAntesSaque = 0;
        int saque = 0;
        int saqueMes = 0;
        decimal valorDoSaque = 0;

        Console.WriteLine("\nSeja bem-vindo à sua conta bancária!");
        Console.WriteLine("Vamos fazer uma simulação de rendimento ao mês?\n");

        do
        {
            Console.Write("Digite o valor que deseja depositar: ");
            if (decimal.TryParse(Console.ReadLine(), out deposito) && deposito > 0)
                break;
            Console.WriteLine("Por favor, informe um valor positivo.");
        } while (true);

        do
        {
            Console.Write("Digite o valor da taxa do rendimento em (%): ");
            if (decimal.TryParse(Console.ReadLine(), out taxa) && taxa >= 0)
            {
                taxa /= 100;
                break;
            }
            Console.WriteLine("Por favor, insira uma taxa válida.");
        } while (true);

        do
        {
            Console.Write("Digite a quantidade de meses que você vai deixar o seu investimento rendendo: ");
            if (int.TryParse(Console.ReadLine(), out meses) && meses > 0)
                break;
            Console.WriteLine("Digite uma quantidade de meses válida.");
        } while (true);

        decimal[] valorMensalPreview = new decimal[meses + 1];
        rendimento = deposito;
        rendimentoLiquido = 0;

        Console.WriteLine("\n-------------------------------------------------------------------------------");
        Console.WriteLine(" Mês | Rend. Mês (R$) | Rend. Líq. (R$) | Saldo Rendimento (R$)");
        Console.WriteLine("-------------------------------------------------------------------------------");

        for (int i = 1; i <= meses; i++)
        {
            decimal anterior = rendimento;
            rendimento += rendimento * taxa;
            rendimentoMensal = rendimento - anterior;
            rendimentoLiquido += rendimentoMensal;
            valorMensalPreview[i] = rendimento;

            Console.WriteLine($" {i,3} | {rendimentoMensal,13:F2} | {rendimentoLiquido,14:F2} | {rendimento,21:F2}");
        }

        rendimentoFinal = rendimento;
        decimal rendimentoTotalBruto = rendimentoFinal - deposito;
        Console.WriteLine("-------------------------------------------------------------------------------");
        Console.WriteLine($"\nSe você não fizer nenhuma retirada, seu saldo final será de: R$ {rendimentoFinal:F2}");
        Console.WriteLine($"Rendimento total ao final de {meses} meses: R$ {rendimentoTotalBruto:F2}");
        Console.WriteLine("-------------------------------------------------------------------------------");

        do
        {
            Console.Write($"\nVocê deseja fazer uma retirada antes do final do {meses}º mês? (s/n): ");
            string inputSaque = Console.ReadLine().Trim().ToLower();

            if (inputSaque == "s")
            {
                saque = 1;

                while (true)
                {
                    Console.Write($"Informe o mês (1 a {meses}) que deseja fazer a retirada: ");
                    if (int.TryParse(Console.ReadLine(), out saqueMes) && saqueMes >= 1 && saqueMes <= meses)
                        break;
                    Console.WriteLine("Mês inválido. Tente novamente.");
                }

                while (true)
                {
                    Console.Write("Informe o valor que deseja retirar: ");
                    if (decimal.TryParse(Console.ReadLine(), out valorDoSaque) && valorDoSaque > 0 && valorDoSaque <= deposito)
                        break;
                    Console.WriteLine("Valor inválido. Informe um valor positivo ou <= ao valor que você depositou.");
                }

                break;
            }
            else if (inputSaque == "n")
            {
                saque = 0;
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Digite 's' para sim ou 'n' para não.");
            }
        } while (true);


        switch (saque)
        {
            case 0:
                {

                    break;
                }

            case 1:
                {
                    decimal[] valorMensal = new decimal[meses + 1];
                    rendimento = deposito;
                    rendimentoLiquido = 0;

                    Console.WriteLine("\n-------------------------------------------------------------------------------");
                    Console.WriteLine(" Mês | Rend. Mês (R$) | Rend. Líq. (R$) | Saldo (R$)       | Saque (R$)   | Pós-Saque (R$)");
                    Console.WriteLine("-------------------------------------------------------------------------------");

                    for (int i = 1; i <= meses; i++)
                    {
                        decimal rendimentoAnterior = rendimento;
                        rendimento += rendimento * taxa;

                        rendimentoMensal = rendimento - rendimentoAnterior;
                        rendimentoLiquido += rendimentoMensal;

                        decimal saldoAntesDoSaque = rendimento;

                        if (i == saqueMes)
                        {
                            rendAntesSaque = rendimento;
                            rendimento -= valorDoSaque;
                            if (rendimento < 0) rendimento = 0;

                            Console.WriteLine($" {i,3} | {rendimentoMensal,13:F2} | {rendimentoLiquido,14:F2} | {saldoAntesDoSaque,15:F2} | {valorDoSaque,11:F2} | {rendimento,15:F2}");
                        }
                        else
                        {
                            Console.WriteLine($" {i,3} | {rendimentoMensal,13:F2} | {rendimentoLiquido,14:F2} | {rendimento,15:F2} | {"-",11} | {"-",15}");
                        }

                        valorMensal[i] = rendimento;
                    }

                    rendimentoFinal = rendimento + valorDoSaque;
                    if (rendimentoFinal < 0) rendimentoFinal = 0;
                    taxa *= 100;

                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine($"\nO valor final após {meses} meses com taxa de {taxa:F2}% ao mês, foi de: R${rendimento:F2}");
                    Console.WriteLine($"Ao somar com o valor de saque que foi de R${valorDoSaque:F2}, temos o valor final de R${rendimentoFinal:F2}");
                    Console.WriteLine($"Com o rendimento líquido de: R${rendimentoLiquido:F2} ");
                    Console.WriteLine("-------------------------------------------------------------------------------\n");
                    break;
                }
        }

    }

    static void Exercicio02()
    {
        int meses;
        decimal taxa;
        decimal saldoFinal;
        decimal saldoInicial;

        Console.WriteLine("\nSeja bem-vindo à sua conta bancária!");
        Console.WriteLine("Vamos descobrir qual foi o valor inicial do seu depósito.");

        do
        {
            Console.Write("Informe o saldo final do investimento (R$): ");
            if (decimal.TryParse(Console.ReadLine(), out saldoFinal) && saldoFinal > 0)
                break;
            Console.WriteLine("Por favor, informe um valor positivo.");
        } while (true);

        do
        {
            Console.Write("Digite o valor da taxa de rendimento mensal (%): ");
            if (decimal.TryParse(Console.ReadLine(), out taxa) && taxa >= 0)
            {
                taxa /= 100;
                break;
            }
            Console.WriteLine("Por favor, insira uma taxa válida.");
        } while (true);

        do
        {
            Console.Write("Digite o número de meses que o investimento ficou rendendo: ");
            if (int.TryParse(Console.ReadLine(), out meses) && meses > 0)
                break;
            Console.WriteLine("Por favor, digite um número válido de meses.");
        } while (true);

        saldoInicial = saldoFinal / (decimal)Math.Pow((double)(1 + taxa), meses);

        Console.WriteLine("\n===============================================================");
        Console.WriteLine($"Com um saldo final de R$ {saldoFinal:F2} após {meses} meses");
        Console.WriteLine($"e uma taxa de rendimento de {taxa * 100:F2}% ao mês...");
        Console.WriteLine($"→ O valor inicial do depósito foi aproximadamente: R$ {saldoInicial:F2}");
        Console.WriteLine("===============================================================\n");
    }
}