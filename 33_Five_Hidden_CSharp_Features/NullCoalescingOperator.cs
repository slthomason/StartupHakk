
//Old Way
variable = MightReturnNull();
if(variable == null)
{
    variable = "default";
}


//New Way
var variable = MightReturnNull() ?? "default";


//Old Way
if (variable is null)
{
    variable = expression;
}

//New 

variable ??= expression;