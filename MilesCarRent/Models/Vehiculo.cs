using System;
using System.Collections.Generic;

namespace MilesCarRent.Models
{
    public partial class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? PrecioRenta { get; set; }
        public int? UbicacionPrincipal { get; set; }
        public int? UbicacionActual { get; set; }
        public int? Disponibilidad { get; set; }

        public virtual Lugar? oUbicacionActual { get; set; }
    }
}
