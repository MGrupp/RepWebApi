using System;
using System.Data;

namespace WebApiPrueba
{
    public static class NotNullDataReader
    {
        public static bool HasColumn(IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetString(IDataReader reader, string paramName)
        {
            if (!HasColumn(reader, paramName))
            {
                return "";
            }
            if (reader.IsDBNull(reader.GetOrdinal(paramName)))
            {
                return "";
            }
            return reader.GetString(reader.GetOrdinal(paramName));
        }

        public static decimal GetDecimal(IDataReader reader, string paramName)
        {
            if (!HasColumn(reader, paramName))
            {
                return 0;
            }
            if (reader.IsDBNull(reader.GetOrdinal(paramName)))
            {
                return 0;
            }
            return reader.GetDecimal(reader.GetOrdinal(paramName));
        }

        public static int GetInt32(IDataReader reader, string paramName)
        {
            if (!HasColumn(reader, paramName))
            {
                return 0;
            }
            if (reader.IsDBNull(reader.GetOrdinal(paramName)))
            {
                return 0;
            }
            return reader.GetInt32(reader.GetOrdinal(paramName));
        }

        public static DateTime GetDateTime(IDataReader reader, string paramName)
        {
            if (!HasColumn(reader, paramName))
            {
                return new DateTime(01, 01, 01, 0, 0, 0);
            }
            if (reader.IsDBNull(reader.GetOrdinal(paramName)))
            {
                return new DateTime(01, 01, 01, 0, 0, 0);
            }
            return reader.GetDateTime(reader.GetOrdinal(paramName));
        }
    }
}