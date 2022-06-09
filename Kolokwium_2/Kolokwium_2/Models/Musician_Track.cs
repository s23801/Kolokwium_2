using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Models
{
    public class Musician_Track
    {
        [Key]
        public int IdTrack { get; set; }
        [Key]
        public int IdMusician { get; set; }
        [ForeignKey("IdTrack")]
        public virtual Musician Musician { get; set; }
        [ForeignKey("IdMusician")]
        public virtual Track Track { get; set; }
    }
}
