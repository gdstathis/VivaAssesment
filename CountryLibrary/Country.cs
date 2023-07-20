using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CountryLibrary
{
    public class Country
    {
        private string _nameOfCountry = string.Empty;
        private string _capital = string.Empty;

        [NotMapped]
        public Name Name { get; set; }

        [Key]
        [Column("name")]
        [JsonIgnore]
        public string NameOfCountry
        {
            get
            {
                return _nameOfCountry;
            }
            set { _nameOfCountry = Name.common; }
        }

        [NotMapped]
        public List<string> Capital { get; set; }


        [NotMapped]
        public string? CapitalCountry { get { return Capital?.FirstOrDefault(); } }

        [NotMapped]
        public List<string> Borders { get; set; }
    }
    [NotMapped]
    public class Name
    {
        public string common { get; set; } = string.Empty;
    }

    [NotMapped]
    public class Borders
    {
        public List<Borders> borders { get; set; }
    }
}
