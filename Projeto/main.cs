using System;
class MainClass {
    public static void Main() {
        Genero g1 = new Genero(1, "Romance");
        Genero g2 = new Genero(2, "Suspense");
        Console.WriteLine(g1);
        Console.WriteLine(g2);

        Livro p1 = new Livro(1, "Bird Box", 19.70, 320, 10);
        Livro p2 = new Livro(2, "IT - A coisa", 25.50, 250, 15);
        Livro p3 = new Livro(3, "A culpa é das estrelas", 15.40, 313, 5);
        Livro p4 = new Livro(4, "O Duque e Eu", 19.97, 288, 20);
        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p3);
        Console.WriteLine(p4);
    }
}

class Genero {
    private int id;
    private string nome;

    public Genero(int id, string nome){
        this.id = id;
        this.nome = nome;
    }

    public void SetId(int id){
        this.id = id;
    }
    public void SetNome(string nome){
        this.nome = nome;
    }

    public int GetId(){
        return id;
    }
    public string GetNome(){
        return nome;
    }

    public override string ToString(){
        return id + " - " + nome;
    }
}

class Livro {
    private int id;
    private string nome;
    private double preco;
    private int paginas;
    private int qtd;

    public Livro(int id, string nome, double preco, int paginas, int qtd){
        this.id = id;
        this.nome = nome;
        this.preco = preco > 0 ? preco : 0;
        this.paginas = paginas > 0 ? paginas : 0;
        this.qtd = qtd > 0 ? qtd : 0;
    }
    public Livro(int id, string nome, double preco, int paginas, int qtd, Genero genero) : this(id, nome, preco, paginas, qtd) {

    }
public void SetId(int id){
        this.id = id;
    }
    public void SetNome(string nome){
        this.nome = nome;
    }
    public void SetPreco(double preco){
        this.preco = preco > 0 ? preco : 0;
    }
    public void SetPaginas(int paginas){
        this.paginas = paginas > 0 ? paginas : 0;
    }
    public void SetQtd(int qtd){
        this.qtd = qtd > 0 ? qtd : 0;
    }

    public int GetId(){
        return id;
    }
    public string GetNome(){
        return nome;
    }
    public double GetPreco(){
        return preco;
    }
    public int GetPaginas(){
        return paginas;
    }
    public int GetQtd(){
        return qtd;
    }

    public override string ToString(){
      return id + " - " + nome + " | Preco: R$" + preco.ToString("0.00") + " | Paginas: " + paginas + " | Quantidade: " + qtd;
    }
}