using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Domain.Users
{
    public interface IUserRepositiory
    {
        Task<IUser?> GetUserByIdAsync(string userId);
    }
}
