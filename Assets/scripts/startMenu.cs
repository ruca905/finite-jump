using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour{
	public void playFinite(){
		SceneManager.LoadScene("infinite");
	}
}