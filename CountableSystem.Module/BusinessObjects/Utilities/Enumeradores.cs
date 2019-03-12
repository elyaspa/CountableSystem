using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountableSystem.Module.BusinessObjects.Utilities
{
    public class Enumeradores
    {
        public enum TipoSaldo
        {
            Deudor=1,
            Acreedor=2
        };

        public enum TipoCuenta
        {
            Balance=1,
            Resultado=2
        };

        public enum EstatusCuenta
        {
            Activa=1,
            Inactiva=2
        };

        public enum EfectoSaldo
        {
            Positivo=1,
            Negativo=2
        };

        public enum EstatusPeriodo
        {
            Abierto=1,
            Cerrado = 2
        };
    }
}
