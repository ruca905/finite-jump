using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class platform : MonoBehaviour{
	public Camera cam;
	public GameObject counText,plr;
	
    void Update(){
        if(transform.position.x>100){
			if(transform.position.y<cam.transform.position.y-5){
				Destroy(gameObject);
				counText.GetComponent<Text>().text=(int.Parse(counText.GetComponent<Text>().text)+1+plr.GetComponent<playerMoving>().dR+plr.GetComponent<playerMoving>().dB).ToString();
			}
		}
    }
}