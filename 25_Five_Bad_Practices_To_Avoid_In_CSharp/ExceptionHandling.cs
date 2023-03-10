//Don't Do This

try { } 
catch(Exception ex) { 
  throw ex; 
} 

//Instead, do this:

catch(Exception ex) { 
  Logger.GetException(ex.Message); 
}

//Or this:

catch(Exception ex) { 
  throw; 
}     