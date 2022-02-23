using System;
using System.Collections.Generic;

class Venda
  {
    private int id;
    private DateTime data;
    private bool carrinho;
    private Cliente cliente;
    private List<VendaLivro> livros = new List<VendaLivro>();
    private string comentario;
  
    public Venda(DateTime data, Cliente cliente){
      this.data = data;
      this.carrinho = true;
      this.cliente = cliente;
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public void SetData(DateTime data)
    {
        this.data = data;
    }

    public void SetCarrinho(bool carrinho)
    {
        this.carrinho = carrinho;
    }

    public void SetCliente(Cliente cliente)
    {
        this.cliente = cliente;
    }

    public void SetComentario(string comentario){
        this.comentario = comentario;
    }

    public int GetId()
    {
        return id;
    }

    public DateTime GetData()
    {
        return data;
    }

    public bool GetCarrinho()
    {
        return carrinho;
    }

    public Cliente GetCliente()
    {
        return cliente;
    }

    public string GetComentario(){
        return comentario;
    }

    public override string ToString()
    {
        if(carrinho){
          return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + " - Cliente: " + cliente.Nome + " - carrinho";
        }
        else{
          return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + " - Cliente: " + cliente.Nome;
        }
    }

    private VendaLivro LivroListar(Livro x){
      foreach(VendaLivro vl in livros){
        if(vl.GetLivro() == x){
          return vl;
        }
      }
       return null;
    }

    public List<VendaLivro> LivroListar(){
      return livros;
    }

    public void LivroInserir(int qtd, Livro l){
      VendaLivro livro = LivroListar(l);
      if(livro == null){
        livro = new VendaLivro(qtd, l);
        livros.Add(livro);
      }
      else{
        livro.SetQtd(livro.GetQtd() + qtd);
      }
    }

    public void LivroExcluir(){
      livros.Clear();
    }
}
// Sempre insere mas quando remove, remove todos.