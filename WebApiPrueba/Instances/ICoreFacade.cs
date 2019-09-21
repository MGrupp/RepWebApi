using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebApiPrueba
{
    public interface ICoreFacade
    {
        #region USER

        BusinessResult CreateUser(BOUser objUser);

        BusinessResult UpdateUser(BOUser objUser);

        BusinessResult DeleteUser(int id);

        BusinessResult GetUserById(int id);

        List<BOUser> GetAllUsers();

        #endregion
    }
}
