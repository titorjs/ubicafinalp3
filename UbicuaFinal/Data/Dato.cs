using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbicuaFinal.Data
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

        public bool enRango()
        {
            return !(Math.Abs(gx) > 1 || Math.Abs(gy) > 1 || Math.Abs(gz) > 1 || Math.Abs(temp) > 30 || Math.Abs(hum) > 60);
        }
    }
}
