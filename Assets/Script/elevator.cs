using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;

public class elevator : MonoBehaviour
{
    public float speed;
    //public Text scoreText;
    public TMPro.TextMeshProUGUI scoreText;
    Rigidbody rb;
    //cameraFollow camerafollow;
    public GameObject otherButton;
    experiment exp;
    float height;
    [HideInInspector]
    public bool elevatorMoving;
    string elevatorDirection;
    public List<float> heights;
    int level=0;
    //public List<Vector2> test;
    int des=0;

    // Start is called before the first frame update
    void Start(){
    	rb=GetComponent<Rigidbody>();
		//exp = otherCamera.GetComponent<experiment>();
		height=transform.position.y;
		updateHeight();
        exp= GetComponent<experiment>();
    }
    public void ElevatorGO (string ElevatorDirection) {
		elevatorDirection = ElevatorDirection;   
		print("current:"+level);
		if(elevatorDirection == "ElevatorUp" && !elevatorMoving && level<heights.Count-1)
		{
            des=heights.FindIndex(x => x>height)>-1?heights.FindIndex(x => x>height):heights.Count-1;
			level += 1;     
		}
		if(elevatorDirection == "ElevatorDown" && !elevatorMoving && level>=1)
		{
            des=heights.FindIndex(x => x<height)>-1?heights.FindIndex(x => x<height):0;
			level -= 1;
            print("NEXT--"+heights.FindIndex(x => x<height));
		}
        print("destination:"+level);
        print("NEXT--"+des);
		// soundplayed = false;
		// m_soundplayed = false;
	}

	void updateHeight(){
        if (height>50f){
            scoreText.text="Height:"+ Math.Round(height,1).ToString()+" m"+"\r\n"+"You are out!";
        } else{
		    scoreText.text="Height:"+ Math.Round(transform.position.y,1).ToString()+" m";
        }
	}

     // Update is called once per frame
    void FixedUpdate()
    {
        height = transform.position.y;
        // if(Input.GetKeyDown(KeyCode.M)){
        //     rb.MovePosition(transform.position + Vector3.up*heights[level]);
        // //transform.position += speed*transform.up*Time.deltaTime;
        // if(height < 6f){
        //     Vector3 destination = transform.position + Vector3.up*speed*Time.deltaTime;
    	//     //rb.AddForce(movement * speed);
        //     rb.MovePosition(destination.magnitude < new Vector3(0.0f,6f,0.0f).magnitude?destination :new Vector3(0.0f,6f,0.0f));
        // }
		// }
        // if(Input.GetKey(KeyCode.H)){
        // if(height < 20f &height >=6f){
        // rb.MovePosition(transform.position + Vector3.up*speed*Time.deltaTime);
        // }}
    if(Input.GetKeyDown(KeyCode.DownArrow)){
        ElevatorGO("ElevatorDown");
        // if(height >0.05f){
        // rb.MovePosition(transform.position + Vector3.down*speed*Time.deltaTime);
        // }
        }
    if(Input.GetKeyDown(KeyCode.UpArrow)){
        ElevatorGO("ElevatorUp");
    //     if(height <53f){
    //     rb.MovePosition(transform.position + Vector3.up*speed*Time.deltaTime);
    //     //transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.0f,6f,0.0f), speed);
    // }
    }
    //up and down, stop at preset height
    if(elevatorDirection == "ElevatorUp"){
		elevatorMoving = true;
            //rb.MovePosition(transform.position + Vector3.up*heights[level]);
		//transform.position = Vector3.MoveTowards(transform.position, Vector3.up*heights[level], speed);
        transform.position = Vector3.MoveTowards(transform.position, Vector3.up*heights[level], speed);
        if(this.transform.position == Vector3.up*heights[level]){
		    elevatorMoving = false;
            ElevatorGO("");
	    }
    }
    
    if(elevatorDirection == "ElevatorDown")
	{
		elevatorMoving = true;
		transform.position = Vector3.MoveTowards(transform.position, Vector3.up*heights[des], speed);
        if(this.transform.position == Vector3.up*heights[des]){
		    elevatorMoving = false;
            ElevatorGO("");
	    }
	}
    
    //show CRT
    if(Input.GetKeyDown(KeyCode.Q)){       
        exp.question(level);
        otherButton.SetActive(true);
    }
    updateHeight();
    }

    // void elevate(float height){
    //     if(height < 6f){}
    //     if(height < 20f &height >=6f){}
    //     if(height >0.05f){}
    //     Vector3 movement = new Vector3(0.0f,speed*1f,0.0f);
    //     rb.MovePosition(transform.position + movement*Time.deltaTime);
    // }
}
