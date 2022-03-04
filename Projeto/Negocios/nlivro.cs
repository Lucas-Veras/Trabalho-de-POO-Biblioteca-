using System;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class NLivro
{
  private NLivro() { }
  static NLivro obj = new NLivro();
  public static NLivro Singleton { get => obj; }
  
  private Livro[] livros = new Livro[10];
  private int ll;

  public Livro[] Listar()
  {
      Livro[] l = new Livro[ll];
      Array.Copy(livros, l, ll);
      return l;
  }

  public Livro Listar(int id)
  {
      for (int i = 0; i < ll; i++)
      {
          if (livros[i].GetId() == id)
          {
              return livros[i];
          }
      }
      return null;
  }

  public void Inserir(Livro l)
  {
      if (ll == livros.Length)
      {
          Array.Resize(ref livros, 2 * livros.Length);
      }
      livros[ll] = l;
      ll++;
      Genero g = l.GetGenero();
      if (g != null)
      {
          g.InserirLivro(l);
      }
  }

  public void Atualizar(Livro l)
  {
      Livro z = Listar(l.GetId());
      if (z == null)
      {
          return;
      }
      z.SetNome(l.GetNome());
      z.SetPreco(l.GetPreco());
      z.SetPaginas(l.GetPaginas());
      z.SetQtd(l.GetQtd());
      if (z.GetGenero() != null)
      {
          z.GetGenero().ExcluirLivro(z);
      }
      z.SetGenero(l.GetGenero());
      if (z.GetGenero() != null)
      {
          z.GetGenero().InserirLivro(z);
      }
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

  public void Excluir(Livro l)
  {
      int ind = Indice(l);
      if (ind == -1)
      {
          return;
      }
      for (int i = ind; i < ll - 1; i++)
      {
          livros[i] = livros[i + 1];
      }
      ll--;
      Genero g = l.GetGenero();
      if (g != null)
      {
          g.InserirLivro(l);
      }
  }

  public void Abrir(){
    Arquivo<Livro[]> f = new Arquivo<Livro[]>();
    livros = f.Abrir("./livros.xml"); 
    ll = livros.Length;
    AtualizarGenero();
    
   /* XmlSerializer xml = new XmlSerializer(typeof(Livro[]));
    StreamReader f = new StreamReader("./livros.xml", Encoding.Default);
    livros = (Livro[]) xml.Deserialize(f);
    f.Close();
    ll = livros.Length;
    AtualizarGenero();*/
  }

  private void AtualizarGenero(){
    for(int i = 0; i < ll; i++){
      Livro l = livros[i];
      Genero g = NGenero.Singleton.Listar(l.GeneroId);
      if (g != null){
        l.SetGenero(g);
        g.InserirLivro(l);
      }
    }
  }

  public void Salvar(){
    Arquivo<Livro[]> f = new Arquivo<Livro[]>();
    f.Salvar("./livros.xml", Listar()); 
    
    /*XmlSerializer xml = new XmlSerializer(typeof(Livro[]));
    StreamWriter f = new StreamWriter("./livros.xml", false, Encoding.Default);
    xml.Serialize(f, Listar());
    f.Close();*/
  }
}