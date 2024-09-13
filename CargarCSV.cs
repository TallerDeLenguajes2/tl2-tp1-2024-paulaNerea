using System;
using System.Collections.Generic;
using System.IO;

public class CargarDesdeCSV
{
    public static Cadeteria CargarCadeteria(string ruta)
    {
        using (var lector = new StreamReader(ruta))
        {
            string linea;
            if ((linea = lector.ReadLine()) != null)
            {
                string [] valores = linea.Split(',');
                string nombre = valores[0];
                string telefono = valores[1];
                return new Cadeteria(nombre, telefono);
            }
        }
        return null;
    }

    public static List<Cadete> CargarCadetes(string ruta)
    {
        List<Cadete> cadetes = new List<Cadete>();
        using (var lector = new StreamReader(ruta))
        {
            string linea;
            while ((linea = lector.ReadLine()) != null)
            {
                var valores = linea.Split(',');
                int id = int.Parse(valores[0]);//convierto string a int
                string nombre = valores[1];
                string direccion = valores[2];
                string telefono = valores[3];
                cadetes.Add(new Cadete(id, nombre, direccion, telefono));
            }
        }
        return cadetes;
    }

}

