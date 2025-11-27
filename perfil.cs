public class Perfil
{
    //Adtributos de la clase
    private int id;
    private string nombre;
    private string ciudad;
    private int edad;

    //Métodos
    //Constructor
    public Perfil(int id, string nombre, string ciudad, int edad)
    {
        this.id = id;
        this.nombre = nombre;
        this.ciudad = ciudad;
        this.edad = edad;
    }
    //Getters y setters
    public int id {get; set;}
    public string nombre {get; set;}
    public string ciudad {get; set;}
    public int edad {get; set;}
}