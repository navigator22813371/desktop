using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingTime.Models
{
    [Table(Name = "Position")]
    public class Position
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "position_name")]
        public string Position_name { get; set; }
    }
}
