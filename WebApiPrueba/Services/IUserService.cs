using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPrueba.Services
{
    public interface IUserService
    {
        bool IsValid(BOUser objUser);
        List<string> Errors { get; set; }
    }
}
