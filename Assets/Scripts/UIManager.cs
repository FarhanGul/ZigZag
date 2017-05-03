using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

//UI Manager is also responsible for handling scores;
public class UIManager : MonoBehaviour {

	public static event System.Action StartGame;
	public GameObject gameOver;
	public GameObject menu;
	public Text bestScore;
	public Text score;
	public Text endScore;
	public Text highScore;
	enum UIState{
		MENU,GAME,GAMEOVER
	}
	UIState uiState;
	bool isGameOver;
	int _score;
	int _highScore;

	void Start () {
		uiState = UIState.MENU;
		score.enabled = false;
		menu.SetActive (true);
		PlayerController.GameOver += () => {isGameOver = true;};
		PlayerController.Score += () => {_score++;};
		Pickup.DoubleScore += () => {_score+=2;};
		if(!PlayerPrefs.HasKey("HighScore")){
			PlayerPrefs.SetInt ("HighScore", 0);
			_highScore = 0;
		}
		else{
			_highScore = PlayerPrefs.GetInt ("HighScore");
		}
		bestScore.text = "BEST SCORE: " + _highScore.ToString ();
	}
	
	void Update () {
		switch(uiState){
		case UIState.MENU:
			if(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space)){
				if (StartGame != null)
				{
					StartGame ();
					menu.SetActive (false);
					score.enabled = true;
					uiState = UIState.GAME;
				}
			}
			break;
		case UIState.GAME:
			score.text = _score.ToString();
			if(isGameOver)
			{
				score.enabled = false;
				gameOver.SetActive (true);
				endScore.text = _score.ToString ();
				if(_score > _highScore){
					PlayerPrefs.SetInt ("HighScore", _score);
					_highScore = _score;
					//TODO: Display new best message
					//		Play sound
				}
				highScore.text = _highScore.ToString ();
				uiState = UIState.GAMEOVER;
			}
			break;
		}
	}
		
	public void Retry(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
