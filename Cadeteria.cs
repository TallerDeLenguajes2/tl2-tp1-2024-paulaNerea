public class Cadeteria
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    private List<Cadete> listadoCadetes { get; set; }
    private List<Pedido> listadoPedidos { get; set; }
    
    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        listadoCadetes = new List<Cadete>();
        listadoPedidos = new List<Pedido>();
    }

    public void AgregarCadete(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
    }

    public void QuitarCadete(Cadete cadete)
    {
        listadoCadetes.Remove(cadete);
    }

    public void AgregarPedido(Pedido pedido)
    {
        listadoPedidos.Add(pedido);
    }

    public void QuitarPedido(Pedido pedido)
    {
        listadoPedidos.Remove(pedido);
    }

    public IEnumerable<Pedido> ObtenerPedidos()
    {
        return listadoPedidos.AsReadOnly();
    }

    public Pedido BuscarPedido(int num)
    {
        return listadoPedidos.FirstOrDefault(pedido => pedido.NroPedido == num);
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

    public Cadete BuscarCadetePorId(int id)
    {
        return listadoCadetes.FirstOrDefault(cadete => cadete.Id == id);
    }

    public int JornalACobrar(int id){
        Cadete cadete = BuscarCadetePorId(id);
        if (cadete != null)
        {
            int totalEnvios = listadoPedidos.Count(p => p.CadeteAsignado.Id == id);
            return totalEnvios * 500;
        }
        return 0;
    }

    public void AsignarCadeteAPedido(int idCadete, int nroPedido)
    {
        Pedido pedido = BuscarPedido(nroPedido);
        Cadete cadete = BuscarCadetePorId(idCadete);
        if (pedido != null && cadete != null)
        {
            pedido.AsignarCadete(cadete);
            Console.WriteLine($"Pedido nro: {pedido.NroPedido} Asignado a {cadete.Nombre}");
        }else
        {
            Console.WriteLine("No fue posible asignar el pedido - (Pedido o cadete no encontrado).");
        }
    }

    public void MostrarTodosLosCadetes()
    {
        foreach (Cadete cadete in listadoCadetes)
        {
            cadete.ImprimirInformacion();
        }
    }

    public void Informe()
    { 
        Console.WriteLine("--- Informe Final ---");

        int totalPedidos = listadoPedidos.Count(p => p.CadeteAsignado != null);
        int montoTotal = totalPedidos * 500;;

        foreach (Cadete cadete in listadoCadetes)
        {
            int cantEnvios = listadoPedidos.Count(p => p.CadeteAsignado != null && p.CadeteAsignado.Id == cadete.Id );
            int montoCobrar = cantEnvios * 500; //o puedo usar mi funcion jornal a cobrar en cadeteria
            
            Console.WriteLine($"{cadete.Nombre} - Envios: {cantEnvios} - Monto Ganado: {montoCobrar}");
        }

        double promedio = totalPedidos > 0 ? (double)totalPedidos / listadoCadetes.Count : 0; 
        Console.WriteLine($"Envios Promedio Por Cadete: {promedio} - Total Ganado: {montoTotal}");
    }
}