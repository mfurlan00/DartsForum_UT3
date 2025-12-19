public class Usuario
{
    // Propiedades
    public int id { get; set; }
    public string? nombreUsuario { get; set; }
    public string? ciudad { get; set; }
    public int edad { get; set; }
    public string? correo { get; set; }
    public string? contraseña { get; set; }

    // Constructor
    public Usuario(int id, string? nombreUsuario, string? ciudad, int edad, string? correo, string? contraseña)
    {
        this.id = id;
        this.nombreUsuario = nombreUsuario;
        this.ciudad = ciudad;
        this.edad = edad;
        this.correo = correo;
        this.contraseña = contraseña;
    }

    // Métodos
    public string Mostrar()
    {
        return id + " | " + nombreUsuario + " | " + ciudad + " | " + edad + " | " + correo;
    }
}
