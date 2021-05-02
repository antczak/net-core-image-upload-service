using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUpload.Data
{
    public class User : IdentityUser
    {
        public virtual List<Image> Images { get; set; }
    }
}
