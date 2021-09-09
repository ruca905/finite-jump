using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMoving : MonoBehaviour{
    public float jumpH, speed, dT,jumpScale,dx;
	private Rigidbody2D plRB;
	public Canvas deathScrnCanv,pauseCanv;
	public Text boostCntdwn;
	public int total=0;
	private bool ghost;
	private int ms;
	public Camera cam;
	public GameObject Rwall,Bwall,Sjump,SgetB1,SgetB2,Sdeath,Sbreak,SforceJump;//forceJump - от платформы прыгучей
	public int dR,dB;
	public Slider music,sounds;
	private Color origR,origB,deltaR,deltaB;

	public Animator animator; 
	
	void Start(){
        plRB=GetComponent<Rigidbody2D>();
		deathScrnCanv.enabled=false;
		ghost=false;
		dR=0;
		dB=0;
		Time.timeScale=1;
		origR=Rwall.GetComponent<Renderer>().material.color;
		origB=Bwall.GetComponent<Renderer>().material.color;
		deltaR=origR;
		deltaB=origB;
		deltaR.a=0.5f;
		deltaB.a=0.5f;
    }
	
    void FixedUpdate(){
		//plRB.velocity=new Vector2(speed*Input.acceleration.x,plRB.velocity.y);
		plRB.velocity=new Vector2(speed*Input.GetAxis("Horizontal"),plRB.velocity.y);
		
		if(ghost){
			if(ms%50==0){
				boostCntdwn.text=(ms/50).ToString();
			}
			ms--;
			if(ms==0){
				ghost=false;
				boostCntdwn.text="";
				Rwall.GetComponent<Renderer>().material.color=origR;
				Bwall.GetComponent<Renderer>().material.color=origB;	
			}
			if(gameObject.transform.position.x>(cam.transform.position.x+2.835F))
				gameObject.transform.position=new Vector2((gameObject.transform.position.x-5.67F),gameObject.transform.position.y);
			if(gameObject.transform.position.x<(cam.transform.position.x-2.835F))
				gameObject.transform.position=new Vector2((gameObject.transform.position.x+5.67F),gameObject.transform.position.y);
		}
		/*if(Input.GetAxis("KeyCode.Escape")>0){
			pauseCanv.GetComponent<pause>().pauseOn();
		}*/
    }
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="platform"){
			//animator.SetBool("Jump", true);
			if(plRB.velocity.y<0){
				plRB.velocity=new Vector2(plRB.velocity.x,jumpH);
				Sjump.GetComponent<AudioSource>().Play();
			}
			//animator.SetBool("Jump", false);
		}
		if(col.gameObject.tag=="p_bad"){
			//animator.SetBool("Jump", true);
			if (plRB.velocity.y<0){
				plRB.velocity=new Vector2(plRB.velocity.x,jumpH);
				Sjump.GetComponent<AudioSource>().Play();
				Sbreak.GetComponent<AudioSource>().Play();
				Destroy(col.gameObject);
			}
			//animator.SetBool("Jump", false);
		}
		if(col.gameObject.tag=="p_jump"){
			//animator.SetBool("Jump", true);
			if (plRB.velocity.y<0){
				plRB.velocity=new Vector2(plRB.velocity.x,jumpH*jumpScale);
				SforceJump.GetComponent<AudioSource>().Play();
			}
			//animator.SetBool("Jump", false);
		}
		if(col.gameObject.tag=="deathWall"){
			if(!ghost){
				death();
			}
		}
		if(col.gameObject.tag=="floor"){
			death();
		}
		if(col.gameObject.tag=="boost_yellow"){
			ghost=true;
			ms+=500;
			SgetB2.GetComponent<AudioSource>().Play();
			Rwall.GetComponent<Renderer>().material.color=deltaR;
			Bwall.GetComponent<Renderer>().material.color=deltaB;
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag=="boost_red_r"){
			dR--;
			moveWall(Rwall,1);
			SgetB1.GetComponent<AudioSource>().Play();
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag=="boost_red_l"){
			dR++;
			moveWall(Rwall,-1);
			SgetB1.GetComponent<AudioSource>().Play();
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag=="boost_blue_r"){
			dB++;
			moveWall(Bwall,1);
			SgetB1.GetComponent<AudioSource>().Play();
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag=="boost_blue_l"){
			dB--;
			moveWall(Bwall,-1);
			SgetB1.GetComponent<AudioSource>().Play();
			Destroy(col.gameObject);
		}
	}
	
	public void moveWall(GameObject wall,int how){
		wall.transform.position=new Vector2(wall.transform.position.x+dx*how,wall.transform.position.y);
	}
	
	public void death(){
		Sdeath.GetComponent<AudioSource>().Play();
		Time.timeScale=0;
		deathScrnCanv.enabled=true;
	}
	
	public void restartGame(){
		PlayerPrefs.SetFloat("Mvol",music.value);
		PlayerPrefs.SetFloat("Svol",sounds.value);
		deathScrnCanv.enabled=false;
		Time.timeScale=1;
		SceneManager.LoadScene("infinite");
	}
}
