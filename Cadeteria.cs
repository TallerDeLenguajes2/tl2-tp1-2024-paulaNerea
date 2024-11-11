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

    public void AgregarCadete(int id, string nombre, string direccion, string telefono)
    {
        Cadete cadete = new Cadete(id, nombre, direccion, telefono);
        listadoCadetes.Add(cadete);
    }

    public void QuitarCadete(int id)
    {
        Cadete cadete = BuscarCadetePorId(id);
        listadoCadetes.Remove(cadete);
    }

    public void AgregarPedido(int nroPedido, string obs, string clienteNombre, string clienteDireccion, string clienteTelefono, string clienteDatosReferenciaDireccion)
    {
        Pedido pedido = new Pedido(nroPedido, obs, clienteNombre, clienteDireccion, clienteTelefono, clienteDatosReferenciaDireccion);
        listadoPedidos.Add(pedido);
    }

    public void QuitarPedido(int nroPedido)
    {
        Pedido pedido = BuscarPedido(nroPedido);
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

    public bool YaExiste(int num)
    {
        return listadoPedidos.Any(pedido => pedido.NroPedido == num);
    }

    public string CambiarEstadoPedido(int nroPedido, int numEstado)
    {
        Pedido pedido = BuscarPedido(nroPedido);
        if (pedido != null)
        {
            pedido.CambiarEstado((EstadoPedido)numEstado);
            return $"Se cambio el estado del pedido a {(EstadoPedido)numEstado}";
        }else
        {
            return "El pedido no es valido";
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

    public string AsignarCadeteAPedido(int idCadete, int nroPedido)
    {
        Pedido pedido = BuscarPedido(nroPedido);
        Cadete cadete = BuscarCadetePorId(idCadete);
        if (pedido != null && cadete != null)
        {
            pedido.AsignarCadete(cadete);
            return $"Pedido nro: {pedido.NroPedido} Asignado a {cadete.Nombre}";
        }else
        {
            return "No fue posible asignar el pedido - (Pedido o cadete no encontrado).";
        }
    }

    public void MostrarTodosLosCadetes()
    {
        foreach (Cadete cadete in listadoCadetes)
        {
            cadete.ImprimirInformacion();
        }
    }

    public List<string> Informe()
    { 
        List<string> informe = new List<string>{
            "--- Informe Final ---"
        };

        int totalPedidos = listadoPedidos.Count(p => p.CadeteAsignado != null);
        int montoTotal = totalPedidos * 500;;

        foreach (Cadete cadete in listadoCadetes)
        {
            int cantEnvios = listadoPedidos.Count(p => p.CadeteAsignado != null && p.CadeteAsignado.Id == cadete.Id );
            int montoCobrar = cantEnvios * 500; //o puedo usar mi funcion jornal a cobrar en cadeteria
            
            informe.Add($"{cadete.Nombre} - Envios: {cantEnvios} - Monto Ganado: {montoCobrar}");
        }

        double promedio = totalPedidos > 0 ? (double)totalPedidos / listadoCadetes.Count : 0; 
        informe.Add($"Envios Promedio Por Cadete: {promedio} - Total Ganado: {montoTotal}");

        return informe;

    }
}