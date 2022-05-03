using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents 
{
    public static event System.Action<bool>UseBombEvent;


    public static void CallUseBombEvent(bool useBomb)
    {
        UseBombEvent?.Invoke(useBomb);
    }

    
}
