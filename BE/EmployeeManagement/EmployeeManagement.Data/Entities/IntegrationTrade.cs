using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Entities
{
    public class IntegrationTrade
    {
        [Key]
        public int Id { get; set; }
        public string Volume { get; set; }
        public string VolumeWeight { get; set; }
        public string Open { get; set; }
        public string Chair { get; set; }
        public string Height { get; set; }
        public string Low { get; set; }
        public string Title { get; set; }
        public string NoOne { get; set; }
    }
}
