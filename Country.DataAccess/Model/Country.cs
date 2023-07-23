using Country.DataAccess.Model.CountryProps;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Country.DataAccess.Model
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        [IgnoreDataMember]
        public int Id { get; set; }

        [NotMapped]
        public Name Name { get; set; }

        [Key]
        [Column("NAME")]
        [IgnoreDataMember]
        public string NameOfCountry
        {
            get { return Name?.Common ?? string.Empty; }
            set { Name = new Name { Common = value }; }
        }

        [NotMapped, IgnoreDataMember]
        public List<string> Capital { get; set; }

        [Column("CAPITAL")]
        [JsonProperty("capital")]
        public string CapitalCountry
        {
            get { return Capital?.FirstOrDefault() ?? string.Empty; }
            set { Capital = new List<string> { value }; }
        }

        [Column("BORDERS")]
        [IgnoreDataMember]
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
