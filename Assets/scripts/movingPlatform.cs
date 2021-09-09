using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour{
	float sX,sY,eX,eY,spdX,spdY;
	public float distance;
    void Start(){
        sX=gameObject.transform.position.x;
		eX=sX+UnityEngine.Random.Range(1,4)+1F;
		spdX=UnityEngine.Random.Range(1,4)/100F;
    }

    void FixedUpdate(){
        transform.position=new Vector2(transform.position.x+spdX,transform.position.y);
		if(transform.position.x>eX){
			spdX=-spdX;
		}else
			if(transform.position.x<sX){
				spdX=-spdX;
			}
    }
}