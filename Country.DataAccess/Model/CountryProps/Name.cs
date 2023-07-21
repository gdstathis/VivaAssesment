using System.ComponentModel.DataAnnotations.Schema;

namespace Country.DataAccess.Model.CountryProps
{
    [NotMapped]
    public class Name
    {
        public string Common { get; set; } = string.Empty;
    }
}
