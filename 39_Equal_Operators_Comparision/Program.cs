int integer1 = 17;
int integer2 = 17;
object integer3 = integer1;

var equal0 = integer1 == integer2;
var equal1 = (object)integer1 == integer3;
var equal2 = integer1.Equals(integer2);
var equal3 = object.Equals(integer1, integer3);
var equal4 = object.ReferenceEquals(integer1, integer2);
var equal5 = object.ReferenceEquals(integer2, integer3);

Console.WriteLine(equal0);   // True
Console.WriteLine(equal1);   // False
Console.WriteLine(equal2);   // True
Console.WriteLine(equal3);   // True
Console.WriteLine(equal4);   // False
Console.WriteLine(equal5);   // False