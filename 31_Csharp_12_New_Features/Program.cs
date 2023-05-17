
//Using directives for additional types
using Measurement = (string Units, int Distance);
using PathOfPoints = int[];
using DatabaseInt = int?;


public void CalculateDistance(PathOfPoints points)
{ }

//Default values for lambda expressions
var addWithDefault = (int addTo = 2) => addTo + 1;
addWithDefault(); // 3
addWithDefault(5); // 6