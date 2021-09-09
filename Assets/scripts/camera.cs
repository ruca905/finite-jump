using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour{
	public Transform Rwall,Bwall,floor;
	public GameObject plr;
    void Start(){
    }

	void moveWithPlr(Transform tran,float dy=0){
		tran.position=new Vector3(tran.position.x,plr.transform.position.y-dy,tran.position.z);
	}
	
    void Update(){
        if(transform.position.y<plr.transform.position.y){
			moveWithPlr(transform);
			moveWithPlr(Rwall);
			moveWithPlr(Bwall);
			moveWithPlr(floor,6);
		}
    }
}