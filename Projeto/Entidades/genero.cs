using System;
using System.Collections;

class Genero
{
  private int id, qtdLivros, ll;
  private string nome;
  private Livro[] livros = new Livro[10];
  
  public Genero(int id, string nome)
  {
      this.id = id;
      this.nome = nome;
  }

  public void SetId(int id)
  {
      this.id = id;
  }

  public void SetNome(string nome)
  {
      this.nome = nome;
  }

  public int GetId()
  {
      return id;
  }

  public string GetNome()
  {
      return nome;
  }

  public Livro[] Listar()
  {
      Livro[] y = new Livro[qtdLivros];
      Array.Copy(livros, y, qtdLivros);
      return y;
  }

  private int Indice(Livro l)
  {
      for (int i = 0; i < ll; i++)
      {
          if (livros[i] == l)
          {
              return i;
          }
      }
      return -1;
  }
  
  public void InserirLivro(Livro x)
  {
      if (qtdLivros == livros.Length)
      {
          Array.Resize(ref livros, 2 * livros.Length);
      }
      livros[qtdLivros] = x;
      qtdLivros++;
  }

  public void ExcluirLivro(Livro x)
  {
      int ind = Indice(x);
      if (ind == -1)
      {
          return;
      }
      for (int i = ind; i < ll - 1; i++)
      {
          livros[i] = livros[i + 1];
      }
      ll--;
  }

  public override string ToString()
  {
      return id + " - " + nome;
  }
}

class GeneroIdComp : IComparer {
  public int Compare(object x, object y){
    Genero a = (Genero) x;
    Genero b = (Genero) y;
    return a.GetId().CompareTo(b.GetId());
  }
}