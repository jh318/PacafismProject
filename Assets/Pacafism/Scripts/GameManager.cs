using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public float playerScore = 0.0f;
	public float playerMultiplier = 1.0f;
	public Text scoreText;
	public Text multiplierText;
	public Text FinalScore;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);	
	}

	void Start(){
		scoreText.text = playerScore.ToString();
		multiplierText.text = playerMultiplier.ToString ();
	}

	void Update(){
		if (!PlayerController.player.isActiveAndEnabled) {
			StartCoroutine ("EndGame");
		}
	}

	public void SetScore(float score){
		playerScore += score * playerMultiplier;
		scoreText.text = playerScore.ToString();
	}

	public void SetMultiplier(float multi){
		playerMultiplier += multi;
		multiplierText.text = "x " + playerMultiplier.ToString ();
	}

	IEnumerator EndGame(){
		FinalScore.text = "Final Score: " + playerScore.ToString();
		scoreText.gameObject.SetActive (false);
		multiplierText.gameObject.SetActive (false);
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene ("Main");
	}
}
