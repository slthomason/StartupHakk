// Classic
public enum PaymentType
{
    CreditCard,
    DebitCard,
    BankTransfer
}

//Smart
public sealed class PaymentType : SmartEnum<PaymentType, string>
{
    public static readonly PaymentType CreditCard = new PaymentType("CC", "Credit Card", new CreditCardPaymentProcessor());
    public static readonly PaymentType DebitCard = new PaymentType("DC", "Debit Card", new DebitCardPaymentProcessor());
    public static readonly PaymentType BankTransfer = new PaymentType("BT", "Bank Transfer", new BankTransferPaymentProcessor());

    private PaymentType(string value, string name, IPaymentProcessor paymentProcessor)
        : base(value, name)
    {
    }

}