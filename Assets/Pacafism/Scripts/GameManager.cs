using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public float playerScore = 0.0f;
	public float playerMultiplier = 1.0f;
	public Text scoreText;
	public Text multiplierText;

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

	public void SetScore(float score){
		playerScore += score * playerMultiplier;
		scoreText.text = playerScore.ToString();
	}

	public void SetMultiplier(float multi){
		playerMultiplier += multi;
		multiplierText.text = playerMultiplier.ToString ();
	}

}
