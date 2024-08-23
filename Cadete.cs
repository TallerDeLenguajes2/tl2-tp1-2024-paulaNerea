public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoPedidos;

    public int Id {get => id; set => id = value; }
    public string Nombre {get => nombre; set => nombre = value; }
    public string Direccion {get => direccion; set => direccion = value; }
    public string Telefono {get => telefono; set => telefono = value; }
    public List<Pedido> ListadoPedidos {get => listadoPedidos; set => listadoPedidos = value; }
    
    public Cadete(){
        ListadoPedidos = new List<Pedido>();
    } 

    public void AgregarPedido(Pedido pedido){
        listadoPedidos.Add(pedido);
    }

    public void QuitarPedido(Pedido pedido){
        listadoPedidos.Remove(pedido);
    }
}