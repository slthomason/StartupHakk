//SmartEnum class 
 public abstract class SmartEnum<TEnum, TValue> where TEnum : SmartEnum<TEnum, TValue>
 {
  private static readonly ConcurrentDictionary<TValue, TEnum> _items =
   new ConcurrentDictionary<TValue, TEnum>();

  public TValue Value { get; }
  public string Name { get; }

  protected SmartEnum(TValue value, string name)
  {
   Value = value;
   Name = name;
  }

  static SmartEnum()
  {
   // Automatically register all enum values
   foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
   {
    var item = (TEnum)field.GetValue(null);
    Register(item);
   }
  }

  public static TEnum FromValue(TValue value)
  {
   return _items[value];
  }

  public static bool TryFromValue(TValue value, out TEnum result)
  {
   return _items.TryGetValue(value, out result);
  }

  public static IEnumerable<TEnum> GetAll()
  {
   return _items.Values;
  }

  protected static TEnum Register(TEnum item)
  {
   return _items.GetOrAdd(item.Value, item);
  }

  public override string ToString()
  {
   return Name;
  }
 }

//--------------------------------------------------------------
// Gender class which is inherited SmartEnum class
 public class Gender : SmartEnum<Gender, string>
 {
  public static readonly Gender Male = new Gender("M", "Male");
  public static readonly Gender Female = new Gender("F", "Female");
  public static readonly Gender Unknown = new Gender("U", "Unknown");

  public Gender(string value, string name) 
   : base(value, name)
  {
  }
 }

//--------------------------------------------------------------
// Program.cs
using SmartEnums;

Gender gender = Gender.FromValue("M");
if (gender == Gender.Male)
{
 Console.WriteLine("The person is male.");
}

Console.ReadLine();
