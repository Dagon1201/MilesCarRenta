using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MilesCarRent.Models
{
    public partial class Lugar
    {
        public Lugar()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdLugar { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }

        [JsonIgnore]
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
