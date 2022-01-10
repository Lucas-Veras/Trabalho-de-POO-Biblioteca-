    using System;

    class MainClass
    {
    public static NGenero ngenero = new NGenero();
    public static NLivro nlivro = new NLivro();
    public static List<Venda> vendas = new List<Venda>();

    public static void Main()
    {
    int opcao = 999;
    Console.Write("--- ");
    Console.Write("Seja Bem-Vindo(a) a nossa Livraria");
    Console.Write(" ---");
    while (opcao != 0)
    {
        opcao = Menu();
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
                Carrinho();
                break;
            default:
                Console.Write("Opção inválida! Tente novamente!");
                break;
        }
    }
    Console.WriteLine("Obrigado! E tenha uma boa leitura :)");
    }
    public static int Menu()
    {
    Console.WriteLine("\n------------------------------------------");
    Console.WriteLine("1 - Gênero - Listar");
    Console.WriteLine("2 - Gênero - Inserir");
    Console.WriteLine("3 - Gênero - Atualizar");
    Console.WriteLine("4 - Gênero - Excluir");
    Console.WriteLine("5 - Livros - Listar");
    Console.WriteLine("6 - Livros - Inserir");
    Console.WriteLine("7 - Livros - Atualizar");
    Console.WriteLine("8 - Livros - Excluir");
    Console.WriteLine("9 - Carrinho");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    int opcao = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcao;
    }
    public static void ListarGenero()
    {
    Console.WriteLine("------------ Lista de Gêneros ------------");
    Genero[] cs = ngenero.Listar();
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
            //nvenda.Inserir(v);
            Console.WriteLine("Gostaria de adicionar mais algum livro? Se sim, digite o ID, se nao, digite 0: ");
            id = int.Parse(Console.ReadLine());
            if (id == 0) return;
            Console.WriteLine("ID inválido, tente efetuar as operações novamente");
            return;
        }
    }
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
    Console.WriteLine("Deseja finalizar a sua compra? 1 - Sim | 2 - Não");
    int finalizar = int.Parse(Console.ReadLine());
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
                Console.WriteLine($"O valor a pagar no débito é R${total}, deseja finalizar?\n1 - Sim\n2 - Não");
                Console.WriteLine("Obrigado pela compra e volte sempre :)");
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
                Console.WriteLine($"Você pagará {total}X de {total}");
                Console.WriteLine("Deseja finalizar sua compra?\n1 - Sim\n2 - Não");
            }
        }
        if (escolha == 2)
        {
            Console.WriteLine($"O valor final é {total}, faça um pix para o nosso email: livraria@gmail.com");
            Console.WriteLine("E obrigado pela compra :)");
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
            Console.WriteLine($"Total a pagar: R${total}");
            Console.WriteLine($"Código do boleto para pagar: {boleto}{boleto2}{boleto3}{boleto3}{boleto4}{boleto5}{boleto6}");
            Console.WriteLine("E muito obrigado pela compra :)");
        }
    }
    }
    }

