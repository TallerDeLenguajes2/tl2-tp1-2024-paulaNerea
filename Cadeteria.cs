public class Cadeteria
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    private List<Cadete> listadoCadetes { get; set; }
    
    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        listadoCadetes = new List<Cadete>();
    }

    public void AgregarCadete(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
    }

    public void QuitarCadete(Cadete cadete)
    {
        listadoCadetes.Remove(cadete);
    }

    public void AsignarPedido(Cadete cadete, Pedido pedido)
    {
        cadete.AgregarPedido(pedido);
    }

    public void QuitarPedido(Cadete cadete, Pedido pedido)
    {
        cadete.QuitarPedido(pedido);
    }

    public Pedido BuscarPedido(int num)
    {
        foreach (Cadete cadete in listadoCadetes)
        {
            Pedido encontrado = cadete.BuscarPedidoPorNum(num);
            if (encontrado != null)
            {
                return encontrado;
            }
        }
        return null; 
    }

    public void CambiarEstadoPedido(Pedido pedido, EstadoPedido nuevo)
    {
        if (pedido != null)
        {
            pedido.CambiarEstado(nuevo);
            Console.WriteLine("Se cambio el estado del pedido");
        }else
        {
            Console.WriteLine("El pedido no es valido");
        }
    }

    public void MostrarTodosLosCadetes()
    {
        foreach (Cadete cadete in listadoCadetes)
        {
            cadete.ImprimirInformacion();
        }
    }
}