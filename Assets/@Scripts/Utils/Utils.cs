using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Utils
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        var component = go.GetComponent<T>();

        if (component == null)
            component.gameObject.AddComponent<T>();

        return component;
    }
}