class Desarrollo
{
    public static void RegistraMotor()
    {
        Console.Clear();
        Console.WriteLine("Registro de motor...");
        Console.WriteLine("*************");
        var motorista = new Motorista();
        motorista.cedula = Utils.Input("cedula: ");
        motorista.nombre = Utils.Input("nombre: ");
        motorista.marca = Utils.Input("marca: ");
        motorista.modelo = Utils.Input("modelo: ");
        motorista.placa = Utils.Input("placa: ");
        motorista.chasis = Utils.Input("chasis: ");
        motorista.telefono = Utils.Input("telefono: ");
        motorista.direccion = Utils.Input("Direccion: ");
        motorista.latitude = Utils.Input("Latitude: ");
        motorista.longitude = Utils.Input("Longitude: ");
        motorista.actividad = Utils.Input("Actividad: ");
        motorista.descripcion = Utils.Input("Descripcion: ");
        Archivo.Guardar(motorista);
        Utils.Pausa("Motor Registrado!");



    }

    public static void EditarMotor()
    {
        Console.Clear();
        Console.WriteLine("Editar Motor");
        Console.WriteLine("*************");
        var motores = Archivo.ListaMotoristas();
        if (motores.Count == 0)
        {
            Utils.Pausa("No hay motores registrados");
            return;
        }
        Console.WriteLine("Motores registrados: ");

        foreach (var motor in motores)
        {
            Console.WriteLine(@$"
            posicion: {motores.IndexOf(motor) + 1}
            Marca: {motor.marca}
            Modelo: {motor.modelo}
            Cedula: {motor.cedula}
            Nombre: {motor.nombre}
            -------------------------
            
            ");
        }
        int posicion = Utils.InputInt("Ingrese la posicion del motor que quiere editar o 0 (cero) para cancelar: ");
        if (posicion == 0)
        {
            Utils.Pausa("Cancelado");
            return;
        }

        var motorEditar = motores[posicion - 1];

        motorEditar.cedula = Utils.InputModificar("CEDULA ", motorEditar.cedula);
        motorEditar.nombre = Utils.InputModificar("NOMBRE ", motorEditar.nombre);
        motorEditar.marca = Utils.InputModificar("MARCA ", motorEditar.marca);
        motorEditar.modelo = Utils.InputModificar("MODELO ", motorEditar.modelo);
        motorEditar.placa = Utils.InputModificar("PLACA ", motorEditar.placa);
        motorEditar.chasis = Utils.InputModificar("CHASIS ", motorEditar.chasis);
        motorEditar.telefono = Utils.InputModificar("TELEFONO ", motorEditar.telefono);
        motorEditar.direccion = Utils.InputModificar("DIRECCION ", motorEditar.direccion);
        motorEditar.latitude = Utils.InputModificar("LATITUDE ", motorEditar.latitude);
        motorEditar.longitude = Utils.InputModificar("LONGITUDE ", motorEditar.longitude);
        motorEditar.actividad = Utils.InputModificar("ACTIVIDAD ", motorEditar.actividad);
        motorEditar.descripcion = Utils.InputModificar("DESCRIPCION ", motorEditar.descripcion);
        Archivo.Guardar(motorEditar);
        Utils.Pausa("Motor editado");





    }

    public static void VerMapa()
    {
        Console.WriteLine("Ver Mapa");

        var marcadores = "";

        var motores = Archivo.ListaMotoristas();

        foreach (var motor in motores)
        {
            marcadores += @$"

                
                var marker = L.marker([{motor.latitude}, {motor.longitude}])
                .addTo(map)
                .bindPopup(`
                <h3>{motor.nombre}</h3>
                Marca: {motor.marca}<br/>
                Modelo: {motor.modelo}<br/>
                Placa: {motor.placa}<br/>
                Uso: {motor.actividad}<br/>
                
                `);

            ";
        }

        var plantilla = System.IO.File.ReadAllText("plantilla.html");
        plantilla = plantilla.Replace("CODIGODINAMICOC#", marcadores);

        System.IO.File.WriteAllText("mapa.html", plantilla);
        var uri = "mapa.html";
        var psi = new System.Diagnostics.ProcessStartInfo();
        psi.UseShellExecute = true;
        psi.FileName = uri;
        System.Diagnostics.Process.Start(psi);

        Utils.Pausa("Mapa abierto");
    }

    public static void Imprimir()
    {

        Console.Clear();
        Console.WriteLine("Imprimir licencia");
        Console.WriteLine("******************");
        var motores = Archivo.ListaMotoristas();
        if (motores.Count == 0)
        {
            Utils.Pausa("No hay motores registrados");
            return;
        }
        Console.WriteLine("Motores registrados");
        foreach (var motors in motores)
        {
            Console.WriteLine(@$"
            Posicion: {motores.IndexOf(motors) + 1}
            Marca: {motors.marca}
            Modelo: {motors.modelo}
            Cedula: {motors.cedula}
            Nombre: {motors.nombre}
            ------------------------------------------------


            ");
        }
        var elegido = Utils.InputInt("Ingrese la posicion del motor al cual desea imprimir licencia o 0 (cero) para cancelar");
        if (elegido == 0)
        {
            Utils.Pausa("Cancelado");
            return;
        }
        var motor = motores[elegido - 1];
        var html = @$"
        <html>
            <head><!-- Compiled and minified CSS -->
                <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css'></head>
            <body>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <hr/>
                <h1 style='text-align: center;'><img style='font-size: 14px;' src='https://th.bing.com/th/id/OIP.heRcK_ahpYvIh0cwx9nV-AHaCK?w=317&amp;h=102&amp;c=7&amp;r=0&amp;o=5&amp;dpr=1.06&amp;pid=1.7' alt='' /></h1>
                <h1 style='text-align: center;'><strong>Registro De Motores</strong></h1>
                <p style='text-align: center;'><strong>Datos del motor</strong></p>
                <table style='border-collapse: collapse; width: 100.728%; height: 105px;' border='1'>
                <tbody>
                <tr style='height: 18px;'>
                <td style='width: 50%; height: 18px; text-align: right;'>Nombre:&nbsp;</td>
                <td style='width: 50%; height: 18px;'>{motor.nombre}</td>
                </tr>
                <tr style='height: 10px;'>
                <td style='width: 50%; height: 10px; text-align: right;'>Cedula:&nbsp;</td>
                <td style='width: 50%; height: 10px;'>{motor.cedula}</td>
                </tr>
                <tr style='height: 18px;'>
                <td style='width: 50%; height: 18px; text-align: right;'>Marca:&nbsp;</td>
                <td style='width: 50%; height: 18px;'>{motor.marca}</td>
                </tr>
                <tr>
                <td style='width: 50%; text-align: right;'>Modelo:&nbsp;</td>
                <td style='width: 50%;'>{motor.modelo}</td>
                </tr>
                <tr style='height: 18px;'>
                <td style='width: 50%; height: 18px; text-align: right;'>Actividad:&nbsp;</td>
                <td style='width: 50%; height: 18px;'>{motor.actividad}</td>
                </tr>
                </tbody>
                </table>
                <p style='text-align: left;'>&nbsp;</p>
                <p style='text-align: left;'>Este documento muestra los datos de la licencia motor.</p>
                <hr/>
                                
            </body>
        </html>
        ";
        System.IO.File.WriteAllText("licencia.html", html);
        var uri = "licencia.html";
        var psi = new System.Diagnostics.ProcessStartInfo();
        psi.UseShellExecute = true;
        psi.FileName = uri;
        System.Diagnostics.Process.Start(psi);

        Utils.Pausa("Licencia lista para imprimir");


    }

    public static void AcercaDeMi()
    {
        Console.Clear();
        Console.WriteLine(@"
               ......               
            .:||||||||:.            
           /            \           
          (   o      o   )          
--@@@@----------:  :----------@@@@--

Nombre: Ada L. Jimenez
Matricula: 2022-0790
Telefono: 849-260-7783
Correo: 20220790@itla.edu.do

");
Utils.Pausa("Contratame!!!!!!!!");
    }
}