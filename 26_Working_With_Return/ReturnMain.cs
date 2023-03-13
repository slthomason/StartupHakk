using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMain : MonoBehaviour
{

    // Create a program that takes a string and return length of it. (How Many Charachters)

    private string _name;
 
    private void Start()
    {  
        _name = "Jordan";    
        int charchterCount = GetCharachterCount(_name);
          Debug.Log("Charachter Count: " + charchterCount);
    }

    int GetCharachterCount(string name)
    { 
        return name.Length;
    }    

}