using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class log : MonoBehaviour
{
    [Conditional("DEBUG")]
    public void Log(string t)
    {
        Debug.Log(t);
    }
}