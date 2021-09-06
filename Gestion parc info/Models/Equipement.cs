using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.Models
{
    public class Equipement
    {
        public int Id { get; set; }

        
        [Required]
        [StringLength(255)] 
        public string Name { get; set; }

        public int Quantité { get; set; }
        public Direction Direction  { get; set; }

        [Display(Name = "Direction")]
        [Required]
        public byte DirectionId { get; set; }


    }
}