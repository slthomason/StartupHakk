//Boxing

int value = 5;
Object obj = (object)value; //boxing - casting the integer to object type


int value = 5; 
Object obj = value; 
value = 6; 
Console.WriteLine(obj);

//Unboxing
int unboxedValue = (int)obj;

//The is operator
int unboxedValue;
if (obj is int)
{
    unboxedValue = (int)obj;
}

//The as operator
int? unboxedvalue = obj as int?;
