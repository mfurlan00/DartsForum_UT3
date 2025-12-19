// Proyecto UT3 - Mario Furlan
class Program
{
    // Listas principales
    static List<Producto> productos = new List<Producto>();
    static List<Lugar> lugares = new List<Lugar>();
    static List<Evento> eventos = new List<Evento>();
    static List<Perfil> perfiles = new List<Perfil>();
    static List<Pedido> pedidos = new List<Pedido>();

    // Diccionario para inicio de sesión (usuario -> objeto Usuario)
    static Dictionary<string, Usuario> usuarios = new Dictionary<string, Usuario>();

    //Reinicio las sesiones
    static bool sesionIniciada = false;
    static bool esAdmin = false;
    static string usuarioActual = "";           
    static void Main()
    {
        // Introducir datos en los objetos
        IntroducirProductos();
        IntroducirLugares();
        IntroducirEventos();

        // Crear admin
        IntroducirAdmin();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine();
            MenuPrincipal();
            Console.WriteLine("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                SobreNosotros();
            }
            else if (opcion == 2)
            {
                InicioSesion();
            }
            else if (opcion == 3)
            {
                CrearPerfil();
            }
            else if (opcion == 4)
            {
                MenuTienda();
            }
            else if (opcion == 5)
            {
                MenuLugares();
            }
            else if (opcion == 6)
            {
                MostrarEventos();
            }
            else if (opcion == 7)
            {
                VerPerfiles();
            }
            else if (opcion == 8)
            {
                VerPedidos();
            }
            else if (opcion == 9)
            {
                Console.WriteLine("Saliendo...");
                exit = true;
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }

    static void MenuPrincipal()
    {
        Console.WriteLine("----- DartsForum -----");
        Console.WriteLine("--- Menú Principal ---");

        if (sesionIniciada)
        {
            Console.WriteLine("Sesión: " + usuarioActual);
        }
        else
        {
            Console.WriteLine("Sesión: (no iniciada)");
        }

        Console.WriteLine("1. Sobre nosotros");
        Console.WriteLine("2. Iniciar sesión / Cerrar sesión");
        Console.WriteLine("3. Crear perfil");
        Console.WriteLine("4. Ver productos");
        Console.WriteLine("5. ¿Dónde jugar?");
        Console.WriteLine("6. Eventos próximos");

        // Opciones admin
        Console.WriteLine("7. Ver perfiles (admin)");
        Console.WriteLine("8. Ver pedidos (admin)");

        Console.WriteLine("9. Salir");
    }

    static void MenuTienda()
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine();
            Console.WriteLine("--- TIENDA ---");
            Console.WriteLine("1. Dardos completos");
            Console.WriteLine("2. Plumas");
            Console.WriteLine("3. Cañas");
            Console.WriteLine("4. Barriletes");
            Console.WriteLine("5. Puntas");
            Console.WriteLine("6. Ver todos");
            Console.WriteLine("7. Comprar (por referencia)");
            Console.WriteLine("8. Calcular IVA (por referencia)");
            Console.WriteLine("9. Volver");

            Console.WriteLine("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                VerProductosPorCategoria("Dardos completos");
            }
            else if (opcion == 2)
            {
                VerProductosPorCategoria("Plumas");
            }
            else if (opcion == 3)
            {
                VerProductosPorCategoria("Cañas");
            }
            else if (opcion == 4)
            {
                VerProductosPorCategoria("Barriletes");
            }
            else if (opcion == 5)
            {
                VerProductosPorCategoria("Puntas");
            }
            else if (opcion == 6)
            {
                VerProductos();
            }
            else if (opcion == 7)
            {
                CrearPedido();
            }
            else if (opcion == 8)
            {
                CalcularIVAProducto();
            }
            else if (opcion == 9)
            {
                volver = true;
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }

    static void MenuLugares()
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine();
            Console.WriteLine("--- LUGARES ---");
            Console.WriteLine("1. Navarra");
            Console.WriteLine("2. Madrid");
            Console.WriteLine("3. La Rioja");
            Console.WriteLine("4. Aragón");
            Console.WriteLine("5. Ver todos");
            Console.WriteLine("6. Volver");

            Console.WriteLine("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                VerLugaresPorCCAA("Navarra");
            }
            else if (opcion == 2)
            {
                VerLugaresPorCCAA("Madrid");
            }
            else if (opcion == 3)
            {
                VerLugaresPorCCAA("La Rioja");
            }
            else if (opcion == 4)
            {
                VerLugaresPorCCAA("Aragón");
            }
            else if (opcion == 5)
            {
                VerLugares();
            }
            else if (opcion == 6)
            {
                volver = true;
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }

    static void SobreNosotros()
    {
        Console.WriteLine();
        Console.WriteLine("DartsForum es una comunidad local para jugadores de dardos.");
        Console.WriteLine("Aquí puedes consultar productos, lugares donde jugar y próximos eventos.");
    }

    // Inicio de sesión
    static void InicioSesion()
    {
        Console.WriteLine();

        if (sesionIniciada == true)
        {
            Console.WriteLine("Ya tienes una sesión iniciada como: " + usuarioActual);
            Console.WriteLine("1. Cerrar sesión");
            Console.WriteLine("2. Volver");

            int opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1)
            {
                sesionIniciada = false;
                esAdmin = false;
                usuarioActual = "";
                Console.WriteLine("Sesión cerrada.");
            }
            return;
        }

        Console.WriteLine("Inicio de sesión:");
        Console.WriteLine("Usuario:");
        string? user = Console.ReadLine();
        Console.WriteLine("Contraseña:");
        string? pass = Console.ReadLine();

        if (user == null)
        {
            user = "";
        }
        if (pass == null)
        {
            pass = "";
        }

        if (usuarios.ContainsKey(user))
        {
            Usuario u = usuarios[user];
            if (u.contraseña == pass)
            {
                sesionIniciada = true;
                usuarioActual = user;
                esAdmin = (user == "admin");

                Console.WriteLine("Sesión iniciada correctamente.");
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta.");
            }
        }
        else
        {
            Console.WriteLine("El usuario no existe.");
        }
    }

    // Crear perfil
    static void CrearPerfil()
    {
        Console.WriteLine();
        Console.WriteLine("--- CREAR PERFIL ---");

        // Usuario
        Console.WriteLine("Elige un nombre de usuario:");
        string? user = Console.ReadLine();
        if (user == null)
        {
            user = "";
        }

        while (usuarios.ContainsKey(user) || user == "")
        {
            Console.WriteLine("Ese usuario no es válido o ya existe. Prueba con otro:");
            user = Console.ReadLine();
            if (user == null)
            {
                user = "";
            }
        }

        // Datos básicos
        Console.WriteLine("Introduce tu ciudad:");
        string? ciudad = Console.ReadLine();

        Console.WriteLine("Introduce tu edad:");
        int edad = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Introduce tu correo:");
        string? correo = Console.ReadLine();

        // Password (confirmación)
        Console.WriteLine("Crea una contraseña:");
        string? pass1 = Console.ReadLine();
        Console.WriteLine("Repite la contraseña:");
        string? pass2 = Console.ReadLine();

        if (pass1 == null)
        {
            pass1 = "";
        }
        if (pass2 == null)
        {
            pass2 = "";
        }

        while (pass1 != pass2)
        {
            Console.WriteLine("Las contraseñas no coinciden. Intenta otra vez.");
            Console.WriteLine("Contraseña:");
            pass1 = Console.ReadLine();
            Console.WriteLine("Repite la contraseña:");
            pass2 = Console.ReadLine();

            if (pass1 == null)
            {
                pass1 = "";
            }
            if (pass2 == null)
            {
                pass2 = "";
            }
        }

        // id automático
        int nuevoId = usuarios.Count + 1;

        // Crear objetos
        Usuario nuevoUsuario = new Usuario(nuevoId, user, ciudad, edad, correo, pass1);
        Perfil nuevoPerfil = new Perfil(nuevoId, user, ciudad, edad);

        // Guardar en listas
        usuarios.Add(user, nuevoUsuario);
        perfiles.Add(nuevoPerfil);

        Console.WriteLine("Perfil creado correctamente.");
    }

    // Productos
    static void VerProductos()
    {
        Console.WriteLine();
        Console.WriteLine("--- PRODUCTOS ---");

        foreach (Producto p in productos)
        {
            Console.WriteLine(p.referencia + " | " + p.categoria + " | " + p.marca + " | " + p.modelo + " | " + p.precio + "€");
        }
    }

    static void VerProductosPorCategoria(string categoria)
    {
        Console.WriteLine();
        Console.WriteLine("--- " + categoria + " ---");

        foreach (Producto p in productos)
        {
            if (p.categoria == categoria)
            {
                Console.WriteLine(p.referencia + " | " + p.marca + " | " + p.modelo + " | " + p.precio + "€");
            }
        }
    }

    // Crear pedido por referencia
    static void CrearPedido()
    {
        Console.WriteLine();

        if (!sesionIniciada)
        {
            Console.WriteLine("Debes iniciar sesión para comprar.");
            return;
        }

        Console.WriteLine("Introduce la referencia del producto (ej: DC001):");
        string? refProducto = Console.ReadLine();
        if (refProducto == null)
        {
            refProducto = "";
        }

        Producto? producto = BuscarProductoPorReferencia(refProducto);
        if (producto == null)
        {
            Console.WriteLine("No existe un producto con esa referencia.");
            return;
        }

        int idPedido = pedidos.Count + 1;
        Pedido nuevoPedido = new Pedido(idPedido, usuarioActual, refProducto, producto.precio);
        pedidos.Add(nuevoPedido);

        Console.WriteLine("Pedido creado: " + nuevoPedido.Mostrar());
    }

    static Producto? BuscarProductoPorReferencia(string referencia)
    {
        foreach (Producto p in productos)
        {
            if (p.referencia == referencia)
            {
                return p;
            }
        }

        return null;
    }

    // iva
    static void CalcularIVAProducto()
    {
        Console.WriteLine();
        Console.WriteLine("Introduce la referencia del producto:");
        string? refProducto = Console.ReadLine();
        if (refProducto == null)
        {
            refProducto = "";
        }

        Producto? producto = BuscarProductoPorReferencia(refProducto);
        if (producto == null)
        {
            Console.WriteLine("No existe un producto con esa referencia.");
            return;
        }

        double iva = 0.21;
        double precioIva = producto.precio * iva;
        double precioFinal = producto.precio + precioIva;

        Console.WriteLine("Producto: " + producto.referencia + " - " + producto.modelo);
        Console.WriteLine("Precio sin IVA: " + producto.precio + "€");
        Console.WriteLine("IVA (21%): " + precioIva + "€");
        Console.WriteLine("Precio con IVA: " + precioFinal + "€");
    }

    // Lugares
    static void VerLugares()
    {
        Console.WriteLine();
        Console.WriteLine("--- LUGARES ---");

        foreach (Lugar l in lugares)
        {
            Console.WriteLine(l.id + " | " + l.ccaa + " | " + l.nombre + " | " + l.zona + " | " + l.horario);
        }
    }

    static void VerLugaresPorCCAA(string ccaa)
    {
        Console.WriteLine();
        Console.WriteLine("--- LUGARES EN " + ccaa + " ---");

        foreach (Lugar l in lugares)
        {
            if (l.ccaa == ccaa)
            {
                Console.WriteLine(l.id + " | " + l.nombre + " | " + l.zona + " | " + l.horario);
            }
        }
    }

    // Eventos
    static void MostrarEventos()
    {
        Console.WriteLine();
        Console.WriteLine("--- EVENTOS PRÓXIMOS ---");

        foreach (Evento e in eventos)
        {
            Console.WriteLine(e.id + " | " + e.nombre + " | " + e.fecha + " | " + e.lugar);
        }
    }

    // Admin ver perfiles
    static void VerPerfiles()
    {
        Console.WriteLine();

        if (!sesionIniciada || !esAdmin)
        {
            Console.WriteLine("Acceso denegado, solo administradores.");
            return;
        }

        Console.WriteLine("--- PERFILES (ADMIN) ---");

        foreach (Perfil p in perfiles)
        {
            Console.WriteLine(p.id + " | " + p.usuario + " | " + p.ciudad + " | " + p.edad);
        }
    }

    // Admin ver pedidos
    static void VerPedidos()
    {
        Console.WriteLine();

        if (!sesionIniciada || !esAdmin)
        {
            Console.WriteLine("Acceso denegado, solo administradores.");
            return;
        }

        Console.WriteLine("--- PEDIDOS (ADMIN) ---");

        foreach (Pedido p in pedidos)
        {
            Console.WriteLine(p.id + " | " + p.usuario + " | " + p.referencia + " | " + p.total + "€");
        }
    }

    static void IntroducirAdmin()
    {
        // Admin por defecto
        if (!usuarios.ContainsKey("admin"))
        {
            Usuario admin = new Usuario(0, "admin", "-", 0, "admin@local", "admin");
            usuarios.Add("admin", admin);
        }
    }

    static void IntroducirEventos()
    {
        eventos.Add(new Evento(1, "Torneo Local", "15/01/2026", "Pamplona"));
        eventos.Add(new Evento(2, "Liga de Invierno", "02/02/2026", "Madrid"));
        eventos.Add(new Evento(3, "Open Rioja", "20/02/2026", "Logroño"));
        eventos.Add(new Evento(4, "Torneo Amistoso", "05/03/2026", "Villava"));
    }

    // Productos
    static void IntroducirProductos()
    {

        // Dardos completos
        productos.Add(new Producto("Dardos completos", "DC001", "Winmau", "Dardos completos profesionales #01", 44.99));
        productos.Add(new Producto("Dardos completos", "DC002", "Winmau", "Dardos completos profesionales #02", 49.99));
        productos.Add(new Producto("Dardos completos", "DC003", "Winmau", "Daros completos profesionales #03", 54.99));
        productos.Add(new Producto("Dardos completos", "DC004", "Impact", "Dardos completos Edición Especial", 59.99));
        productos.Add(new Producto("Dardos completos", "DC005", "Impact", "Dardos completos Set Ed. Especial Metallica", 79.99));
        productos.Add(new Producto("Dardos completos", "DC006", "Impact", "Dardos completos Set Ed. Especial Iron Maiden", 84.99));
        productos.Add(new Producto("Dardos completos", "DC007", "Impact", "Dardos completos Set Ed. Especial Megadeth", 89.99));
        productos.Add(new Producto("Dardos completos", "DC008", "Impact", "Dardos completos Set Ed. Especial Motorhead", 99.99));

        // Plumas
        productos.Add(new Producto("Plumas", "PL001", "Winmau", "Plumas Iron Maiden", 1.50));
        productos.Add(new Producto("Plumas", "PL002", "Winmau", "Plumas Slayer", 1.50));
        productos.Add(new Producto("Plumas", "PL003", "Winmau", "Plumas Motorhead", 1.50));
        productos.Add(new Producto("Plumas", "PL004", "Winmau", "Plumas Motley Crew", 1.50));
        productos.Add(new Producto("Plumas", "PL005", "Winmau", "Plumas Metallica", 1.50));
        productos.Add(new Producto("Plumas", "PL006", "Winmau", "Plumas Judas Priest", 1.50));
        productos.Add(new Producto("Plumas", "PL007", "Winmau", "Plumas lisas negras", 1.50));
        productos.Add(new Producto("Plumas", "PL008", "Winmau", "Plumas lisas blancas", 1.50));
        productos.Add(new Producto("Plumas", "PL009", "Winmau", "Plumas lisas rojas", 1.50));

        // Cañas
        productos.Add(new Producto("Cañas", "CA001", "Harrows", "Cañas Midi blancas 40mm", 3.00));
        productos.Add(new Producto("Cañas", "CA002", "Harrows", "Cañas Midi negras 40mm", 3.00));
        productos.Add(new Producto("Cañas", "CA003", "Harrows", "Cañas Dimplex M blancas 45mm", 5.50));
        productos.Add(new Producto("Cañas", "CA004", "Harrows", "Cañas Dimplex M negras 45mm", 5.50));
        productos.Add(new Producto("Cañas", "CA005", "Harrows", "Cañas Alamo blancas 47mm", 3.50));
        productos.Add(new Producto("Cañas", "CA006", "Harrows", "Cañas Alamo negras 47mm", 3.50));
        productos.Add(new Producto("Cañas", "CA007", "Harrows", "Cañas Speedline blancas 47mm", 4.50));
        productos.Add(new Producto("Cañas", "CA008", "Harrows", "Cañas Speedline negras 47mm", 4.50));
        productos.Add(new Producto("Cañas", "CA009", "Harrows", "Cañas Supergrip M negras 49mm", 6.50));
        productos.Add(new Producto("Cañas", "CA010", "Harrows", "Cañas Supergrip M blancas 49mm", 6.50));
        productos.Add(new Producto("Cañas", "CA011", "Harrows", "Cañas Supergrip M smokey 49mm", 6.50));

        // Barriletes
        productos.Add(new Producto("Barriletes", "BL001", "Harrows", "Barrilete silver 16g", 5.50));
        productos.Add(new Producto("Barriletes", "BL002", "Harrows", "Barrilete silver 18g", 6.00));
        productos.Add(new Producto("Barriletes", "BL003", "Harrows", "Barrilete silver 20g", 6.50));
        productos.Add(new Producto("Barriletes", "BL004", "Harrows", "Barrilete tungsten 16g", 5.50));
        productos.Add(new Producto("Barriletes", "BL005", "Harrows", "Barrilete tungsten 18g", 6.00));
        productos.Add(new Producto("Barriletes", "BL006", "Harrows", "Barrilete tungsten 20g", 6.50));
        productos.Add(new Producto("Barriletes", "BL007", "Canaveral", "Barrilete SN90 16g", 6.50));
        productos.Add(new Producto("Barriletes", "BL008", "Canaveral", "Barrilete SN90 18g", 7.50));
        productos.Add(new Producto("Barriletes", "BL009", "Canaveral", "Barrilete SN90 20g", 8.50));
        productos.Add(new Producto("Barriletes", "BL010", "Winmau", "Barrilete gold 16g", 6.50));
        productos.Add(new Producto("Barriletes", "BL011", "Winmau", "Barrilete gold 18g", 7.50));
        productos.Add(new Producto("Barriletes", "BL012", "Winmau", "Barrilete gold 20g", 8.50));
        productos.Add(new Producto("Barriletes", "BL013", "Cosmo Darts", "Barrilete Deluxe 20g", 8.50));
        productos.Add(new Producto("Barriletes", "BL014", "Cosmo Darts", "Barrilete Deluxe 22g", 9.99));

        // Puntas
        productos.Add(new Producto("Puntas", "PT001", "Winmau", "50 puntas blandas cortas", 3.50));
        productos.Add(new Producto("Puntas", "PT002", "Winmau", "100 puntas blandas cortas", 5.50));
    }

    // Lugares
    static void IntroducirLugares()
    {
        lugares.Add(new Lugar(1, "Navarra", "Bar Tábata", "Villava", "18:00 - 02:00"));
        lugares.Add(new Lugar(2, "Navarra", "Bar Coyote", "Iturrama", "17:00 - 01:00"));
        lugares.Add(new Lugar(3, "Navarra", "Bar Motobomba", "Casco Antiguo", "19:00 - 03:00"));

        lugares.Add(new Lugar(4, "Madrid", "Entre Darts Rock", "Carabanchel", "20:00 - 03:00"));
        lugares.Add(new Lugar(5, "Madrid", "Bar Bodegas Riojanas", "Centro Madrid", "18:00 - 02:00"));
        lugares.Add(new Lugar(6, "Madrid", "Pool Madrid Club", "Ópera", "18:00 - 02:00"));

        lugares.Add(new Lugar(7, "La Rioja", "Bar Bola Ocho", "Logroño (centro)", "18:00 - 02:00"));
        lugares.Add(new Lugar(8, "La Rioja", "El Bunker Pub Musical", "Logroño (centro)", "20:00 - 04:00"));
        lugares.Add(new Lugar(9, "La Rioja", "Cervecería Dante O'Neal", "Logroño (centro)", "18:00 - 02:00"));
        lugares.Add(new Lugar(10, "La Rioja", "Pause&Play Berceo", "C.C. Berceo", "10:00 - 00:00"));
        lugares.Add(new Lugar(11, "La Rioja", "Bar Viñas", "Calahorra", "18:00 - 02:00"));

        lugares.Add(new Lugar(12, "Aragón", "Pub Dardo", "Zaragoza", "18:00 - 02:00"));
        lugares.Add(new Lugar(13, "Aragón", "Bar Triple", "Huesca", "19:00 - 01:00"));
    }
}