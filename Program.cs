bool continuar = true;

Archivo.Leer();


while (continuar)
{
    Console.Clear();
    Console.WriteLine(@"
    Registro de motores

                        `   `.
           <```--...       .---.//  < `.
            `..     `.___ /       ___`.'
              _`_ .      `      .'\\__
            .'---`.`.          / .'---`.
           /.'  _`.\_\        / /.'\\ `.\
           ||  <__||_|        | ||  ~  ||
           \`.___.'/ /________\ \`.___.'/
            `.___.'              `.___.'


    Seleccione la opcion que desee realizar:

    1. Registrar Motor
    2. Editar
    3. Ver Mapa
    4. Imprimir licencica
    5. AcercaDeMi
    x. Salir
    
    ");

    string opcion = Utils.Input("Ingrese una opcion: ");
    switch (opcion.ToLower())
    {
        case "1":
            Desarrollo.RegistraMotor();

            break;

        case "2":
            Desarrollo.EditarMotor();

            break;

        case "3":
            Desarrollo.VerMapa();

            break;

        case "4":
            Desarrollo.Imprimir();

            break;

        case "5":
            Desarrollo.AcercaDeMi();
            break;

        case "x":
            continuar = false;
            Utils.Pausa("Saliendo... Regrese pronto <3");
            break;

        default:
            Utils.Pausa("Opcion no valida");
            break;
    }
}