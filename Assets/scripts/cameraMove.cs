using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour{
	public GameObject plr,Rwall,Bwall,floor;
	public float dY;
	
    void Update(){
        transform.position=new Vector3(transform.position.x,plr.transform.position.y+dY,transform.position.z);
		moveWithPlr(Rwall);
		moveWithPlr(Bwall);
		moveWithPlr(floor);
    }
	
	void moveWithPlr(GameObject tran){
		tran.transform.position=new Vector2(tran.transform.position.x,plr.transform.position.y);
	}
}