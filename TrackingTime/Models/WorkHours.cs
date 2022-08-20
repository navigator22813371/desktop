using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrackingTime.Models
{
    [Table(Name = "WorkHours")]
    public class WorkHours
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "employee_id")]
        public int Employee_id { get; set; }
        [Column(Name = "position_id")]
        public int Position_id { get; set; }
        [Column(Name = "change_id")]
        public int Change_id { get; set; }
        [Column(Name = "number_of_hours")]
        public int Number_of_hours { get; set; }
        [Column(Name = "date")]
        public DateTime Date { get; set; }
    }
}

    
