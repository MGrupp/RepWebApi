using System;
using System.Collections.Generic;
using System.Data;

namespace WebApiPrueba
{
    public class UserPE : BasePE
    {
        public UserPE()
        {
        }

        public int CreateUser(IDbConnection conexion, BOUser obj)
        {
            string sql = "INSERT INTO USER " +
                "(" +
                "NAME," +
                "LASTNAME," +
                "ADDRESS," +
                "CREATEDATE" +
                ")" +
                " VALUES " +
                "(" +
                "'" + obj.Name + "'," +
                "'" + obj.LastName + "'," +
                "'" + obj.Address + "'," +
                "'" + Util.FormatDateYYYYMMDD(DateTime.Now) + "'" +
                ")";
            int resp = 0;
            switch (Util._GestorBaseDatos)
            {
                case Util.GestorBaseDatos.MySQL:
                    DataBase.ExecuteNonQuery(sql, conexion);
                    sql = "SELECT AUTO_INCREMENT FROM information_schema.tables WHERE table_name = 'USER'";
                    resp = Convert.ToInt32(DataBase.ExecuteScalar(sql, conexion)) - 1;
                    break;
                default:
                    break;
            }
            return resp;
        }

        public void UpdateUser(IDbConnection conexion, BOUser obj)
        {
            string sql = "UPDATE USER SET" +
                " NAME='" + Util.FormatString(obj.Name) + "'," +
                " LASTNAME='" + Util.FormatString(obj.LastName) + "'," +
                " ADDRESS='" + obj.Address + "'," +
                " UPDATEDATE='" + Util.FormatDateYYYYMMDD(DateTime.Now) + "'" +
                " WHERE ID='" + obj.Id + "'";
            DataBase.ExecuteNonQuery(sql, conexion);
        }

        public void DeleteUser(IDbConnection conexion, int idUser)
        {
            string sql = "DELETE FROM USER WHERE ID='" + idUser + "'";
            DataBase.ExecuteNonQuery(sql, conexion);
        }

        public BOUser GetUserById(IDbConnection conexion, int idUser)
        {
            BOUser resp = null;
            string sql = "SELECT * FROM USER" +
                " WHERE ID=" + idUser;
            using (var dr = DataBase.ExecuteReader(sql, conexion))
            {
                while (dr.Read())
                {
                    resp = Load(dr);
                }
            }
            return resp;
        }

        public List<BOUser> GetAllUsers(IDbConnection conexion)
        {
            List<BOUser> resp = new List<BOUser>();
            string sql = "SELECT * FROM USER";
            using (var dr = DataBase.ExecuteReader(sql, conexion))
            {
                while (dr.Read())
                {
                    resp.Add(Load(dr));
                }
            }
            return resp;
        }

        private BOUser Load(IDataReader reader)
        {
            BOUser obj = new BOUser();
            obj.Id = NotNullDataReader.GetInt32(reader, "ID");
            obj.Name = NotNullDataReader.GetString(reader, "NAME");
            obj.LastName = NotNullDataReader.GetString(reader, "LASTNAME");
            obj.Address = NotNullDataReader.GetString(reader, "ADDRESS");
            obj.CreateDate = NotNullDataReader.GetDateTime(reader, "CREATEDATE");
            obj.UpdateDate = NotNullDataReader.GetDateTime(reader, "UPDATEDATE");

            return obj;
        }
    }
}