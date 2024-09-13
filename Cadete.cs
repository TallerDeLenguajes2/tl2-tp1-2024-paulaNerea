public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listaPedidos;

    public int Id { get => id; private set => id = value; }
    public string Nombre { get => nombre; private set => nombre = value; }
    public string Direccion { get => direccion; private set => direccion = value; }
    public string Telefono { get => telefono; private set => telefono = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; private set => listaPedidos = value; }
    
    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        ListaPedidos = new List<Pedido>();
    } 

    public int JornalACobrar()
    {
        int pedidosEntregados = 0;
        foreach (Pedido pedido in ListaPedidos)
        {
            if (pedido.Estado == EstadoPedido.Entregado)
            {
                pedidosEntregados++;
            }
        }
        return 500 * pedidosEntregados;
    }

    public void AgregarPedido(Pedido pedido){
        ListaPedidos.Add(pedido);
    }

    public void QuitarPedido(Pedido pedido){ //o entregar
        ListaPedidos.Remove(pedido);
    }

    public int TotalPedidos() 
    {
        return ListaPedidos.Count;
    }

    public Pedido BuscarPedidoPorNum(int num)
    {
        foreach (Pedido pedido in ListaPedidos)
        {
            if (pedido.NroPedido == num)
            {
                return pedido;
            }
        }
        return null;
    }

    public void ImprimirInformacion()
    {
        Console.WriteLine($"ID: {Id}, Nombre: {Nombre}, Dirección: {Direccion}, Teléfono: {Telefono}");
    }


}

