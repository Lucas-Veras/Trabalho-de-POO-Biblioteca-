using System;

class MainClass {
  public static NGenero ngenero = new NGenero();
  public static void Main() {
    int opcao = 999;
    Console.Write("--- ");
    Console.Write("Seja Bem-Vindo(a) a nossa Livraria");
    Console.Write(" ---");
    while (opcao != 0){
      opcao = Menu();
      switch(opcao){
        case 0:
          break;
        case 1: 
          ListarGenero(); 
          break;
        case 2:
          InserirGenero();
          break;
        case 3:
          break;
        case 4:
          break;
        case 5:
          
          break;
        default:
          Console.Write("Opção inválida! Tente novamente!");
          break;
      }
    }
    Console.WriteLine("Obrigado! E tenha uma boa leitura :)");
  }
  public static int Menu(){
    Console.WriteLine("\n------------------------------------------");
    Console.WriteLine("1 - Gênero - Listar");
    Console.WriteLine("2 - Gênero - Inserir");
    Console.WriteLine("3 - Livros - Listar");
    Console.WriteLine("4 - Livros - Inserir");
    Console.WriteLine("5 - Carrinho");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    int opcao = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcao;
  }
  public static void ListarGenero(){
    Console.WriteLine("------------ Lista de Gêneros ------------");
    Genero[] cs = ngenero.Listar();
    if (cs.Length == 0){
      Console.WriteLine("Nenhum Gênero cadastrado");
      return;
    }
    foreach (Genero i in cs){
      Console.WriteLine(i);
    }
    Console.WriteLine();
  }
  public static void InserirGenero(){
    Console.WriteLine("------------ Adicionar Gênero ------------");
    Console.Write("Informe um ID para o gênero: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Escreva o nome do gênero: ");
    string nome = Console.ReadLine();
    Genero x = new Genero(id, nome);
    ngenero.Inserir(x);
  }
}