using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapDatingApp.Infrastructure.DTOs
{
   public class MemberDto
    {
        public int AppUserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<PhotoDto> Photos { get; set; }
    }
}
