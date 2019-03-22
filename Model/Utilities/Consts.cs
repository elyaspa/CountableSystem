using System.Runtime.Serialization;


namespace CS.Model.Utilities
{
    [DataContract]
    public sealed class Consts
    {
        [DataMember]
        public const string TablePrefix = "SCT_";
        [DataMember]
        public const string TwoDecimalNumericMask = "#,###,##0.00";
        [DataMember]
        public const string SixDecimalNumericMask = "#,###,##0.000000";
        [DataMember]
        public const string NoDecimalNumericMask = "##########";

    }
}
