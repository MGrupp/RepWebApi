using System;
using System.Data;

namespace WebApiPrueba
{
    public class DataBaseAccess : IDisposable
    {
        public DataBaseAccess()
        {
        }

        public int InsertReturning(string sql, IDbConnection conexion)
        {
            using (IDbCommand command = conexion.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 300;
                return int.Parse(command.ExecuteScalar().ToString());
            }
        }

        public int ExecuteNonQuery(string sql, IDbConnection conexion)
        {
            using (IDbCommand command = conexion.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 300;
                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string sql, IDbConnection conexion)
        {
            using (IDbCommand command = conexion.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 300;
                return command.ExecuteScalar();
            }
        }

        public IDataReader ExecuteReader(string sql, IDbConnection conexion)
        {
            IDbCommand command = conexion.CreateCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 300;
            return command.ExecuteReader();
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Liberamos objetos manejados.
                }
                // Liberamos los objetos no manejados.
                // Establecemos variables largas en Nulo.
                disposed = true;
            }
        }
    }
}
