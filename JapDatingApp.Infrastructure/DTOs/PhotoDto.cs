using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapDatingApp.Infrastructure.DTOs
{
   public class PhotoDto
    {
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}
