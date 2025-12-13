namespace Scripts
{
    public class Fila
    {
        public Node[] fila = new Node[50];
        public int fim = 0;
        public void Add(Node node)
        {
            if(fim < fila.Length)
            {
                fila[fim] = node;
                fim++;
            }
        }
        public void Remove()
        {
            if (fim > 0)
            {
                for (int i = 1; i < fim; i++)
                {
                    fila[i - 1] = fila[i];
                }

                fim--;
            }
        }
        public Node GetElemento() 
        {
            return fila[0];
        }

    }
}