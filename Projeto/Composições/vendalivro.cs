using System;

public class VendaLivro{
  private int qtd;
  private double preco;
  private Livro livro;
  private int livroId;

  public int Qtd { get => qtd; set => qtd = value; }
  public double Preco { get => preco; set => preco = value; }
  public int LivroId { get => livroId; set => livroId = value; }
  public VendaLivro() { }
  
  public VendaLivro(int qtd, Livro livro){
    this.qtd = qtd;
    this.preco = livro.GetPreco();
    this.livro = livro;
    this.livroId = livro.GetId();
  }

  public void SetQtd(int qtd){
    this.qtd = qtd;
  }

  public void SetPreco(double preco){
    this.preco = preco;
  }

  public void SetLivro(Livro livro){
    this.livro = livro;
    this.livroId = livro.GetId();
  }

  public int GetQtd(){
    return qtd;
  }

  public double GetPreco(){
    return preco;
  }

  public Livro GetLivro(){
    return livro;
  }

  public override string ToString(){
    return livro.GetNome() + " - Quantidade: " + qtd + " - Preço: " + preco.ToString("c2");
  }
}