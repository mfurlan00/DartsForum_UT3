public class Pedido
{
    // Propiedades
    public int id { get; set; }
    public string? usuario { get; set; }
    public string? referencia { get; set; }
    public double total { get; set; }

    // Constructor
    public Pedido(int id, string? usuario, string? referencia, double total)
    {
        this.id = id;
        this.usuario = usuario;
        this.referencia = referencia;
        this.total = total;
    }

    // Métodos
    public string Mostrar()
    {
        return id + " | " + usuario + " | " + referencia + " | " + total;
    }
}
