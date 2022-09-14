class Utils
{
    public static string Input(string msg)
    {
        Console.WriteLine(msg);
        return Console.ReadLine() ?? "";
    }

    public static void Pausa(string msg = "")
    {
        Console.WriteLine(msg);
        Console.WriteLine("Presione ENTER para continuar");
        Console.ReadLine();
    }

    public static int InputInt(string msg = "")
    {
        Console.Write(msg);
        int numero = 0;
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Ingrese un numero: ");
        }
        return numero;
    }

    public static string InputModificar(string msg, string valor)
    {
        Console.WriteLine($"Los datos actuales en {msg}son: {valor}, digite el nuevo opresione ENTER para NO modificar: ");
        string nuevoValor = Console.ReadLine() ?? "";
        if (nuevoValor != "")
        {
            valor = nuevoValor;
        }
        return valor;
    }
}



