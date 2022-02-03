using System;
using System.Collections.Generic;
using System.Collections;

class Livro
{
  private int id;
  private string nome;
  private double preco;
  private int paginas;
  private int qtd;
  private Genero genero;
  public Livro(int id, string nome, double preco, int paginas, int qtd)
  {
      this.id = id;
      this.nome = nome;
      this.preco = preco > 0 ? preco : 0;
      this.paginas = paginas > 0 ? paginas : 0;
      this.qtd = qtd > 0 ? qtd : 0;
  }
  public Livro(int id, string nome, double preco, int paginas, int qtd, Genero genero) : this(id, nome, preco, paginas, qtd)
  {
      this.genero = genero;
  }
  public void SetId(int id)
  {
      this.id = id;
  }
  public void SetNome(string nome)
  {
      this.nome = nome;
  }
  public void SetPreco(double preco)
  {
      this.preco = preco > 0 ? preco : 0;
  }
  public void SetPaginas(int paginas)
  {
      this.paginas = paginas > 0 ? paginas : 0;
  }
  public void SetQtd(int qtd)
  {
      this.qtd = qtd > 0 ? qtd : 0;
  }
  public void SetGenero(Genero genero)
  {
      this.genero = genero;
  }

  public int GetId()
  {
      return id;
  }
  public string GetNome()
  {
      return nome;
  }
  public double GetPreco()
  {
      return preco;
  }
  public int GetPaginas()
  {
      return paginas;
  }
  public int GetQtd()
  {
      return qtd;
  }
  public Genero GetGenero()
  {
      return genero;
  }

  public override string ToString()
  {
      if (genero == null)
      {
          return id + " - " + nome + " | Preco: R$" + preco.ToString("0.00") + " | Gênero: Sem classificação" + " | Paginas: " + paginas + " | Quantidade: " + qtd;
      }
      else
      {
          return id + " - " + nome + " | Preco: R$" + preco.ToString("0.00") + " | Gênero: " + genero + " | Paginas: " + paginas + " | Quantidade: " + qtd;
      }
  }
}

class LivroIdComp : IComparer {
  public int Compare(object x, object y){
    Livro a = (Livro) x;
    Livro b = (Livro) y;
    return a.GetId().CompareTo(b.GetId());
  }
}