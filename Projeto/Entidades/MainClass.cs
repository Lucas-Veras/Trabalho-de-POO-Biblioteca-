using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Linq;

class MainClass
{
  public static NGenero ngenero = NGenero.Singleton;
  public static NLivro nlivro = NLivro.Singleton;
//  public static List<Venda> vendas = new List<Venda>();
  public static NCliente ncliente = NCliente.Singleton;
  public static NVenda nvenda = NVenda.Singleton;

  private static Cliente clienteLogin = null;
  public static Venda clienteVenda = null;
  public static void Main()
  { 
   Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
    try{
      ngenero.Abrir();
      nlivro.Abrir();
      ncliente.Abrir();
      nvenda.Abrir();
    }
    catch(Exception erro){
      Console.WriteLine(erro.Message);
    }
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
          opcao = MenuGerente();
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
              case 13:
                  VendaListar();
                  break;
              case 14:
                  VerComentarios();
                  break;
              case 15:
                  AtualizarQuantidadeEstoque();
                  break;
              case 16:
                  VendaListarResumo();
                  break;
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
                  ClienteLivroListar();
                  break;
              case 3:
                  ClienteLivroInserir();
                  break;
              case 4:
                  ClienteCarrinhoVisualizar();
                  break;
              case 5:
                  ClienteCarrinhoLimpar();
                  break;
              case 6:
                  ClienteComentariosListar();
                  break;
              case 7:
                  ClienteAtualizarComentario();
                  break;
              case 8:
                  ClienteApagarComentario();
                  break;
              case 9:
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
  try{
    ngenero.Salvar();
    nlivro.Salvar();
    ncliente.Salvar();
    nvenda.Salvar();
  }
  catch(Exception erro){
    Console.WriteLine(erro.Message);
  }
    Console.WriteLine("Obrigado! Volte sempre :)");
  }
  public static int MenuUsuario()
  {
  Console.WriteLine("\n------------------------------------------");
  Console.WriteLine("01 - Entrar como Gerente");
  Console.WriteLine("02 - Entrar como Cliente");
  Console.WriteLine("0  - Sair");
  Console.WriteLine("------------------------------------------");
  Console.Write("Escolha uma opção: ");
  int opcao = int.Parse(Console.ReadLine());
  Console.WriteLine();
  return opcao;
  }
  
  public static int MenuGerente()
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
  Console.WriteLine("13 - Venda   - Listar");
  Console.WriteLine("14 - Venda   - Ver Comentários");
  Console.WriteLine("15 - Atualizar estoque");
  Console.WriteLine("16 - Resumo das vendas");
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
  Console.WriteLine("Bem vindo(a), " + clienteLogin.Nome);
  Console.WriteLine("------------------------------------------");
  Console.WriteLine("01 - Listar minhas compras");
  Console.WriteLine("02 - Listar livros");
  Console.WriteLine("03 - Inserir um livro no carrinho");
  Console.WriteLine("04 - Visualizar o carrinho");
  Console.WriteLine("05 - Limpar o carrinho");
  Console.WriteLine("06 - Ver apenas meus comentários");
  Console.WriteLine("07 - Atualizar/Adicionar comentário");
  Console.WriteLine("08 - Apagar comentário");
  Console.WriteLine("09 - Confirmar a compra");
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
//  GeneroIdComp x = new GeneroIdComp();
  Array.Sort(cs);
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
  //LivroIdComp x = new LivroIdComp();
  Array.Sort(z);
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

  public static void InserirLivro()
  {
  Console.WriteLine("------------ Adicionar Livro ------------");
  Console.Write("Informe o id do livro: ");
  int id = int.Parse(Console.ReadLine());
  Console.Write("Informe o nome do livro: ");
  string nome = Console.ReadLine();
  Console.Write("Informe o seu preço: ");
  double preco = double.Parse(Console.ReadLine());
  Console.Write("Informe a sua quantidade de páginas: ");
  int paginas = int.Parse(Console.ReadLine());
  Console.Write("Informe a quantidade que entrará em estoque: ");
  int qtd = int.Parse(Console.ReadLine());
  ListarGenero();
  Console.WriteLine("------------------------------------------");
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
  ListarLivro();
  Console.Write("Informe o id do livro para ser atualizado: ");
  int id = int.Parse(Console.ReadLine());
  Console.Write("Informe o novo nome do livro: ");
  string nome = Console.ReadLine();
  Console.Write("Informe o seu novo preço: ");
  double preco = double.Parse(Console.ReadLine());
  Console.Write("Informe a sua quantidade de páginas: ");
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
  ListarLivro();
  Console.Write("Informe o ID do Livro a ser excluído: ");
  int id = int.Parse(Console.ReadLine());
  Livro x = nlivro.Listar(id);
  nlivro.Excluir(x);
  }

  public static void AtualizarQuantidadeEstoque(){
    Console.WriteLine("----------- Atualização de Estoque -----------");
    ListarLivro();
    Console.Write("Informe o id do livro para ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade que entrará em estoque: ");
    int qtd = int.Parse(Console.ReadLine());
    Livro l = nlivro.Listar(id);
    l.SetQtd(qtd);
    Console.Write("Estoque atualizado!");
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
    Console.Write("Digite o código do cliente a ser atualizado: ");
    int codId = int.Parse(Console.ReadLine());
    Cliente y = ncliente.Listar(codId);
    if (y == null){
      Console.WriteLine("Esse cliente não existe, tente novamente!");
      return;
    }
    Console.Write("Informe o novo nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Digite a nova data de nascimento do cliente: ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    y.Nome = nome;
    y.Nascimento = nasc;
  //  Cliente y = new Cliente { Nome = nome, Nascimento = nasc };
    ncliente.Atualizar(y);
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

  public static void VendaListar(){
    Console.WriteLine("----- Lista de Vendas -----");
    List<Venda> vs = nvenda.Listar();
    if (vs.Count == 0){
      Console.WriteLine("Nenhuma venda cadastrada");
      return;
    }
    foreach(Venda v in vs){
      double total = v.Livros.Sum(vl => vl.Qtd*vl.Preco);
      Console.WriteLine(v + " - Total: R$" + total.ToString("0.00"));
      //Console.WriteLine(v);
      foreach (VendaLivro livro in nvenda.LivroListar(v)){
        Console.WriteLine(" " + livro);
      }
      if (v.GetComentario() == null){
        Console.WriteLine("  Sem comentário");
        Console.WriteLine();
        continue;
      }
      Console.WriteLine($"  Comentário: {v.GetComentario()}");
      Console.WriteLine();
    }
  }

  public static void VendaListarResumo(){
    Console.WriteLine("----- Resumo das Vendas -----");
    List<Venda> vs = nvenda.Listar();
    if (vs.Count == 0){
      Console.WriteLine("Nenhuma venda cadastrada");
      return;
    }
    double total = 0;
    int qtd = 0;
    foreach(Venda v in vs){
      total = total + v.Livros.Sum(vl => vl.Qtd*vl.Preco);
      qtd++;
    }
    
      Console.WriteLine("Total das vendas: R$" + total.ToString("0.00"));
    Console.WriteLine("Quantidade de vendas: " + qtd);
    var r1 = vs.Select(v => new {
      mesAno = v.Data.Month + "/" + v.Data.Year,
      total = v.Livros.Sum(vl => vl.Qtd * vl.Preco)
    });
    Console.WriteLine();
    Console.WriteLine("Vendas:");
    foreach(var livro in r1){
      Console.WriteLine("Data: " + livro.mesAno + " - Total: R$" + livro.total.ToString("0.00"));
    }
    
    
    /*
    foreach(Venda v in vs){
      Console.WriteLine(v);
      foreach (VendaLivro livro in nvenda.LivroListar(v)){
        Console.WriteLine(" " + livro);
      }
      if (v.GetComentario() == null){
        Console.WriteLine("  Sem comentário");
        Console.WriteLine();
        continue;
      }
      Console.WriteLine($"  Comentário: {v.GetComentario()}");
      Console.WriteLine();
    }*/
    
  }


  
  public static void VerComentarios(){
    Console.WriteLine("----- Lista de Comentários -----");
    List<Venda> vs = nvenda.Listar();
    if (vs.Count == 0){
      Console.WriteLine("Sem comentários");
      return;
    }
    foreach(Venda v in vs){
   //   Cliente x = v.GetCliente();
    //  string nome = v.Get
      if (v.GetComentario() == null){
        continue;
      }
      Console.WriteLine($"Comentário de {v.GetCliente().Nome}: {v.GetComentario()}");
      Console.WriteLine();
    }
  }

  public static void ClienteLogin(){
    Console.WriteLine("----- Login do Cliente -----");
    ListarCliente();
    clienteLogin = new Cliente();
    Console.Write("Informe o código do cliente para logar: ");
    int id = int.Parse(Console.ReadLine());
    clienteLogin = ncliente.Listar(id);
    clienteVenda = nvenda.ListarCarrinho(clienteLogin);
  }
  
  public static void ClienteLogout(){
    Console.WriteLine("----- Logout do Cliente -----");
    if(clienteVenda != null){
      nvenda.Inserir(clienteVenda, true);
    }
    clienteLogin = null;
    clienteVenda = null;
  }

  public static void ClienteVendaListar(){
    Console.WriteLine("----- Minhas Compras -----");
    List<Venda> vs = nvenda.Listar(clienteLogin);
    if (vs.Count == 0){
      Console.WriteLine("Nenhuma compra cadastrada");
      return;
    }
    foreach(Venda v in vs){
      double total = v.Livros.Sum(vl => vl.Qtd*vl.Preco);
      Console.WriteLine(v + " - Total: R$" + total.ToString("0.00"));
    //  Console.WriteLine(v);
      foreach (VendaLivro livro in nvenda.LivroListar(v)){
        Console.WriteLine(" " + livro);
      }
      if (v.GetComentario() == null){
        Console.WriteLine("  Sem comentário");
        Console.WriteLine();
        continue;
      }
      Console.WriteLine($"  Comentário: {v.GetComentario()}");
      Console.WriteLine();
    }
  }

  public static void ClienteLivroListar(){
    ListarLivro();
  }

  public static void ClienteLivroInserir(){
    Console.WriteLine("----- Inserir Livro -----");
    ListarLivro();
    Console.Write("Digite o código do livro a ser comprado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Digite a quantidade: ");
    int qtd = int.Parse(Console.ReadLine());
    if (qtd <= 0){
      Console.WriteLine("Coloque uma quantidade maior que 0, tente novamente!");
      return;
    }
    Livro l = nlivro.Listar(id);
    if(l != null){
      if (clienteVenda == null){
        clienteVenda = new Venda(DateTime.Now,clienteLogin);
      }
      nvenda.LivroInserir(clienteVenda, qtd, l);
    }
  }

  public static void ClienteCarrinhoVisualizar(){
    Console.WriteLine("------ Carrinho ------");
    if (clienteVenda == null){
      Console.WriteLine("Nenhum livro no carrinho");
      return;
    }
    List<VendaLivro> livros = nvenda.LivroListar(clienteVenda);
  //  List<Venda> vs = nvenda.Listar(clienteLogin);
  //  foreach(Venda v in vs){
  //    double total = v.Livros.Sum(vl => vl.Qtd*vl.Preco);
    //  Console.WriteLine(v + " - Total: R$" + total.ToString("0.00"));
    double total = 0;
    foreach(VendaLivro livro in livros){
      double valor = livro.Qtd * livro.Preco;
      total = total + valor;
    }
    Console.WriteLine("Total: R$" + total.ToString("0.00"));
    foreach (VendaLivro livro in livros){
      Console.WriteLine(livro);
    }
    Console.WriteLine();
  }

  public static void ClienteCarrinhoLimpar(){
    if (clienteVenda != null){
      nvenda.LivroExcluir(clienteVenda);
    }
  }
  
  public static void ClienteCarrinhoComprar(){
    if (clienteVenda == null){
      Console.WriteLine("Nenhum livro no carrinho");
      return;
    }
    List<VendaLivro> livros = nvenda.LivroListar(clienteVenda);
    foreach (VendaLivro livro in livros){
      int idLivro = livro.GetLivro().GetId();
      Livro l = nlivro.Listar(idLivro);
      if (l.GetQtd() < livro.GetQtd()){
        Console.WriteLine("Não há essa quantidade no estoque, limpe o carrinho e tente novamente.");
        return;
      }
    }
    ClienteCarrinhoVisualizar();
    Console.WriteLine("Deseja finalizar sua compra? 1-Sim | 2-Não");
    int reposta = int.Parse(Console.ReadLine());
    if (reposta == 2){
      return;
    }
    else if(reposta == 1){
      foreach (VendaLivro livro in livros){
        int idLivro = livro.GetLivro().GetId();
        Livro l = nlivro.Listar(idLivro);
        int estoque = l.GetQtd();
        estoque = l.GetQtd() - livro.GetQtd();
        l.SetQtd(estoque);
      }
      nvenda.Inserir(clienteVenda, false);
      Console.WriteLine("Deseja deixar seu comentário na sua compra? 1-Sim | 2-Não");
      int escolhaComent = int.Parse(Console.ReadLine());
      if (escolhaComent == 1){
        Console.Write("Deixe seu comentário sobre sua compra: ");
        string comentario = Console.ReadLine();
        clienteVenda.SetComentario(comentario);
        Console.WriteLine();
        Console.WriteLine("Compra confirmada!");
        clienteVenda = null;
      }
      else{
      Console.WriteLine();
      Console.WriteLine("Compra confirmada!");
      clienteVenda = null;
   //   Venda.SetComentario(comentario);
      }
      return;
    }
    else{
      Console.WriteLine("Opção inválida, tente novamente.");
    }
  }

  public static void ClienteComentariosListar(){
    Console.WriteLine("----- Meus Comentários -----");
    List<Venda> vs = nvenda.Listar(clienteLogin);
    if (vs.Count == 0){
      Console.WriteLine("Nenhum comentário feito");
      return;
    }
    int num = 1;
    foreach(Venda v in vs){
      if (v.GetComentario() == null){
        continue;
      }
      Console.WriteLine($"Comentário {num}: {v.GetComentario()}");
      Console.WriteLine();
      num++;
    }
  }

  public static void ClienteAtualizarComentario(){
    Console.WriteLine("----- Atualizar comentário -----");
    List<Venda> vs = nvenda.Listar(clienteLogin);
    if (vs.Count == 0){
      Console.WriteLine("Nenhum comentário feito");
      return;
    }
    foreach(Venda v in vs){
      Console.WriteLine(v);
      foreach (VendaLivro livro in nvenda.LivroListar(v)){
        Console.WriteLine(" " + livro);
      }
      if (v.GetComentario() == null){
        Console.WriteLine("  Sem comentário");
        Console.WriteLine();
        continue;
      }
      Console.WriteLine($"  Comentário: {v.GetComentario()}");
      Console.WriteLine();
    }
    Console.Write("Digite o código da compra que você deseja atualizar o comentário: ");
    int cod = int.Parse(Console.ReadLine());
    foreach (Venda v in vs){
      if (cod == v.GetId()){
        Console.Write("Reescreva seu comentário: ");
        string coment = Console.ReadLine();
        v.SetComentario(coment);
        Console.WriteLine("Atualização Concluída!");
        return;
      }
    }
    Console.WriteLine("Código inválido, tente novamente.");
  }

public static void ClienteApagarComentario(){
    Console.WriteLine("----- Apagar comentário -----");
    List<Venda> vs = nvenda.Listar(clienteLogin);
    if (vs.Count == 0){
      Console.WriteLine("Nenhum comentário para apagar");
      return;
    }
    foreach(Venda v in vs){
      Console.WriteLine(v);
      foreach (VendaLivro livro in nvenda.LivroListar(v)){
        Console.WriteLine(" " + livro);
      }
      Console.WriteLine($"  Comentário: {v.GetComentario()}");
      Console.WriteLine();
    }
    Console.Write("Digite o código da compra que você deseja apagar o comentário: ");
    int cod = int.Parse(Console.ReadLine());
    foreach (Venda v in vs){
      if (v.GetComentario() == null){
        Console.WriteLine("Não existe comentário nessa compra, tente novamente."); 
        return;
      }
      else if (cod == v.GetId()){
        //Apagar comentário
        v.SetComentario(null);
        Console.WriteLine("Comentário Apagado!");
        return;
      }
    }
    Console.WriteLine("Código inválido, tente novamente."); 
  }
}