﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace congestion.calculator.Entities
{
    [Table("Holidays")]
    public class Holidays
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
