using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera0 : MonoBehaviour{
	public GameObject floor,plr;
	public float dX;
	void Start(){
        
    }
	
	void Update(){
        transform.position=new Vector3(plr.transform.position.x+dX,transform.position.y,transform.position.z);
		floor.transform.position=new Vector2(plr.transform.position.x,floor.transform.position.y);
    }
}