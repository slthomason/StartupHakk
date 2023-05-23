//HashSet<T>
var hashset = new HashSet<Item>();
var item = new Item();

hashset.Add(item);
hashset.Add(item);
hashset.Add(item);
hashset.Add(item);

Console.WriteLine("How many items does my Hashset have? {0}!", hashset.Count);



//Dictionary<TKey, TValue>
var dictionary = new Dictionary<int, Item>();

var item = new Item();
dictionary.Add(1, item);
dictionary.Add(2, item);
dictionary.Add(3, item);
dictionary.Add(4, item);
dictionary.Add(5, item);

Console.WriteLine("How many items does my Dictionary have? {0}!", dictionary.Count);


//LinkedList<T>
var linkedList = new LinkedList<Item>();
var item = new Item();

linkedList.AddLast(item);
linkedList.AddLast(item);
linkedList.AddLast(item);
linkedList.AddLast(item);
linkedList.AddLast(item);

Console.WriteLine("How many items does LinkedList have? {0}!", linkedList.Count);


//Stack<T>
var stack = new Stack<int>();
stack.Push(11);
stack.Push(22);
stack.Push(33);
stack.Push(44);
stack.Push(55);

foreach (var integer in stack)
{
    Console.WriteLine(integer);
}

Console.WriteLine("How many items does my Stack have? {0}!", stack.Count);

//Queue<T>
var queue = new Queue<int>();

queue.Enqueue(11);
queue.Enqueue(22);
queue.Enqueue(33);
queue.Enqueue(44);
queue.Enqueue(55);

foreach (var integer in queue)
{
    Console.WriteLine(integer);
}

Console.WriteLine("How many items does my Queue have? {0}!", queue.Count);