using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubicua_Lectura_de_Datos.Db
{
    public class Dato
    {
        [Key]
        public int id {  get; set; }
        [Required]
        public DateTime date {  get; set; }
        [Required]
        public float gx { get; set; }
        [Required]
        public float gy { get; set; }
        [Required]
        public float gz { get; set; }
        [Required]
        public float temp { get; set; }
        [Required]
        public float hum { get; set; }
    }
}
