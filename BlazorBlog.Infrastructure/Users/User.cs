using BlazorBlog.Domain.Articles;
using BlazorBlog.Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Infrastructure.Users;

public class User : IdentityUser, IUser
{
    public List<Article> Articles { get; set; } = [];
}
