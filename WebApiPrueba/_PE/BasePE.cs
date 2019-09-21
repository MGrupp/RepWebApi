using System;

namespace WebApiPrueba
{
    public abstract class BasePE : IDisposable
    {
        public DataBaseAccess DataBase = new DataBaseAccess();

        private bool disposed = false;

        //Implement IDisposable.
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
                    DataBase.Dispose();
                }
                // Liberamos los objetos no manejados.
                // Establecemos variables largas en Nulo.
                disposed = true;
            }
        }
    }
}
