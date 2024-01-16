using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Character : MonoBehaviour
{
	public GameObject Player;
    public static Character instance;
    public Animator animator;
	public int isPassed = 0;
	private Camera mainCamera;

	void Start(){
        mainCamera = Camera.main;
	}


	void Update() {
		
		if (isPassed == 1) {
			Character_jump();
			isPassed = 0;
		}
		if(transform.position.x>0){
		mainCamera.transform.position = new Vector3(transform.position.x,0,-10);
		}
	}

	public void Character_jump(){
		if((Score.instance.score -2) * 7 == transform.position.x){
		Player.transform.DOJump(transform.position+(Vector3.right * 7), 3, 1, 0.2f, true);
		animator.SetTrigger("IsJumping");
		}else{
		transform.position = new Vector3((Score.instance.score -2) * 7,0,0);
		Player.transform.DOJump(transform.position+(Vector3.right * 7), 3, 1, 0.2f, true);
		animator.SetTrigger("IsJumping");
		}
	}

    public void CorrectAnswer(){
		isPassed = 1;
	}

	private void Awake() {
		instance = this;
	}


}