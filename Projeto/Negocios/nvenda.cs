using System;
using System.Collections.Generic;
using System.Linq;

class NVenda{
  private NVenda() { }
  static NVenda obj = new NVenda();
  public static NVenda Singleton { get => obj; }
  
  private List<Venda> vendas = new List<Venda>();

  public List<Venda> Listar(){
    return vendas;
  }

  public List<Venda> Listar(Cliente x){
    List<Venda> vs = new List<Venda>();
    foreach (Venda v in vendas){
      if (v.GetCliente() == x){
        vs.Add(v);
      }
    }
    return vs;
  }

  public Venda ListarCarrinho(Cliente x){
    foreach (Venda v in vendas){
      if (v.GetCliente() == x && v.GetCarrinho()){
        return v;
      }
    }
    return null;
  }

  public void Inserir(Venda v, bool carrinho){
    int max = 0;
  /*  foreach (Venda obj in vendas){
      if(obj.GetId() > max){
        max = obj.GetId();
      }
    }*/
    max = vendas.Max(obj => obj.GetId());
    v.SetId(max + 1);
    vendas.Add(v);
    v.SetCarrinho(carrinho);
  }

  public List<VendaLivro> LivroListar(Venda v){
    return v.LivroListar();
  }

  public void LivroInserir(Venda v, int qtd, Livro l){
    v.LivroInserir(qtd, l);
  }

  public void LivroExcluir(Venda v){
    v.LivroExcluir();
  }

    public void Abrir(){
    Arquivo<List<Venda>> f = new Arquivo<List<Venda>>();
    vendas = f.Abrir("./vendas.xml"); 
    AtualizarCliente();
    AtualizarLivro();
  }

  private void AtualizarCliente(){
    foreach(Venda v in vendas){
      Cliente c = NCliente.Singleton.Listar(v.ClienteId);
      if (c != null){
        v.SetCliente(c);
      }
    }
  }
  
  private void AtualizarLivro(){
    foreach(Venda v in vendas){
      foreach(VendaLivro vl in v.LivroListar()){
        Livro l = NLivro.Singleton.Listar(vl.LivroId);
        if (l != null){
          vl.SetLivro(l);
        }
      }
    }
  }
  
  public void Salvar(){
    Arquivo<List<Venda>> f = new Arquivo<List<Venda>>();
    f.Salvar("./vendas.xml", Listar());
  }
}