public class OverdraftException : InvalidOperationException
{
   public OverdraftException(decimal startingBalance, decimal withdrawAmount)
     : base($"Attempted to overdraft the account. The staring balance was {startingBalance:C} and the amount withdrawn was {withdrawAmount:C}")
   {
      StartingBalance = startingBalance;
      WithdrawAmount = withdrawAmount;
   }

   public decimal StartingBalance { get; }
   public decimal WithdrawAmount { get; }
}

throw new OverdraftException(1000, 5000);

catch (OverdraftException ex)
{
   Console.WriteLine($"Starting Balance: {ex.StartingBalance:C}");
   Console.WriteLine($" Withdraw Amount: {ex.WithdrawAmount:C}");
}