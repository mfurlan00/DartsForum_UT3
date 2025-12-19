public class Producto
{
    public string referencia { get; set; }
    public string categoria { get; set; }
    public string marca { get; set; }
    public string modelo { get; set; }
    public double precio { get; set; }

    public Producto(string categoria, string referencia, string marca, string modelo, double precio)
    {
        this.categoria = categoria;
        this.referencia = referencia;
        this.marca = marca;
        this.modelo = modelo;
        this.precio = precio;
    }

    // Métodos
    public string Mostrar()
    {
        return referencia + " | " + categoria + " | " + marca + " | " + modelo + " | " + precio;
    }
}
