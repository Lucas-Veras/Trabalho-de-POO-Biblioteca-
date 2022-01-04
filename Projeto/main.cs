using System;
class MainClass {
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
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Escolha uma opção:");
    int opcao = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcao;
  }
  public static void ListarGenero(){
    Console.WriteLine("------------ Lista de Gêneros ------------");
  }
  public static void InserirGenero(){
    Console.WriteLine("------------ Adicionar Gênero ------------");
  }
}



