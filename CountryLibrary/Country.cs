using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CountryLibrary
{
    public class Country
    {
        private string _nameOfCountry;

        public int Id { get; set; }
        [NotMapped]
        [Key]
        public Name name { get; set; }

        [Column("Name")]
        public string NameOfCountry
        {
            get { return _nameOfCountry; }
            set
            {
                if (name == null)
                    _nameOfCountry = string.Empty;
                else
                    _nameOfCountry = name.common.FirstOrDefault().ToString();
            }
        }
        [NotMapped]
        public List<string> capital { get; set; }
        [NotMapped]
        public List<string> borders { get; set; }

    }

    public class Name
    {
        public string common { get; set; }
    }
    public class Borders
    {
        public List<Borders> borders { get; set; }
    }
}
