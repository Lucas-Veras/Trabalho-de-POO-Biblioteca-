using System;

class VendaLivro{
  private int qtd;
  private double preco;
  private Livro livro;
  public VendaLivro(int qtd, double preco, Livro livro){
    this.qtd = qtd;
    this.preco = livro.GetPreco();
    this.livro = livro;
  }
  public void SetQtd(int qtd){
    this.qtd = qtd;
  }
  public void SetQtd(double preco){
    this.preco = preco;
  }
  public void SetLivro(Livro livro){
    this.livro = livro;
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
    return livro.GetNome() + " - Quantidade: " + qtd + " - Preço: R$" + preco.ToString("c2");
  }
}