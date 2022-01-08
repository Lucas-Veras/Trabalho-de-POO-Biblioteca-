using System;

class NVenda{
  private Venda[] vendas = new Venda[10];
  private int qtdVendas;

  public void Inserir(Venda x){
    if (qtdVendas == vendas.Length){
      Array.Resize(ref vendas, 2*vendas.Length);
    }
    vendas[qtdVendas] = x;
    qtdVendas++;
  }
  public Venda[] Listar(){
    Venda[] x = new Venda[qtdVendas];
    Array.Copy(vendas, x, qtdVendas);
    return x;
  }
  public Venda Listar(int id){
    for (int i = 0; i < qtdVendas; i++){
      if (vendas[i].GetId() == id){
        return vendas[i];
      }
    }
    return null;
  }
}