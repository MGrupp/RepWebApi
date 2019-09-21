using System.Collections;

namespace WebApiPrueba
{
    public partial class CoreFacade : ICoreFacade
    {
        private Hashtable controllersInstances = new Hashtable();

        private static CoreFacade _instance = null;

        private CoreFacade()
        {
        }

        public static CoreFacade getInstance()
        {
            if (_instance == null)
            {
                _instance = new CoreFacade();
            }
            return _instance;
        }
    }
}
