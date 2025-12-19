public class Lugar
{
    // Propiedades
    public int id { get; set; }
    public string? ccaa { get; set; }
    public string? nombre { get; set; }
    public string? zona { get; set; }
    public string? horario { get; set; }

    // Constructor
    public Lugar(int id, string? ccaa, string? nombre, string? zona, string? horario)
    {
        this.id = id;
        this.ccaa = ccaa;
        this.nombre = nombre;
        this.zona = zona;
        this.horario = horario;
    }

    // Métodos
    public string Mostrar()
    {
        return id + " | " + ccaa + " | " + nombre + " | " + zona + " | " + horario;
    }
}
