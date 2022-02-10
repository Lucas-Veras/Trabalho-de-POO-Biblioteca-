using System;
using System.Collections.Generic;
using System.Collections;

class NCliente{
  private List<Cliente> clientes = new List<Cliente>();
  
  public List<Cliente> Listar()
  {
      clientes.Sort();
      return clientes;
  }

  public Cliente Listar(int id)
  {
      for (int i = 0; i < clientes.Count; i++)
      {
          if (clientes[i].Id == id)
          {
              return clientes[i];
          }
      }
      return null;
  }

  public void Inserir(Cliente x)
  {
      int max = 0;
      foreach(Cliente obj in clientes){
        if (obj.Id > max){
          max = obj.Id;
        }
      }
      x.Id = max + 1;
      clientes.Add(x);
  }
  
  public void Atualizar(Cliente x)
  {
      Cliente cliente_atual = Listar(x.Id);
      if (cliente_atual == null){
          return;
      }
      cliente_atual.Nome = x.Nome;
      cliente_atual.Nascimento = x.Nascimento;
  }
  
  public void Excluir(Cliente x)
  {
      if (x != null){
        clientes.Remove(x);
      }
  }
}