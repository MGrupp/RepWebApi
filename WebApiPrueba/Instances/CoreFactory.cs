
namespace WebApiPrueba
{
    public class CoreFactory
    {
        private CoreFactory()
        {
        }

        public static ICoreFacade Instance
        {
            get
            {
                return (ICoreFacade)CoreFacade.getInstance();
            }
        }
    }
}
