using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPrueba.Services
{
    public class UserService : IUserService
    {
        public List<string> Errors { get; set; }

        public bool IsValid(BOUser objUser)
        {
            Errors = new List<string>();

            bool resp = true;

            if (string.IsNullOrEmpty(objUser.Name) ||
                string.IsNullOrWhiteSpace(objUser.Name))
            {
                Errors.Add("Name: Required field");
                resp = false;
            }
            if (string.IsNullOrEmpty(objUser.LastName) ||
                string.IsNullOrWhiteSpace(objUser.LastName))
            {
                Errors.Add("LastName: Required field");
                resp = false;
            }

            return resp;
        }
    }
}
