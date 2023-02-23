
//Everytime you want to throw a ArgumentNullException you will do something like this
string StartupHakk = null;

if(StartupHakk ==  null)
{
  throw new ArgumentException(nameof(StartupHakk));
}


//But now you can simplify things like this:
throw new ArgumentNullException(StartupHakk,nameof(StartupHakk));
 