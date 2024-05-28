using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace congestion.calculator.Entities
{
    [Table("TaxTime")]
    public class TaxTime
    {
        [Key]
        public int Id { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public int Tax { get; set; }

    }
}
