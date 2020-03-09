using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public GameObject m_ElevatorController;
	[HideInInspector]
	public bool ElevatorMoving;
	
	public void SendCall (string Call) {
		elevator Elevator = m_ElevatorController.GetComponent<elevator>();
		ElevatorMoving = Elevator.elevatorMoving;
		if(Call == "ElevatorUp" && !ElevatorMoving)
		{
			Elevator.ElevatorGO("ElevatorUp");
		}
		else if(Call == "ElevatorDown" && !ElevatorMoving)
		{
			Elevator.ElevatorGO("ElevatorDown");
		}
	}
	void OnMouseDown(){
         // this object was clicked - do something
		print("clicked--"+gameObject.tag);	
		if(gameObject.CompareTag ("ElevatorUp")){
			SendCall("ElevatorUp");
			gameObject.SetActive(false);
		}
		//this.enable=false;
	}   

	public void ButtonPressed() {
		print("pressed--"+gameObject.tag);
		if(gameObject.CompareTag ("ElevatorUp")){
			SendCall("ElevatorUp");
			gameObject.SetActive(false);
		}
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
