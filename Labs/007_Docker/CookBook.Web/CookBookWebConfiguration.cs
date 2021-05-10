using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Web
{
    public class CookBookWebConfiguration
    {
        [Required]
        public string OpenWeatherApiUrl { get; set; }
    }
}
