class Archivo
{

    private static List<Motorista> Motoristas = new List<Motorista>();

    public static List<Motorista> ListaMotoristas()
    {
        return Motoristas;
    }

    public static void Guardar(Motorista motorista)
    {
        try
        {
            Motoristas.Remove(motorista);
        }
        catch (Exception) { }
        Motoristas.Add(motorista);

        var json = Newtonsoft.Json.JsonConvert.SerializeObject(Motoristas);
        System.IO.File.WriteAllText("motoristas.json", json);
    }

    public static void Leer()
    {
        Motoristas = new List<Motorista>();
        if (System.IO.File.Exists("motoristas.json"))
        {


            var json = System.IO.File.ReadAllText("motoristas.json");
            try
            {
                Motoristas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Motorista>>(json);
            }
            catch (Exception)
            {
                Utils.Pausa("Error al leer el archivo");

            }
        }

    }



}