using System;

class MainClass {
  public static NGenero ngenero = new NGenero();
  public static NLivro nlivro = new NLivro();
  public static NVenda nvenda = new NVenda();
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
          ListarLivro();
          break;
        case 4:
          InserirLivro();
          break;
        case 5:
          Carrinho();
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
  public static void ListarLivro(){
    Console.WriteLine("------------ Lista de Livros ------------");
    Livro[] z = nlivro.Listar();
    if (z.Length == 0){
    Console.WriteLine("Nenhum livro cadastrado");
    return;
    }
    foreach (Livro i in z){
      Console.WriteLine(i);
    }
    Console.WriteLine();
    Console.WriteLine("Deseja comprar algum livro? Se sim, digite o ID, se nao digite 0 para voltar ao menu: ");
    int id = int.Parse(Console.ReadLine());
    if (id == 0){
      return;
    }
    Livro l = nlivro.Listar(id);
    if (l == null){
      Console.WriteLine("ID inválido, tente efetuar as operações novamente");
      return;
    }
    else{
      Console.WriteLine("Qual a quantidade que deseja adicionar? ");
      int qtd = int.Parse(Console.ReadLine());
      Venda v = new Venda(l.GetId(), l.GetNome(), l.GetPreco(), qtd);
      nvenda.Inserir(v);
      Console.WriteLine("Gostaria de adicionar mais algum livro? Se sim, digite o ID, se nao, digite 0: ");
      id = int.Parse(Console.ReadLine());
      if (id == 0) return;
      while(id != 0){
        l = nlivro.Listar(id);
        Console.WriteLine("Qual a quantidade que deseja adicionar? ");
        qtd = int.Parse(Console.ReadLine());
        v = new Venda(l.GetId(), l.GetNome(), l.GetPreco(), qtd);
        nvenda.Inserir(v);
        Console.WriteLine("Gostaria de adicionar mais algum livro? Se sim, digite o ID, se nao, digite 0: ");
        id = int.Parse(Console.ReadLine());
        if (id == 0) return;
        Console.WriteLine("ID inválido, tente efetuar as operações novamente");
        return;
      }
    }
  }
  public static void InserirLivro(){
    Console.WriteLine("------------ Adicionar Livro ------------");
    Console.Write("Informe o id do livro: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do livro: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o seu preço: ");
    double preco = double.Parse(Console.ReadLine());
    Console.Write("Informe a sua quantidade de paginas: ");
    int paginas = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade que entrará em estoque: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o gênero do livro(caso não haja, digite 0): ");
    int generoid = int.Parse(Console.ReadLine());
    if (generoid == 0){
      Livro x = new Livro(id, nome, preco, paginas, qtd);
      nlivro.Inserir(x);
    }
    else{
      Genero g = ngenero.Listar(generoid);
      Livro x = new Livro(id, nome, preco, paginas, qtd, g);
      nlivro.Inserir(x);
    }
  }
  public static void Carrinho(){
    Console.WriteLine("------------ Carrinho ------------");
    Venda[] v = nvenda.Listar();
    if (v.Length == 0){
      Console.WriteLine("Nenhum livro no carrinho");
      return;
    }
    foreach (Venda i in v){
      Console.WriteLine(i);
    }
    Console.WriteLine();
  }
}
