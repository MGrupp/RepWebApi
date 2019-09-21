
namespace WebApiPrueba
{
    public class BaseCO
    {
        protected string ErroresPersistencia;

        public BaseCO()
        {
        }

        protected CoreFacade getInstance()
        {
            return CoreFacade.getInstance();
        }
    }
}
