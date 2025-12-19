public class Evento
{
    // Propiedades
    public int id { get; set; }
    public string? nombre { get; set; }
    public string? fecha { get; set; }
    public string? lugar { get; set; }

    // Constructor
    public Evento(int id, string? nombre, string? fecha, string? lugar)
    {
        this.id = id;
        this.nombre = nombre;
        this.fecha = fecha;
        this.lugar = lugar;
    }

    // Métodos
    public string Mostrar()
    {
        return id + " | " + nombre + " | " + fecha + " | " + lugar;
    }
}
