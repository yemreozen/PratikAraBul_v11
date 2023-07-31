using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogTags
    {
        [Key]
        public int TagID { get; set; }
        public string TagName { get; set; }
        public int BlogID { get; set; }

        public Blog Blog { get; set; }

    }
}
