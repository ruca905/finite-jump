using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour{
	public Slider music,sounds;
    void Start(){
        gameObject.GetComponent<Canvas>().enabled=false;
		music.value=PlayerPrefs.GetFloat("Mvol",1);
		sounds.value=PlayerPrefs.GetFloat("Svol",1);
    }

	public void pauseOn(){
		if(Time.timeScale==1){
			Time.timeScale=0;
			gameObject.GetComponent<Canvas>().enabled=true;
		}
	}
	
	public void pauseOff(){
		Time.timeScale=1;
        gameObject.GetComponent<Canvas>().enabled=false;	
	}
	
	public void back(){
		PlayerPrefs.SetFloat("Mvol",music.value);
		PlayerPrefs.SetFloat("Svol",sounds.value);
		SceneManager.LoadScene("start");
	}
}