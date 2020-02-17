using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinAcessorios
{
    class Program
    {
        static void Main(string[] args)
        {
            Programa();
        }

        public static void Programa()
        {
            //Declaração de Variaveis
            string vnome;
            double vcarrinho = 0;
            double vjuros = 0.09;
            double vcaljuros = 0;
            string vcomprar = "0";
            uint vquantidade = 0;
            string vfimCompra = "";
            int resultado;
            string vrecebevalor = "";

            uint[] vtestoque = new uint[11];
            string[] vtnome_produto = new string[11];
            double[] vtpreco = new double[11];
            uint[] vtcodigo = new uint[11];
            uint[] vtauxiliar = new uint[11];

            //Atribuição de Valores as Variaveis
            for (int i = 0; i < vtauxiliar.Length; i++)
            {
                vtauxiliar[i] = 0;
            }


            vtcodigo[0] = 0;
            vtcodigo[1] = 0001;
            vtcodigo[2] = 0002;
            vtcodigo[3] = 0003;
            vtcodigo[4] = 0004;
            vtcodigo[5] = 0005;
            vtcodigo[6] = 0006;
            vtcodigo[7] = 0007;
            vtcodigo[8] = 0008;
            vtcodigo[9] = 0009;
            vtcodigo[10] = 0010;

            vtpreco[0] = 0;
            vtpreco[1] = 10.00;
            vtpreco[2] = 15.50;
            vtpreco[3] = 79.99;
            vtpreco[4] = 25.00;
            vtpreco[5] = 30.90;
            vtpreco[6] = 7.00;
            vtpreco[7] = 5.00;
            vtpreco[8] = 10.00;
            vtpreco[9] = 20.90;
            vtpreco[10] = 105.90;

            vtestoque[0] = 0;
            vtestoque[1] = 10;
            vtestoque[2] = 15;
            vtestoque[3] = 19;
            vtestoque[4] = 12;
            vtestoque[5] = 10;
            vtestoque[6] = 14;
            vtestoque[7] = 13;
            vtestoque[8] = 16;
            vtestoque[9] = 20;
            vtestoque[10] = 20;

            vtnome_produto[0] = "";
            vtnome_produto[1] = " Brinco   ";
            vtnome_produto[2] = " Bolsa    ";
            vtnome_produto[3] = " Turbante ";
            vtnome_produto[4] = " Capulana ";
            vtnome_produto[5] = " Anel     ";
            vtnome_produto[6] = " Tiara    ";
            vtnome_produto[7] = " Corrente ";
            vtnome_produto[8] = " Bracelete";
            vtnome_produto[9] = " Óculos   ";
            vtnome_produto[10] = " Pulseira ";

            Console.WriteLine("/////////////////////////");
            Console.WriteLine("//// AKIN ACESSÓRIOS ////");
            Console.WriteLine("////////////////////////");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("DIGITE O SEU NOME: ");
            vnome = Console.ReadLine();

            Console.Clear();

            {
                do
                {

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();

                    Console.WriteLine("/////////////////////////");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("//// AKIN ACESSÓRIOS ////");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("/////////////////////////");

                    Console.WriteLine();

                    for (int i = 1; i < 11; i++) // Exibição da lista de produtos
                    {
                        if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkCyan;
                        else Console.ForegroundColor = ConsoleColor.White;
                        if (vtcodigo[i] < 10)
                        {

                            Console.WriteLine("CÓDIGO: {0}  | PRODUTO: {1} | QTDE: {3} | PREÇO: {2}", vtcodigo[i], vtnome_produto[i], vtpreco[i].ToString("C"), vtestoque[i]);
                        }
                        else
                        {
                            Console.WriteLine("CÓDIGO: {0} | PRODUTO: {1} | QTDE: {3} | PREÇO: {2}", vtcodigo[i], vtnome_produto[i], vtpreco[i].ToString("C"), vtestoque[i]);
                        }


                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Seu carrinho de compras: ");
                    for (int i = 1; i < 11; i++)
                    {
                        if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkGray;
                        else Console.ForegroundColor = ConsoleColor.White;

                        if (vtauxiliar[i] > 0)
                        {
                            Console.WriteLine("CÓDIGO: {0} | PRODUTO: {1} | QTDE: {3} | PREÇO: {2} | SUBTOTAL: " + (vtpreco[i] * vtauxiliar[i]).ToString("C"), vtcodigo[i], vtnome_produto[i], vtpreco[i].ToString("C"), vtauxiliar[i]);
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nSubotal: {0}\n", vcarrinho.ToString("C"));


                    // VALIDAÇÃO PARA RECEBER APENAS NÚMERO
                    do
                    {
                        Console.Write("\nDigite o código do produto que deseja comprar: ");
                        vcomprar = Console.ReadLine();

                        if ((int.TryParse(vcomprar, out resultado) == false))
                        {
                            Console.WriteLine("ERRRROOOUUUUU\nTente novamente!");
                        }
                    }
                    while (int.TryParse(vcomprar, out resultado) == false);


                    if (vtauxiliar[int.Parse(vcomprar)] > 0) // Verifica se já comprou o produto
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0}, você já comprou este produto.", vnome);
                        Console.ReadKey();
                    }
                    else
                    {

                        // VALIDAÇÃO PARA RECEBER APENAS NÚMERO

                        do
                        {
                            Console.Write("Escolha a quantidade do produto que deseja comprar: ");
                            vrecebevalor = Console.ReadLine();

                            if ((uint.TryParse(vrecebevalor, out vquantidade) == false))
                            {
                                Console.WriteLine("ERROOUUUU");
                            }
                        }
                        while (uint.TryParse(vrecebevalor, out vquantidade) == false);





                        // --------------


                        if (vtestoque[int.Parse(vcomprar)] == 0) // vquantidade > estoque
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0}, estamos sem estoque para este produto. Desculpa!", vnome);
                            Console.ReadKey();
                        }
                        else if (vquantidade > vtestoque[int.Parse(vcomprar)]) // vquantidade > estoque
                        {
                            Console.WriteLine("{0}, no momento temos apenas {1} {2} no nosso estoque", vnome, vtestoque[int.Parse(vcomprar)], vtnome_produto[int.Parse(vcomprar)].Trim());
                            Console.ReadKey();
                        }

                        else
                        {
                            // somar valor no subtoal
                            vcarrinho = vcarrinho + (vtpreco[int.Parse(vcomprar)] * vquantidade);

                            // jogar produto no vetor produtocomprado
                            vtauxiliar[int.Parse(vcomprar)] = vquantidade;

                            // dar baixa no estoque o estoque
                            vtestoque[int.Parse(vcomprar)] = vtestoque[int.Parse(vcomprar)] - vquantidade;

                            Console.WriteLine("\nSUBTOTAL DO CARRINHO: {0}\n", vcarrinho.ToString("C"));

                            Console.Write("Digite 1 para continuar comprando ou \nDigite 2 para finalizar a compra: ");
                            vfimCompra = Console.ReadLine();

                            while (vfimCompra != "2" && vfimCompra != "1") // FUNCIONOU
                            {
                                Console.WriteLine("ERROOOUUUUU!!!\nDigite 1 para continuar comprando ou \nDigite 2 para finalizar a compra: ");
                                vfimCompra = Console.ReadLine();
                            }

                        }
                    }

                }

                while (vfimCompra == "1");

                vcaljuros = vcarrinho * vjuros;

                Console.Clear();

                Console.WriteLine("/////////////////////////");
                Console.WriteLine("//// AKIN ACESSÓRIOS ////");
                Console.WriteLine("////////////////////////");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Lista de compras: ");
                for (int i = 1; i < 11; i++)
                {
                    if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkGray;
                    else Console.ForegroundColor = ConsoleColor.White;

                    if (vtauxiliar[i] > 0)
                    {
                        Console.WriteLine("CÓDIGO: {0} | PRODUTO: {1} | QTDE: {3} | PREÇO: {2} ", vtcodigo[i], vtnome_produto[i], vtpreco[i].ToString("C"), vtauxiliar[i]);
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine("\nTOTAL DA COMPRA É: {0}", vcarrinho.ToString("C"));
                Console.WriteLine("O ICMS DA COMPRA É: " + vcaljuros.ToString("C"));

                Console.ReadKey();

            }
        }
    }
}