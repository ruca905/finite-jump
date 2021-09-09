using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedure : MonoBehaviour{
	public float R;
	public Camera cam;
	public GameObject plr,Psimple,Pmove,Pbad,Pjump,By,BrR,BrL,BbR,BbL;
	int type,count;
	private float lastY;
	
    void Start(){
		for(float i=-4.5F;i<5.0F;i+=0.5F){
			Instantiate(Psimple,new Vector2(UnityEngine.Random.Range(cam.transform.position.x-2F,cam.transform.position.x+2F),cam.transform.position.y+i),Quaternion.identity);
		}

			lastY =cam.transform.position.y;
		count=0;
    }

    void Update(){
        if((cam.transform.position.y-lastY)>0.5){
			count++;
			lastY=cam.transform.position.y;
			type=UnityEngine.Random.Range(1,9);
			if(type<7)
				if(type<5)
					spawnPlatform(Psimple);
				else
					spawnPlatform(Pbad);
			else
				if(type<8)
					spawnPlatform(Pjump);
				else
					spawnPlatform(Pmove);
			type=UnityEngine.Random.Range(0,15);
			if(type==0){
				type=UnityEngine.Random.Range(1,10);
				if(type==9)
					spawnBoost(By);
				else
					if(type>4){
						if(type>6){
							if(plr.GetComponent<playerMoving>().dB<1)
								spawnBoost(BbR);
							else
								spawnBoost(BbL);
						}else
							spawnBoost(BbR);
					}else{
						if(type>2){
							if(plr.GetComponent<playerMoving>().dR<1)
								spawnBoost(BrL);
							else
								spawnBoost(BrR);
						}else
							spawnBoost(BrL);
					}
			}
		}
    }
	
	void spawnPlatform(GameObject obj){
		if(count==4){
			Instantiate(obj,new Vector2(UnityEngine.Random.Range(cam.transform.position.x-2,cam.transform.position.x+2),cam.transform.position.y+6),Quaternion.identity);
			count=0;
		}else{
			Instantiate(obj,new Vector2(UnityEngine.Random.Range(cam.transform.position.x- R,cam.transform.position.x+R),cam.transform.position.y+6),Quaternion.identity);
		}
	}
	
	void spawnBoost(GameObject obj){
		Instantiate(obj,new Vector2(UnityEngine.Random.Range(cam.transform.position.x-2F,cam.transform.position.x+2F),cam.transform.position.y+6),Quaternion.identity);
	}
}