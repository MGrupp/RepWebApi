using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WebApiPrueba
{
    public static class Util
    {        
        public static string FormatDateYYYYMMDD(DateTime val)
        {
            return val.Year.ToString().PadLeft(4, '0') + "-" + val.Month.ToString().PadLeft(2, '0') + "-" + val.Day.ToString().PadLeft(2, '0');
        }

        public static string FormatDateDDMMYYYY(DateTime val)
        {
            return val.Day.ToString().PadLeft(2, '0') + "-" + val.Month.ToString().PadLeft(2, '0') + "-" + val.Year.ToString().PadLeft(4, '0');
        }

        public static DateTime GetDateFromString(string date_YYYY_MM_DD)
        {
            int año = int.Parse(date_YYYY_MM_DD.Substring(0, 4));
            int mes = int.Parse(date_YYYY_MM_DD.Substring(5, 2));
            int dia = int.Parse(date_YYYY_MM_DD.Substring(8, 2));
            return new DateTime(año, mes, dia);
        }

        public static string NullValueFK(string val)
        {
            if (val == "0")
                return "NULL";
            return val;
        }

        public static string NullValueSTRFK(string val)
        {
            if (val == "")
                return "NULL";
            return "'" + val + "'";
        }


        public static string FormatString(string val)
        {
            return val.Replace("'", "''");
        }

        public enum GestorBaseDatos
        {
            PostgreSQL,
            MySQL,
            SQLSERVER
        }
        public static GestorBaseDatos _GestorBaseDatos = GestorBaseDatos.MySQL;

        public static IDbConnection GetConnection()
        {
            IDbConnection con = null;
            switch (_GestorBaseDatos)
            {
                case GestorBaseDatos.MySQL:
                    con = new MySqlConnection(@"Data Source=webapiprueba.db.11978601.3fe.hostedresource.net; Port=3306; Initial Catalog=webapiprueba; User ID=webapiprueba; Password='Z1x2@@c3v4';");
                    break;
                case GestorBaseDatos.SQLSERVER:
                    con = new SqlConnection("");
                    break;
            }
            return con;
        }
    }
}


