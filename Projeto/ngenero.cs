using System;
using System.Collections;
class NGenero
{
  private Genero[] generos = new Genero[10];
  private int qtdGenero;

  public void Inserir(Genero x)
  {
      if (qtdGenero == generos.Length)
      {
          Array.Resize(ref generos, 2 * generos.Length);
      }
      generos[qtdGenero] = x;
      qtdGenero++;
  }
  public Genero[] Listar()
  {
      Genero[] x = new Genero[qtdGenero];
      Array.Copy(generos, x, qtdGenero);
      return x;
  }
  public Genero Listar(int id)
  {
      for (int i = 0; i < qtdGenero; i++)
      {
          if (generos[i].GetId() == id)
          {
              return generos[i];
          }
      }
      return null;
  }
  public void Atualizar(Genero x)
  {
      Genero genero_atual = Listar(x.GetId());
      if (genero_atual == null)
      {
          return;
      }
      genero_atual.SetNome(x.GetNome());
  }
  public int Indice(Genero x)
  {
      for (int i = 0;i < qtdGenero;i++)
          if (generos[i] == x)
          {
              return i;
          }
      return -1;
  }
  public void Excluir(Genero x)
  {
      int n = Indice(x);
      if (n == -1)
      {
          return;
      }
      for (int i = n; i < qtdGenero-1;i++)
          generos[i] = generos[i+1];
      qtdGenero--;
      Livro[] ps = x.Listar();
      foreach (Livro p in ps)
          p.SetGenero(null);
  }
}