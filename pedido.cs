public class Pedido
{
    //Atributos
    private int id;
    private string usuario;
    private string referencia;
    public double total;

    //Métodos
    //Constructor
    public Pedido(int id, string usuario, string referencia, double total)
    {
        this.id = id;
        this.usuario = usuario;
        this.referencia = referencia;
        this.total = total;
    }

    //Getters y setters
    public int id {get; set;}
    public string usuario {get; set;}
    public string referencia {get; set;}
    public double total {get; set;}
}