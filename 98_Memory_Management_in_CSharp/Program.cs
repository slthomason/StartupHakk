//Stack vs. Heap: A Detailed Insight
int x = 10; // Stored in Stack
MyClass obj = new MyClass(); // Reference in Stack, actual object in Heap

//Value Types and Reference Types in Depth

int valType = 42; // Value Type
string refType = "Hello World"; // Reference Type


//Generational Garbage Collection
// Creating a short-lived object
var shortLived = new ShortLived();

// This object may get promoted to generation 1 or 2 over time, depending on the GC's collection process

//Fine-Tuning Garbage Collection

// Forcing a garbage collection
GC.Collect();

//Manual Memory Management Strategies
public class ResourceHolder : IDisposable
{
    private bool disposed = false;

    // Implement IDisposable.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Free other state (managed objects).
            }
            // Free your own state (unmanaged objects).
            // Set large fields to null.
            disposed = true;
        }
    }
    ~ResourceHolder()
    {
        Dispose(false);
    }
}

//Leveraging Finalizers


public class MyClass
{
    ~MyClass()
    {
        // Cleanup code here
    }
}

//The SafeHandle Class

public class UnmanagedResourceWrapper : SafeHandleZeroOrMinusOneIsInvalid
{
    private UnmanagedResourceWrapper() : base(true) { }

protected override bool ReleaseHandle()
    {
        return NativeMethods.ReleaseHandle(handle);
    }
}


//Object Pooling: A Primer

public class ObjectPool<T>
{
    private readonly ConcurrentBag<T> _objects = new ConcurrentBag<T>();
    private readonly Func<T> _objectGenerator;

public ObjectPool(Func<T> objectGenerator)
    {
        _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
    }
    public T Get() => _objects.TryTake(out T item) ? item : _objectGenerator();
    public void Return(T item) => _objects.Add(item);
}


//Strategies to Prevent Memory Leaks

public class EventHolder
{
    public event EventHandler LeakEvent;

public void DoSomething()
    {
        LeakEvent?.Invoke(this, EventArgs.Empty);
    }
}
public class EventSubscriber
{
    public void Subscribe(EventHolder holder)
    {
        holder.LeakEvent += OnLeakEvent;
    }
    private void OnLeakEvent(object sender, EventArgs e)
    {
        // Do something here
    }
    public void Unsubscribe(EventHolder holder)
    {
        holder.LeakEvent -= OnLeakEvent;
    }
}

//Choosing the Right Collections

var list = new List<int> { 1, 2, 3, 4 };
var set = new HashSet<int> { 1, 2, 3, 4 };




//Understanding and Implementing Weak References

var strongReference = new MyClass();
var weakReference = new WeakReference<MyClass>(strongReference);
strongReference = null;
MyClass temp;
if (weakReference.TryGetTarget(out temp))
{
    // Object is still alive
}
else
{
    // Object is collected
}















//Memory Profiling in C#: Tools and Techniques

[MemoryDiagnoser]
public class MyBenchmarks
{
    [Benchmark]
    public void Benchmark1()
    {
        // Benchmarking code here
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<MyBenchmarks>();
    }
}