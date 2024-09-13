public enum EstadoPedido
{
    Entregado,
    Cancelado,
    EnProceso
}
public class Pedido
{
    public int NroPedido { get; set; }
    public string Obs { get; set; }
    public Cliente MiCliente { get; private set; }
    public EstadoPedido Estado { get; set; }

    public Pedido(int nroPedido, string obs, string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferenciaDireccionCliente)
    {
        NroPedido = nroPedido;
        Obs = obs;
        MiCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferenciaDireccionCliente);
        Estado = EstadoPedido.EnProceso;
    }

    public string VerDireccionCliente()
    {
        return MiCliente.Direccion;
    }

    public void VerDatosCliente()
    {
        Console.WriteLine("---Datos del Cliente---");
        Console.WriteLine($"Nombre: {MiCliente.Nombre}");
        Console.WriteLine($"Direccion: {MiCliente.Direccion}");
        Console.WriteLine($"Telefono: {MiCliente.Telefono}");
        Console.WriteLine($"Datos de Referencia: {MiCliente.DatosReferenciaDireccion}");
    }

    //cambio el estado del pedido
    public void CambiarEstado(EstadoPedido nuevo)
    {
        Estado = nuevo;
    }
}