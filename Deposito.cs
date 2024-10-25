public class Deposito
{
    private List<Pedido> pedidos;
    private static int contadorPedidos = 0; 

    public Deposito()
    {
        pedidos = new List<Pedido>();
    }

    public void AgregarPedido(Pedido pedido)
    {
        pedidos.Add(pedido);
        Console.WriteLine($"Pedido {pedido.NroPedido} agregado al depósito.");
    }

    public List<Pedido> ObtenerPedidos()
    {
        return pedidos;
    }

    public Pedido BuscarPedidoPorNum(int num)
    {
        foreach (Pedido pedido in pedidos)
        {
            if (pedido.NroPedido == num)
            {
                return pedido;
            }
        }
        return null;
    }

    public void QuitarPedido(int nro)
    {
        pedidos.Remove(BuscarPedidoPorNum(nro));
        Console.WriteLine($"Pedido removido del depósito.");
    }

    public void VerPedidos()
    {
        if (pedidos.Count > 0)
        {
            Console.WriteLine("Pedidos en el depósito:");
            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"Pedido {pedido.NroPedido}: Cliente {pedido.MiCliente.Nombre}, Dirección: {pedido.VerDireccionCliente()}");
            }
        }
        else
        {
            Console.WriteLine("No hay pedidos en el depósito.");
        }
    }
}
