using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace CountableSystem.Module.BusinessObjects.Utilities
{
    [DataContract]
    public sealed class Constantes
    {
        [DataMember]
        public const string PrefijoTabla = "SCT_";
        [DataMember]
        public const string MascaraNumericaDosDecimales = "#,###,##0.00";
        [DataMember]
        public const string MascaraNumericaSeisDecimales = "#,###,##0.000000";
        [DataMember]
        public const string MascaraNumericaSinDecimales = "##########";

    }
}
