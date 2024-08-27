using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Category
    {
        Cuadriceps = 0,
        Espalda = 1,
        Piernas = 2,
        Brazos = 3,
        Abdominales = 4,
        Hombros = 5,
        Pecho = 6,
        Core = 7
    }
}
