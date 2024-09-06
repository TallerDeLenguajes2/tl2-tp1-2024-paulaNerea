public class Cadeteria
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> ListadoCadetes { get; set; }
    
    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        ListadoCadetes = new List<Cadete>();
    }

    public void AgregarCadete(Cadete cadete)
    {
        ListadoCadetes.Add(cadete);
    }

    public void QuitarCadete(Cadete cadete)
    {
        ListadoCadetes.Remove(cadete);
    }

    public void AsignarPedido(Cadete cadete, Pedido pedido)
    {
        cadete.AgregarPedido(pedido);
    }
}