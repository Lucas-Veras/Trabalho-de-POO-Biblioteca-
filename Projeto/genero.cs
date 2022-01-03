using System;

class Genero {
  private int id;
  private string nome;
  private Livro[] livros = new Livro[10];
  private int qtdLivros;
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
  public Livro[] ListarLivros(){
    Livro[] y = new Livro[qtdLivros];
    Array.Copy(livros, y, qtdLivros);
    return y;
  }
  public void InserirLivro(Livro x){
    if (qtdLivros == livros.Length){
      Array.Resize(ref livros, 2*livros.Length);
    }
    livros[qtdLivros] = x;
    qtdLivros++;
  }

  public override string ToString(){
    return id + " - " + nome;
  }
}