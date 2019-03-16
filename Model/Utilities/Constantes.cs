using System.Runtime.Serialization;


namespace CS.Model.Utilities
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
