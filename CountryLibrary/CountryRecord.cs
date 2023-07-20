using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryLibrary
{
    public class CountryRecord
    {
        [Key]
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Borders { get; set; }
    }



}