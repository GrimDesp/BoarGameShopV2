namespace BoardGameShop.Model.Enums
{
    //DON'T move first element
    public enum OrderStatus
    {
        Created,
        Cancel,
        Complete,
        InProcess,
        Delivered
    }
    //DON'T move first element
    public enum PaymentStatus
    {
        NotPaid,
        Rollback,
        Paid,
    }
}
