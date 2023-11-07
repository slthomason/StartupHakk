public void Process(Order? order)
{
    if (order != null)
    {
        if (order.IsVerified)
        {
            if (order.Items.Count > 0)
            {
                if (order.Items.Count > 15)
                {
                    throw new Exception(
                        "The order " + order.Id + " has too many items");
                }

                if (order.Status != "ReadyToProcess")
                {
                    throw new Exception(
                        "The order " + order.Id + " isn't ready to process");
                }

                order.IsProcessed = true;
            }
        }
    }
}

//#1: Early Return Principle

public void Process(Order? order)
{
    if (order is null)
    {
        return;
    }

    if (!order.IsVerified)
    {
        return;
    }

    if (order.Items.Count == 0)
    {
        return;
    }

    if (order.Items.Count > 15)
    {
        throw new Exception(
            "The order " + order.Id + " has too many items");
    }

    if (order.Status != "ReadyToProcess")
    {
        throw new Exception(
            "The order " + order.Id + " isn't ready to process");
    }

    order.IsProcessed = true;
}

//#2: Merge If Statements To Improve Readability
public void Process(Order? order)
{
    if (order is null ||
        !order.IsVerified ||
        order.Items.Count == 0)
    {
        return;
    }

    if (order.Items.Count > 15)
    {
        throw new Exception(
            "The order " + order.Id + " has too many items");
    }

    if (order.Status != "ReadyToProcess")
    {
        throw new Exception(
            "The order " + order.Id + " isn't ready to process");
    }

    order.IsProcessed = true;
}

//#3: Use LINQ For More Concise Code
public void Process(Order? order)
{
    if (order is null ||
        !order.IsVerified ||
        !order.Items.Any())
    {
        return;
    }

    if (order.Items.Count > 15)
    {
        throw new Exception(
            "The order " + order.Id + " has too many items");
    }

    if (order.Status != "ReadyToProcess")
    {
        throw new Exception(
            "The order " + order.Id + " isn't ready to process");
    }

    order.IsProcessed = true;
}

//#4: Replace Boolean Expression With Descriptive Method
public void Process(Order? order)
{
    if (!IsProcessable(order))
    {
        return;
    }

    if (order.Items.Count > 15)
    {
        throw new Exception(
            "The order " + order.Id + " has too many items");
    }

    if (order.Status != "ReadyToProcess")
    {
        throw new Exception(
            "The order " + order.Id + " isn't ready to process");
    }

    order.IsProcessed = true;
}

static bool IsProcessable(Order? order)
{
    return order is not null &&
           order.IsVerified &&
           order.Items.Any();
}

//#5: Prefer Throwing Custom Exceptions
public void Process(Order? order)
{
    if (!IsProcessable(order))
    {
        return;
    }

    if (order.Items.Count > 15)
    {
        throw new TooManyLineItemsException(order.Id);
    }

    if (order.Status != "ReadyToProcess")
    {
        throw new NotReadyForProcessingException(order.Id);
    }

    order.IsProcessed = true;
}

static bool IsProcessable(Order? order)
{
    return order is not null &&
           order.IsVerified &&
           order.Items.Any();
}


//#6: Fix Magic Numbers With Constants


const int MaxNumberOfLineItems = 15;

public void Process(Order? order)
{
    if (!IsProcessable(order))
    {
        return;
    }

    if (order.Items.Count > MaxNumberOfLineItems)
    {
        throw new TooManyLineItemsException(order.Id);
    }

    if (order.Status != "ReadyToProcess")
    {
        throw new NotReadyForProcessingException(order.Id);
    }

    order.IsProcessed = true;
}

static bool IsProcessable(Order? order)
{
    return order is not null &&
           order.IsVerified &&
           order.Items.Any();
}

//#7: Fix Magic Strings With Enums
enum OrderStatus
{
    Pending = 0,
    ReadyToProcess = 1,
    Processed = 2
}

const int MaxNumberOfLineItems = 15;

public void Process(Order? order)
{
    if (!IsProcessable(order))
    {
        return;
    }

    if (order.Items.Count > MaxNumberOfLineItems)
    {
        throw new TooManyLineItemsException(order.Id);
    }

    if (order.Status != OrderStatus.ReadyToProcess)
    {
        throw new NotReadyForProcessingException(order.Id);
    }

    order.IsProcessed = true;
    order.Status = OrderStatus.Processed;
}

static bool IsProcessable(Order? order)
{
    return order is not null &&
           order.IsVerified &&
           order.Items.Any();
}

//#8: Use The Result Object Pattern
public class ProcessOrderResult
{
    private ProcessOrderResult(
        ProcessOrderResultType type,
        long orderId,
        string message)
    {
        Type = type;
        OrderId = orderId;
        Message = message;
    }

    public ProcessOrderResultType Type { get; }

    public long OrderId { get; }

    public string? Message { get; }

    public static ProcessOrderResult NotProcessable() =>
      new(ProcessOrderResultType.NotProcessable, default, "Not processable");

    public static ProcessOrderResult TooManyLineItems(long oderId) =>
      new(ProcessOrderResultType.TooManyLineItems, orderId, "Too many items");

    public static ProcessOrderResult NotReadyForProcessing(long oderId) =>
      new(ProcessOrderResultType.NotReadyForProcessing, oderId, "Not ready");

    public static ProcessOrderResult Success(long oderId) =>
      new(ProcessOrderResultType.Success, oderId, "Success");
}

public enum ProcessOrderResultType
{
    NotProcessable = 0,
    TooManyLineItems = 1,
    NotReadyForProcessing = 2,
    Success = 3
}

const int MaxNumberOfLineItems = 15;

public ProcessOrderResult Process(Order? order)
{
    if (!IsProcessable(order))
    {
        return ProcessOrderResult.NotProcessable();
    }

    if (order.Items.Count > MaxNumberOfLineItems)
    {
        return ProcessOrderResult.TooManyLineItems(order);
    }

    if (order.Status != OrderStatus.ReadyToProcess)
    {
        return ProcessOrderResult.NotReadyForProcessing(order);
    }

    order.IsProcessed = true;
    order.Status = OrderStatus.Processed;

    return ProcessOrderResult.Success(order);
}

static bool IsProcessable(Order? order)
{
    return order is not null &&
           order.IsVerified &&
           order.Items.Any();
}


var result = Process(order);

result.Type switch
{
    ProcessOrderResultType.TooManyLineItems =>
        Console.WriteLine($"Too many line items: {result.OrderId}"),

    ProcessOrderResultType.NotReadyForProcessing =>
        Console.WriteLine($"Not ready for processing {result.OrderId}"),

    ProcessOrderResultType.Success =>
        Console.WriteLine($"Processed successfully {result.OrderId}"),

    _ => Console.WriteLine("Failed to process: {OrderId}", result.OrderId),
};