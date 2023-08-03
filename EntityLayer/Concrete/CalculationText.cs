using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CalculationText
    {
        [Key]
        public int CalculationTextID { get; set; }
        public string CalculationTitle { get; set; }
        public string CalculationFristCaption { get; set; } 
        public string CalculationLastCaption { get; set; }
    }
}
