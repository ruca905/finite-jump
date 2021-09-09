using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeManager : MonoBehaviour{
	private AudioSource Msrc;
	private float Mvol=1F;
    void Start(){
        Msrc=GetComponent<AudioSource>();
    }

	void Update(){
        Msrc.volume=Mvol;
    }
	
	public void setVol(float v){
		Mvol=v;
	}
}