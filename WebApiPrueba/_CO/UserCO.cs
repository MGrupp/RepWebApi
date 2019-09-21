using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using WebApiPrueba.Services;

namespace WebApiPrueba
{
    public class UserCO : BaseCO
    {
        private IUserService _userService;

        public UserCO(IUserService userService)
        {
            _userService = userService;
        }

        public BusinessResult CreateUser(BOUser objUser)
        {
            BusinessResult result = new BusinessResult();

            if (!_userService.IsValid(objUser))
            {
                result.Success = false;
                result.ErrorsList = _userService.Errors;
                return result;
            }

            using (var conexion = Util.GetConnection())
            {
                conexion.Open();
                using (var objPE = new UserPE())
                {
                    try
                    {
                        objUser.Id = objPE.CreateUser(conexion, objUser);

                        result.Success = true;
                        result.Other = objUser;
                    }
                    catch (Exception error)
                    {
                        result.ErrorsList.Add(error.Message);
                    }
                }
            }

            return result;
        }

        public BusinessResult UpdateUser(BOUser objUser)
        {
            BusinessResult result = new BusinessResult();

            using (var conexion = Util.GetConnection())
            {
                conexion.Open();
                using (var objPE = new UserPE())
                {
                    try
                    {
                        objPE.UpdateUser(conexion, objUser);

                        result.Success = true;
                        result.Other = objUser;
                    }
                    catch (Exception error)
                    {
                        result.ErrorsList.Add(error.Message);
                    }
                }
            }

            return result;
        }

        public BusinessResult DeleteUser(int id)
        {
            BusinessResult result = new BusinessResult();

            using (var conexion = Util.GetConnection())
            {
                conexion.Open();
                using (var objPE = new UserPE())
                {
                    try
                    {
                        objPE.DeleteUser(conexion, id);
                        result.Success = true;
                        result.Other = id;
                    }
                    catch (Exception error)
                    {
                        result.ErrorsList.Add(error.Message);
                    }
                }
            }

            return result;
        }

        public BusinessResult GetUserById(int id)
        {
            BusinessResult result = new BusinessResult();

            using (var conexion = Util.GetConnection())
            {
                conexion.Open();
                using (var objPE = new UserPE())
                {
                    try
                    {
                        BOUser objUser = objPE.GetUserById(conexion, id);

                        if (objUser == null)
                        {
                            result.ErrorsList.Add("Record not found.");
                        }
                        else
                        {
                            result.Success = true;
                            result.Other = objUser;
                        }
                    }
                    catch (Exception error)
                    {
                        throw new Exception(error.Message);
                    }
                }
            }

            return result;
        }

        public List<BOUser> GetAllUsers()
        {
            List<BOUser> result = new List<BOUser>();
            using (var conexion = Util.GetConnection())
            {
                conexion.Open();
                using (var objPE = new UserPE())
                {
                    result = objPE.GetAllUsers(conexion);
                }
            }
            return result;
        }
    }
}
