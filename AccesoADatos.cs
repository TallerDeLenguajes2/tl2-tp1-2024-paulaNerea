using System;
using System.Collections.Generic;
using System.IO;

public abstract class AccesoADatos
{
    public abstract Cadeteria CargarCadeteria(string ruta);
    public abstract List<Cadete> CargarCadetes(string ruta);
}