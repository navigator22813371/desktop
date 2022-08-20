using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingTime.Models
{
    [Table(Name = "Change")]
    public class Smena
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "сhange_of_employee")]
        public string Change_of_employee { get; set; }
    }
        
}
