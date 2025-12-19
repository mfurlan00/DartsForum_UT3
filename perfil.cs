public class Perfil
{
    // Propiedades
    public int id { get; set; }
    public string? usuario { get; set; }
    public string? ciudad { get; set; }
    public int edad { get; set; }

    // Constructor
    public Perfil(int id, string? usuario, string? ciudad, int edad)
    {
        this.id = id;
        this.usuario = usuario;
        this.ciudad = ciudad;
        this.edad = edad;
    }

    // Métodos
    public string Mostrar()
    {
        return id + " | " + usuario + " | " + ciudad + " | " + edad;
    }
}
