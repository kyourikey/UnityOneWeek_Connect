using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Action OnRedClick;
    public static Action OnBlueClick;
    public static Action OnGreenlick;
    
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Z))
        {
            if(OnGreenlick != null)
    	        OnRedClick();
	    }
	    if (Input.GetKeyDown(KeyCode.X))
	    {
	        if (OnBlueClick != null)
                OnBlueClick();
	    }
	    if (Input.GetKeyDown(KeyCode.C))
	    {
	        if (OnGreenlick != null)
                OnGreenlick();
	    }
    }
    
}
