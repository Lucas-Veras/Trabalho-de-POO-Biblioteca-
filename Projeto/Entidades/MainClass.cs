using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Threading;

class MainClass
{
  public static NGenero ngenero = new NGenero();
  public static NLivro nlivro = new NLivro();
//  public static List<Venda> vendas = new List<Venda>();
  public static NCliente ncliente = new NCliente();
  private static Cliente clienteLogin = null;
  public static void Main()
  { 
   Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
    int opcao = 0;
    int perfil = 0;
    Console.Write("--- Seja Bem-Vindo(a) a nossa Livraria ---");
    do {
      try{
        if (perfil == 0){
          opcao = 0;
          perfil = MenuUsuario();
        }
        if (perfil == 1){
          opcao = MenuVendedor();
          switch (opcao)
          {
              case 0:
                  break;
              case 1:
                  ListarGenero();
                  break;
              case 2:
                  InserirGenero();
                  break;
              case 3:
                  AtualizarGenero();
                  break;
              case 4:
                  ExcluirGenero();
                  break;
              case 5:
                  ListarLivro();
                  break;
              case 6:
                  InserirLivro();
                  break;
              case 7:
                  AtualizarLivro();
                  break;
              case 8:
                  ExcluirLivro();
                  break;
              case 9:
                  ListarCliente();
                  break;
              case 10:
                  InserirCliente();
                  break;
              case 11:
                  AtualizarCliente();
                  break;
              case 12:
                  ExcluirCliente();
                  break;
          /*    case 13:
                  Carrinho();
                  break;*/
              case 20:
                  perfil = 0; 
                  break;
              default:
                  Console.WriteLine("Opção inválida, tente novamente.");
                  break;
          }
        }
        if (perfil == 2 && clienteLogin == null){
          opcao = MenuClienteLogin();
          switch (opcao)
          {
              case 1:
              ClienteLogin();
                  break;
              case 20:
                  perfil = 0;
                  break;
          }
        }
        if (perfil == 2 && clienteLogin != null){
          opcao = MenuClienteLogout();
          switch (opcao)
          {
              case 1:
                  ClienteVendaListar();
                  break;
              case 2:
                  ClienteProdutoListar();
                  break;
              case 3:
                  ClienteProdutoInserir();
                  break;
              case 4:
                  ClienteCarrinhoVisualizar();
                  break;
              case 5:
                  ClienteCarrinhoLimpar();
                  break;
              case 6:
                  ClienteCarrinhoComprar();
                  break;
              case 20:
                  ClienteLogout();
                  break;    
          }
        }
    }
    catch(Exception erro){
      Console.WriteLine(erro.Message);
    }
  } while(opcao != 0);
    Console.WriteLine("Obrigado! Volte sempre :)");
  }
  public static int MenuUsuario()
  {
  Console.WriteLine("\n------------------------------------------");
  Console.WriteLine("01 - Entrar como Vendedor");
  Console.WriteLine("02 - Entrar como Cliente");
  Console.WriteLine("0  - Sair");
  Console.WriteLine("------------------------------------------");
  Console.Write("Escolha uma opção: ");
  int opcao = int.Parse(Console.ReadLine());
  Console.WriteLine();
  return opcao;
  }
  
  public static int MenuVendedor()
  {
  Console.WriteLine("\n------------------------------------------");
  Console.WriteLine("01 - Gênero - Listar");
  Console.WriteLine("02 - Gênero - Inserir");
  Console.WriteLine("03 - Gênero - Atualizar");
  Console.WriteLine("04 - Gênero - Excluir");
  Console.WriteLine("05 - Livros - Listar");
  Console.WriteLine("06 - Livros - Inserir");
  Console.WriteLine("07 - Livros - Atualizar");
  Console.WriteLine("08 - Livros - Excluir");

  Console.WriteLine("09 - Cliente - Listar");
  Console.WriteLine("10 - Cliente - Inserir");
  Console.WriteLine("11 - Cliente - Atualizar");
  Console.WriteLine("12 - Cliente - Excluir");

//  Console.WriteLine("13 - Carrinho");
  Console.WriteLine("20 - Voltar ");
  Console.WriteLine("0  - Sair");
    Console.WriteLine("------------------------------------------");
  Console.Write("Escolha uma opção: ");
  int opcao = int.Parse(Console.ReadLine());
  Console.WriteLine();
  return opcao;
  }

  public static int MenuClienteLogin()
  {
  Console.WriteLine("\n------------------------------------------");
  Console.WriteLine("01 - Login");
  Console.WriteLine("20 - Voltar");
  Console.WriteLine("0  - Sair");
  Console.WriteLine("\n------------------------------------------");
  Console.Write("Escolha uma opção: ");
  int opcao = int.Parse(Console.ReadLine());
  Console.WriteLine();
  return opcao;
  }

  public static int MenuClienteLogout()
  {
  Console.WriteLine("\n------------------------------------------");
  Console.WriteLine("Bem vindo(a), "+ clienteLogin.Nome);
  Console.WriteLine("------------------------------------------");
  Console.WriteLine("01 - Listar minhas compras");
  Console.WriteLine("02 - Listar produtos");
  Console.WriteLine("03 - Inserir um produto no carrinho");
  Console.WriteLine("04 - Visualizar o carrinho");
  Console.WriteLine("05 - Limpar o carrinho");
  Console.WriteLine("06 - Confirmar a compra");
  Console.WriteLine("20 - Logout");
  Console.WriteLine("0  - Sair");
  Console.WriteLine("\n------------------------------------------");
  Console.Write("Escolha uma opção: ");
  int opcao = int.Parse(Console.ReadLine());
  Console.WriteLine();
  return opcao;
  }


  public static void ListarGenero()
  {
  Console.WriteLine("------------ Lista de Gêneros ------------");
  Genero[] cs = ngenero.Listar();
  GeneroIdComp x = new GeneroIdComp();
  Array.Sort(cs,x);
  if (cs.Length == 0)
  {
      Console.WriteLine("Nenhum Gênero cadastrado");
      return;
  }
  foreach (Genero i in cs)
  {
      Console.WriteLine(i);
  }
  Console.WriteLine();
  }
  public static void InserirGenero()
  {
  Console.WriteLine("------------ Adicionar Gênero ------------");
  Console.Write("Informe um ID para o gênero: ");
  int id = int.Parse(Console.ReadLine());
  Console.Write("Escreva o nome do gênero: ");
  string nome = Console.ReadLine();
  Genero x = new Genero(id, nome);
  ngenero.Inserir(x);
  }
  public static void AtualizarGenero()
  {
  Console.WriteLine("----------- Atualização de Gêneros -----------");
  ListarGenero();
  Console.Write("Informe o ID do gênero a ser alterado: ");
  int id = int.Parse(Console.ReadLine());
  Console.Write("Escreva o nome do gênero: ");
  string nome = Console.ReadLine();
  Genero x = new Genero(id, nome);
  ngenero.Atualizar(x);
  }
  public static void ExcluirGenero()
  {
  Console.WriteLine("----------- Exclusão de Gêneros -----------");
  ListarGenero();
  Console.Write("Informe o ID do gênero a ser excluído: ");
  int id = int.Parse(Console.ReadLine());
  Genero x = ngenero.Listar(id);
  ngenero.Excluir(x);
  }
  public static void ListarLivro()
  {
  Console.WriteLine("------------ Lista de Livros ------------");
  Livro[] z = nlivro.Listar();
  LivroIdComp x = new LivroIdComp();
  Array.Sort(z,x);
  if (z.Length == 0)
  {
      Console.WriteLine("Nenhum livro cadastrado");
      return;
  }
  foreach (Livro i in z)
  {
      Console.WriteLine(i);
  }
  Console.WriteLine();
  /*
  Console.WriteLine("Deseja comprar algum livro? Se sim, digite o ID, se nao digite 0 para voltar ao menu: ");
  int id = int.Parse(Console.ReadLine());
  if (id == 0)
  {
      return;
  }
  Livro l = nlivro.Listar(id);
  if (l == null)
  {
      Console.WriteLine("ID inválido, tente efetuar as operações novamente");
      return;
  }
  else
  {
      Console.WriteLine("Qual a quantidade que deseja adicionar? ");
      int qtd = int.Parse(Console.ReadLine());
      Venda v = new Venda(l.GetId(), l.GetNome(), l.GetPreco(), qtd);
      vendas.Add(v);
      Console.WriteLine("Gostaria de adicionar mais algum livro? Se sim, digite o ID, se nao, digite 0: ");
      id = int.Parse(Console.ReadLine());
      if (id == 0) return;
      while (id != 0)
      {
          l = nlivro.Listar(id);
          Console.WriteLine("Qual a quantidade que deseja adicionar? ");
          qtd = int.Parse(Console.ReadLine());
          v = new Venda(l.GetId(), l.GetNome(), l.GetPreco(), qtd);
          vendas.Add(v);
          Console.WriteLine("Gostaria de adicionar mais algum livro? Se sim, digite o ID, se nao, digite 0: ");
          id = int.Parse(Console.ReadLine());
          if (id == 0) return;
          Livro n = nlivro.Listar(id);
          if (n == null){ 
              Console.WriteLine("ID inválido, tente efetuar as operações novamente");
          return;
          }
      }
  }*/
  }
  public static void ListarLivro2()
  {
  Console.WriteLine("------------ Lista de Livros ------------");
  Livro[] z = nlivro.Listar();
  if (z.Length == 0)
  {
      Console.WriteLine("Nenhum livro cadastrado");
      return;
  }
  foreach (Livro i in z)
  {
      Console.WriteLine(i);
  }
  Console.WriteLine();
  }
  public static void InserirLivro()
  {
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
  if (generoid == 0)
  {
      Livro x = new Livro(id, nome, preco, paginas, qtd);
      nlivro.Inserir(x);
  }
  else
  {
      Genero g = ngenero.Listar(generoid);
      Livro x = new Livro(id, nome, preco, paginas, qtd, g);
      nlivro.Inserir(x);
  }
  }
  public static void AtualizarLivro()
  {
  Console.WriteLine("----------- Atualização de Livros -----------");
  ListarLivro2();
  Console.Write("Informe o id do livro para ser atualizado: ");
  int id = int.Parse(Console.ReadLine());
  Console.Write("Informe o novo nome do livro: ");
  string nome = Console.ReadLine();
  Console.Write("Informe o seu novo preço: ");
  double preco = double.Parse(Console.ReadLine());
  Console.Write("Informe a sua quantidade de paginas: ");
  int paginas = int.Parse(Console.ReadLine());
  Console.Write("Informe a quantidade que entrará em estoque: ");
  int qtd = int.Parse(Console.ReadLine());
  Console.Write("Informe o gênero do livro(caso não haja, digite 0): ");
  int generoid = int.Parse(Console.ReadLine());
  if (generoid == 0)
  {
      Livro x = new Livro(id, nome, preco, paginas, qtd);
      nlivro.Atualizar(x);
  }
  else
  {
      Genero g = ngenero.Listar(generoid);
      Livro x = new Livro(id, nome, preco, paginas, qtd, g);
      nlivro.Atualizar(x);
  }
  }
  public static void ExcluirLivro()
  {
  Console.WriteLine("----------- Exclusão de Livros -----------");
  ListarLivro2();
  Console.Write("Informe o ID do Livro a ser excluído: ");
  int id = int.Parse(Console.ReadLine());
  Livro x = nlivro.Listar(id);
  nlivro.Excluir(x);
  }

  /*
  public static void Carrinho()
  {
  Console.WriteLine("------------ Carrinho ------------");
  if (vendas.Count == 0)
  {
      Console.WriteLine("Nenhum livro no carrinho");
      return;
  }
  double total = 0;
  foreach(Venda i in vendas)
  {
      Console.WriteLine(i);
      total += i.GetPreco() * i.GetQtd();
  }
  Console.WriteLine($"Total: R${total}");
  Console.WriteLine("Você deseja remover algum item do seu carrinho? 1 - Sim | 2 - Não");
  int finalizar = int.Parse(Console.ReadLine());
  if (finalizar == 1){
      Console.WriteLine("Digite o ID do item que deseja remover: ");
      int ide = int.Parse(Console.ReadLine());
      foreach(Venda i in vendas){
          if(i.GetId() == ide){
              int indice = vendas.IndexOf(i);
              vendas.RemoveAt(indice);
              break;
          }
      }
  }
  Console.WriteLine("Deseja finalizar a sua compra? 1 - Sim | 2 - Não");
  finalizar = int.Parse(Console.ReadLine());
    if (finalizar == 1)
    {
      Console.WriteLine("Métodos de pagamento:");
      Console.WriteLine("1 - Cartão");
      Console.WriteLine("2 - PIX");
      Console.WriteLine("3 - Boleto");
      Console.WriteLine("Escolha seu método de pagamento: (caso deseje comprar mais algum livro digite 0 para voltar para o menu)");
      int escolha = int.Parse(Console.ReadLine());
      if (escolha == 0){

      }
      Livro[] x = nlivro.Listar();
      foreach (Venda i in vendas){
          Livro l = nlivro.Listar(i.GetId());
          l.SetQtd(l.GetQtd()-i.GetQtd());
      }
      vendas.Clear();
      if (escolha == 1)
      {
          Console.WriteLine("1 - Débito\n2 - Crédito");
          int metodo = int.Parse(Console.ReadLine());
          if (metodo == 1)
          {
              Console.WriteLine("Digite o número do seu cartão:");
              int numeroCartao = int.Parse(Console.ReadLine());
              Console.WriteLine("Digite a validade do cartão:");
              int validade = int.Parse(Console.ReadLine());
              Console.WriteLine("Digite o código de segurança, são 3 digitos:");
              int codigoDeSeguranca = int.Parse(Console.ReadLine());
              Console.WriteLine($"O valor a pagar no débito é R${total}, deseja finalizar a compra?\n1 - Sim\n2 - Não");
              int finalizar2 = int.Parse(Console.ReadLine());
              if (finalizar2 == 1){
                Console.WriteLine("Obrigado pela compra e volte sempre :)");
              } 
          }
          if (metodo == 2)
          {
              Console.WriteLine("Digite o número do seu cartão:");
              int numeroCartao = int.Parse(Console.ReadLine());
              Console.WriteLine("Digite a validade do cartão:");
              int validade = int.Parse(Console.ReadLine());
              Console.WriteLine("Digite o código de segurança, são 3 digitos:");
              int codigoDeSeguranca = int.Parse(Console.ReadLine());
              Console.WriteLine("Em quantas parcelas deseja pagar?");
              int parcelas = int.Parse(Console.ReadLine());
              double valorParcelas = total/parcelas;
              Console.WriteLine($"Você pagará {parcelas}X de R${valorParcelas:0.00}");
              Console.WriteLine("Deseja finalizar sua compra?\n1 - Sim\n2 - Não");
              int finalizar2 = int.Parse(Console.ReadLine());
              if (finalizar2 == 1){
                Console.WriteLine("Muito obrigado pela compra e volte sempre! :)");
              }
          }
      }
      if (escolha == 2)
      {
          Console.WriteLine($"O valor final é R${total}, deseja finalizar a compra?\n1 - Sim\n2 - Não");
          int finalizar2 = int.Parse(Console.ReadLine());
          if (finalizar2 == 1){
            Console.WriteLine($"Faça um pix de R${total} para o nosso email: livraria@gmail.com");
            Console.WriteLine("E Muito obrigado pela compra, volte sempre! :)");
          }
      }
      if (escolha == 3)
      {

          Random randNum = new Random();
          int boleto = randNum.Next(100000000, 999999999);
          int boleto2 = randNum.Next(100000000, 999999999);
          int boleto3 = randNum.Next(100000000, 999999999);
          int boleto4 = randNum.Next(100000000, 999999999);
          int boleto5 = randNum.Next(100000000, 999999999);
          int boleto6 = randNum.Next(100, 999);
          Console.WriteLine($"Total a pagar: R${total}, deseja finalizar a compra?\n1 - Sim\n2 - Não");
          int finalizar2 = int.Parse(Console.ReadLine());
          if (finalizar2 == 1){
            Console.WriteLine($"Código do boleto para pagar: {boleto}{boleto2}{boleto3}{boleto3}{boleto4}{boleto5}{boleto6}");
            Console.WriteLine("E Muito obrigado pela compra, volte sempre! :)");
          }
        }
      }
    }*/





  public static void ListarCliente()
  {
    Console.WriteLine("------------ Lista de Clientes ------------");
    List<Cliente> cs = ncliente.Listar();

    if (cs.Count == 0)
    {
        Console.WriteLine("Nenhum cliente cadastrado");
        return;
    }
    foreach (Cliente i in cs)
    {
        Console.WriteLine(i);
    }
    Console.WriteLine();
  }
  public static void InserirCliente()
  {
    Console.WriteLine("------------ Adicionar Cliente ------------");
    Console.Write("Digite o nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Digite a data de nascimento do cliente no formato (dd/mm/aaaa):");
    DateTime dataNasc = DateTime.Parse(Console.ReadLine());
    Cliente x = new Cliente { Nome = nome, Nascimento = dataNasc };
    ncliente.Inserir(x);
  }
  
  public static void AtualizarCliente()
  {
    Console.WriteLine("----------- Atualização de Clientes -----------");
    ListarCliente();
    Console.Write("Informe o nome do cliente a ser atualizado: ");
    string nome = Console.ReadLine();
    Console.Write("Digite a data de nascimento do cliente: ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    Cliente x = new Cliente { Nome = nome, Nascimento = nasc };
    ncliente.Atualizar(x);
  }
  public static void ExcluirCliente()
  {
    Console.WriteLine("----------- Exclusão de Clientes -----------");
    ListarCliente();
    Console.Write("Informe o código do cliente a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    Cliente x = ncliente.Listar(id);
    ncliente.Excluir(x);
  }

  public static void ClienteLogin(){
    Console.WriteLine("----- Login do Cliente -----");
    ListarCliente();
    clienteLogin = new Cliente();
    Console.Write("Informe o código do cliente para logar: ");
    int id = int.Parse(Console.ReadLine());
    clienteLogin = ncliente.Listar(id);
  }
  public static void ClienteLogout(){
    Console.WriteLine("----- Logout do Cliente -----");
    clienteLogin = null;
  }
  public static void ClienteVendaListar(){
    Console.WriteLine("----- Venda Listar -----");
  }
  public static void ClienteProdutoListar(){
    Console.WriteLine("----- Produto Listar -----");
  }
  public static void ClienteProdutoInserir(){
    Console.WriteLine("----- Produto Inserir -----");
  }
  public static void ClienteCarrinhoVisualizar(){
    Console.WriteLine("----- Carrinho Visualizar -----");
  }
  public static void ClienteCarrinhoLimpar(){
    Console.WriteLine("----- Carrinho Limpar -----");
  }
  public static void ClienteCarrinhoComprar(){
    Console.WriteLine("----- Carrinho Comprar -----");
  }
}