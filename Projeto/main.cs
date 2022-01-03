using System;
class MainClass {
  public static void Main() {
    Genero g1 = new Genero(1, "Romance");
    Genero g2 = new Genero(2, "Suspense");
    Console.WriteLine(g1);
    Console.WriteLine(g2);

    Livro p1 = new Livro(1, "Bird Box", 19.70, 320, 10, g1);
    Livro p2 = new Livro(2, "IT - A coisa", 25.50, 250, 15);
    Livro p3 = new Livro(3, "A culpa é das estrelas", 15.40, 313, 5);
    Livro p4 = new Livro(4, "O Duque e Eu", 19.97, 288, 20);
    Console.WriteLine(p1);
    Console.WriteLine(p2);
    Console.WriteLine(p3);
    Console.WriteLine(p4);
    
  }
}



