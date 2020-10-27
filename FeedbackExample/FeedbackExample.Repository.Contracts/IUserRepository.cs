using FeedbackExample.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackExample.Repository.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(Guid id);
    }
}
