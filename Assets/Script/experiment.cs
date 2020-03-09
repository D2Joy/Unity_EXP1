using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class experiment : MonoBehaviour
{
    List<string> shuffled;
    List<string> answers;
    // Start is called before the first frame update
    void Start()
    {
        //read CRT
        List<string> CRT = File.ReadAllLines( System.IO.Directory.GetCurrentDirectory() +@"\CRT.txt").ToList();
        print(CRT.Count +"-"+ CRT);
        ////RANDOMIZE
        shuffled = CRT.OrderBy(x => Guid.NewGuid()).ToList();
        print(shuffled);
    }

    //select and present CRT
    public void question(int qs){      
        //System.Random rnd = new System.Random();
        //int index = rnd.Next(CRT.Count);
        //print(shuffled);
        //print(shuffled[n]);
        if (qs<shuffled.Count)
        {
            print(shuffled[qs]);
        }else{
            return;
        }
        
        // if(qs==0){
        //     //CRT1
        //     print(shuffled[0]);
        //     //print(CRT[index]+CRT.Count+"-0METERS");
        // }else if(qs==1){
        //     //CRT2
        //     print(shuffled[1]);
        //     //print(CRT[index]+CRT.Count+"-6METERS");
        // }else if(qs==2){
        //     //CRT3
        //     print(shuffled[2]);
        //     //print(CRT[index]+CRT.Count+"-20METERS");
        // }
        //CRT.RemoveAt(index);
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
