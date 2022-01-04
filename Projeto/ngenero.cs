using System;

class NGenero{
  private Genero[] generos = new Genero[10];
  private int qtdGenero;

  public void Inserir(Genero x){
    if (qtdGenero == generos.Length){
      Array.Resize(ref generos, 2*generos.Length);
    }
    generos[qtdGenero] = x;
    qtdGenero++;
  }
  public Genero[] Listar(){
    Genero[] x = new Genero[qtdGenero];
    Array.Copy(generos, x, qtdGenero);
    return x;
  }
  public Genero[] Listar(int id){
    for (int i = 0; i < qtdGenero; i++){
      if (generos[i].GetId() == id){
        return generos;
      }
    }
    return null;
  }
}