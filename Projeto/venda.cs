/*using System;
using System.Collections.Generic;
using System.Collections;

class Venda
  {
    private int id, qtd;
    private string nome;
    private double preco;
    private Venda venda;
    public Venda(int id, string nome, double preco, int qtd)
    {
        this.id = id;
        this.nome = nome;
        this.preco = preco > 0 ? preco : 0;
        this.qtd = qtd > 0 ? qtd : 0;
    }
    public void SetId(int id)
    {
        this.id = id;
    }
    public void SetNome(string nome)
    {
        this.nome = nome;
    }
    public void SetPreco(double preco)
    {
        this.preco = preco > 0 ? preco : 0;
    }
    public void SetQtd(int qtd)
    {
        this.qtd = qtd > 0 ? qtd : 0;
    }

    public int GetId()
    {
        return id;
    }
    public string GetNome()
    {
        return nome;
    }
    public double GetPreco()
    {
        return preco;
    }
    public int GetQtd()
    {
        return qtd;
    }
    public override string ToString()
    {
        return id + " - " + nome + " | Preco: R$" + preco.ToString("0.00") + " | Quantidade: " + qtd;
    }
}
*/