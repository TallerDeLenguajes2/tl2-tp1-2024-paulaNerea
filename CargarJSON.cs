using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class CargarDesdeJSON : AccesoADatos
{
    public override Cadeteria CargarCadeteria(string ruta)
    {
        try
        {
            string jsonString = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<Cadeteria>(jsonString) ?? new Cadeteria("Cadeteria Vacia", "Sin Telefono");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer desde el archivo");
            return new Cadeteria("Cadeteria Vacia", "Sin Telefono");
        }
    }
    
    public override List<Cadete> CargarCadetes(string ruta)
    {
        try
        {
            string jsonString = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Cadete>>(jsonString) ?? new List<Cadete>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer personajes: {ex.Message}");
            return new List<Cadete>();
        }
    }
}