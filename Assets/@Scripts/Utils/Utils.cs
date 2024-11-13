using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Utils
{
 

    public static string  RemoveCloneFormat( string target)
    {
        int index = target.IndexOf("(Clone)");
        if (index >= 0) 
            target = target.Substring(0, index);

        return target;
    }
}