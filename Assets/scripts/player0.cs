using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player0 : MonoBehaviour{
	public float spd,jumpH;
	private Collider2D box;
	private Rigidbody2D plRB;
	public LayerMask lm;
    void Start(){
        box=gameObject.GetComponent<Collider2D>();
		plRB=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        if((Input.touchCount>0)|(Input.GetAxis("Jump")>0)){
			if(box.IsTouchingLayers(lm)){
				plRB.velocity=new Vector2(spd,jumpH);
			}
		}else{
				plRB.velocity=new Vector2(spd,plRB.velocity.y);
			}
    }
}