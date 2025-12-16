using System;
using System.Collections.Generic;

       int Linha = 5, Coluna = 5;
        Node[,] grid = new Node[Coluna, Linha];

        for (int i = 0; i < Linha; i++)
        {
            for(int j = 0; j < Coluna; j++)
            {
                grid[i, j] = new Node(i, j, true);
            }
        }

        grid[4, 3].Andar = false;
        grid[3, 3].Andar = false; 
        List<Node> caminho = AEstrela.Procurar(grid, grid[4, 0], grid[2, 4]);

        if (caminho != null)
        {
            Console.WriteLine("Caminho final:");
            AEstrela.DesenharCaminho(grid, caminho, grid[4, 0], grid[2, 4]);
        }
        else
        {
            Console.WriteLine("Caminho não encontrado!");
        };


