using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingTime.Models
{
    [Table(Name = "Employee")]
    public class Employee
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "fio")]
        public string Fio { get; set; }
        [Column(Name = "position_id")]
        public int Position_id { get; set; }

        [Column(Name = "phone")]
        public string Phone { get; set; }  
    }
}
