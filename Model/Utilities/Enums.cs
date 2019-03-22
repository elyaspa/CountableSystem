namespace CS.Model.Utilities
{
    public class Enums
    {
        public enum CreditType
        {
            Debtor=1,
            Creditor=2
        };

        public enum AccountType
        {
            Balance=1,
            Result=2
        };

        public enum AccountStatus
        {
            Active=1,
            Idle=2
        };

        public enum CreditImpact
        {
            Positive=1,
            Negative=2
        };

        public enum PeriodStatus
        {
            Open=1,
            Closed = 2
        };
    }
}
