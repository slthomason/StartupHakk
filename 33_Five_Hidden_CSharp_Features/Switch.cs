//old way
switch (light.Status)
{
	case ON:
		text = "Light is on";
		break;
	case OFF:
		text = "Light is off";
		break;
	default:
		text = "Unknown status";
		break;
}

//new way
text = light.Status switch
{
	ON => "Light is on",
	OFF => "Light is off",
	_ => "Unknown status"
}