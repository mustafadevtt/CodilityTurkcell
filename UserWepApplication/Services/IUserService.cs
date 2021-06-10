using System;
using UserWepApplication.Models.DataModels;

namespace UserWepApplication.Services
{
    public interface IUserService
    {
        Guid Create(User user);
        User Get(Guid id);
        bool Update(User userToUpdate);
    }
}
