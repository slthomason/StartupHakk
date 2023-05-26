public class OverdraftException : InvalidOperationException
{
    public required decimal Balance { get; init; }
    public required decimal WithdrawAmount { get; init; }

    public override
     string Message => $"This is an overdraft. Withdrew ${WithdrawAmount}
      with balance of ${Balance}";
}
throw new OverdraftException()
{
    Balance = 1000,
    WithdrawAmount = 5000
};