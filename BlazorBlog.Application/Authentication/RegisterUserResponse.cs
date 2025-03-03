using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Authentication
{
    public class RegisterUserResponse
           {
        public bool Successed { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}
