using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class NumpadLogic : MonoBehaviour
{
    public string winCode = "4236";
    protected string currentCode = "0000";
    public UnityEvent onWin;
    public TMPro.TextMeshProUGUI display;


    void Awake() {
        currentCode = display.text;
    }

    public void ButtonPressed(int val) {
        currentCode = currentCode.Substring(1) + val.ToString();
        display.text = currentCode;

        if (currentCode == winCode) {
            Debug.Log("WINNER!");
            if (onWin != null) {
                onWin.Invoke();
            }
        }
    }
    	void OnMouseDown(int val){
        currentCode = currentCode.Substring(1) + val.ToString();
        display.text = currentCode;
         // this object was clicked - do something
		print("clicked--"+gameObject.tag);	
		if(gameObject.CompareTag ("ElevatorUp")){
			//SendCall("ElevatorUp");
			gameObject.SetActive(false);
		}

	} 
}
