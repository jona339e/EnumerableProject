using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnumerableProject
{

    class CarData
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("car_make")]
        public string Make { get; set; }

        [JsonPropertyName("car_models")]
        public string Model { get; set; }

        [JsonPropertyName("car_year")]
        public int Year { get; set; }

        [JsonPropertyName("number_of_doors")]
        public int NumberOfDoors { get; set; }

        [JsonPropertyName("horse_power")]
        public int HorsePower { get; set; }
    }
}
