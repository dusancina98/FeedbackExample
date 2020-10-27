using FeedbackExample.Contracts.DTO;
using FeedbackExample.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackExample.Contracts.Interfaces
{
    public interface IUserService
    {
        IEnumerable<IdentifiableDTO<UserDTO>> GetAll();
        IdentifiableDTO<UserDTO> GetById(Guid id);
    }
}
