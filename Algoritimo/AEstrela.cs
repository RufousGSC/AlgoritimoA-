using System;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    public int X, Y;
    public bool Andar;
    public int G, H;
    public int F => G + H;
    public Node Pai = null;

    public Node(int x, int y, bool andar)
    {
        X = x;
        Y = y;
        Andar = andar;
    }
}

public class AEstrela
{
    static int Distancia(Node a, Node b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    public static List<Node> Procurar(Node[,] grid, Node Inicio, Node Fim)
    {
        List<Node> FilaAberta = new List<Node>();
        List<Node> FilaFechada = new List<Node>();

        FilaAberta.Add(Inicio);

        while (FilaAberta.Count > 0)
        {
            Node Atual = FilaAberta.OrderBy(n => n.F).First();

            if (Atual == Fim)
                return Caminho(Inicio, Fim);

            FilaAberta.Remove(Atual);
            FilaFechada.Add(Atual);

            
            DesenharCaminho(grid, FilaFechada, Inicio, Fim);

            
            int i = 0;
            while (i < GetVizinho(grid, Atual).Count)
            {
                Node vizinho = GetVizinho(grid, Atual)[i];

                if (!vizinho.Andar || FilaFechada.Contains(vizinho))
                {
                    i++;
                    continue;
                }

                int novoG = Atual.G + 1;

                if (novoG < vizinho.G || !FilaAberta.Contains(vizinho))
                {
                    vizinho.G = novoG;
                    vizinho.H = Distancia(vizinho, Fim);
                    vizinho.Pai = Atual;

                    if (!FilaAberta.Contains(vizinho))
                        FilaAberta.Add(vizinho);
                }
                i++;
            }
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("---------------");
        }

        return null;
    }

    private static List<Node> Caminho(Node Inicio, Node Fim)
    {
        List<Node> Caminho = new List<Node>();
        Node Atual = Fim;

        while (Atual != Inicio)
        {
            Caminho.Add(Atual);
            Atual = Atual.Pai;
        }

        Caminho.Add(Inicio);
        Caminho.Reverse();

        return Caminho;
    }

    private static List<Node> GetVizinho(Node[,] grid, Node node)
    {
        List<Node> Vizinhos = new List<Node>();
        int[,] Direcao = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        for (int i = 0; i < Direcao.GetLength(0); i++)
        {
            int x = node.X + Direcao[i, 0];
            int y = node.Y + Direcao[i, 1];

            if (x >= 0 && y >= 0 && x < grid.GetLength(0) && y < grid.GetLength(1))
            {
                Vizinhos.Add(grid[x, y]);
            }
        }
        return Vizinhos;
    }

    public static void DesenharCaminho(Node[,] grid, List<Node> caminho, Node inicio, Node fim)
    {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                Node n = grid[x, y];

                if (n == inicio)
                    Console.Write("I ");
                else if (n == fim)
                    Console.Write("F ");
                else if (!n.Andar)
                    Console.Write("# ");
                else if (caminho != null && caminho.Contains(n))
                    Console.Write("* ");
                else
                    Console.Write(". ");
            }
            Console.WriteLine("");
        }
    }
}