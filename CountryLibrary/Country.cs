using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CountryLibrary
{
    public class Country
    {
        public Name name { get; set; }
        public List<string> capital { get; set; }

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
