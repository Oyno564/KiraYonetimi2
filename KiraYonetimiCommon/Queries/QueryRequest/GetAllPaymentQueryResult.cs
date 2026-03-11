namespace KiraYonetimi.Common.Queries.QueryRequest
{
    public class GetAllPaymentQueryResult
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
