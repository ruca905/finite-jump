using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour{
	private Rigidbody2D plRB;
	public float spdX,spdY;
	
    void Start(){
		plRB=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        plRB.velocity=new Vector2(Input.GetAxis("Horizontal")*spdX,spdY);
    }
	
	/*void OnTriggerEnter(Collider2D col){
		if(col.gameObject.tag=="acceleration"){
			spdX*=
		}
	}*/
}