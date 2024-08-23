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

    public Pedido(int nroPedido, string obs, string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferenciaDireccionCliente, EstadoPedido estado)
    {
        NroPedido = nroPedido;
        Obs = obs;
        MiCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferenciaDireccionCliente);
        Estado = estado;
    }
}