using System;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Linq;

class NGenero
{
  private NGenero() { }
  static NGenero obj = new NGenero();
  public static NGenero Singleton { get => obj; }
  
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
    /*  Genero[] x = new Genero[qtdGenero];
      Array.Copy(generos, x, qtdGenero);
      return x;*/
      return generos.Take(qtdGenero).OrderBy(x => x.GetNome()).ToArray();
  }
  public Genero Listar(int id)
  {
    /*
      for (int i = 0; i < qtdGenero; i++)
      {
          if (generos[i].GetId() == id)
          {
              return generos[i];
          }
      }
      return null;
    */
    var x = generos.Where(obj => obj.GetId() == id);
    if(x.Count() == 0) return null;
    return x.First();
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

  public void Abrir(){
    Arquivo<Genero[]> f = new Arquivo<Genero[]>();
    generos = f.Abrir("./generos.xml"); 
    qtdGenero = generos.Length;
    
  /*  XmlSerializer xml = new XmlSerializer(typeof(Genero[]));
    StreamReader f = new StreamReader("./generos.xml", Encoding.Default);
    generos = (Genero[]) xml.Deserialize(f);
    f.Close();
    qtdGenero = generos.Length;*/
  }

  public void Salvar(){
    Arquivo<Genero[]> f = new Arquivo<Genero[]>();
    f.Salvar("./generos.xml", Listar());

    /*
    XmlSerializer xml = new XmlSerializer(typeof(Genero[]));
    StreamWriter f = new StreamWriter("./generos.xml", false, Encoding.Default);
    xml.Serialize(f, Listar());
    f.Close();*/
  }
}