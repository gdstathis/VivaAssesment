using Country.DataAccess.Model.CountryProps;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Country.DataAccess.Model
{
    public class Country
    {
        [NotMapped]
        public Name? Name { get; set; }

        [Key]
        [Column("NAME")]
        [Newtonsoft.Json.JsonIgnore]
        public string NameOfCountry
        {
            get { return Name?.Common ?? string.Empty; }
            set { Name = new Name { Common = value }; }
        }

        [NotMapped]
        public List<string> Capital { get; set; }

        [Column("CAPITAL")]
        [Newtonsoft.Json.JsonIgnore]
        public string CapitalCountry
        {
            get { return Capital?.FirstOrDefault() ?? string.Empty; }
            set { Capital = new List<string> { value }; }
        }

        [Column("BORDERS")]
        [Newtonsoft.Json.JsonIgnore]
        public string? Border
        {
            get
            {
                return Borders != null ?
                string.Join(",", Borders) : "";
            }
            set { Borders = new List<string> { value }; }
        }

        [NotMapped]
        public List<string> Borders { get; set; }

        public Country()
        {
            Name = new Name();
            Capital = new List<string>();
            Borders = new List<string>();
        }
    }
}
