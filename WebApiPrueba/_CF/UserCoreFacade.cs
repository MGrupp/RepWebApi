using System.Collections.Generic;
using WebApiPrueba.Services;

namespace WebApiPrueba
{
    public partial class CoreFacade : ICoreFacade
    {
        public UserCO getUserCO()
        {
            if (this.controllersInstances.Contains("UserCO"))
                return (UserCO)this.controllersInstances["UserCO"];
            else
            {
                UserService userService = new UserService(); 
                UserCO UserCo = new UserCO(userService);
                this.controllersInstances.Add("UserCO", UserCo);
                return UserCo;
            }
        }

        public BusinessResult CreateUser(BOUser objUser)
        {
            return this.getUserCO().CreateUser(objUser);
        }

        public BusinessResult UpdateUser(BOUser objUser)
        {
            return this.getUserCO().UpdateUser(objUser);
        }

        public BusinessResult DeleteUser(int id)
        {
            return this.getUserCO().DeleteUser(id);
        }

        public BusinessResult GetUserById(int id)
        {
            return this.getUserCO().GetUserById(id);
        }

        public List<BOUser> GetAllUsers()
        {
            return this.getUserCO().GetAllUsers();
        }
    }
}
