using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
	// public int startingLives;
	public GameObject gameOverScreen;
	public string mainMenu;
	public float waitAfterGameOver;

	private int lifeCounter;
	private Text theText;
	private PlayerController player;

	// Use this for initialization
	void Start ()
	{
		this.theText = GetComponent<Text> ();
		this.lifeCounter = PlayerPrefs.GetInt ("PlayerCurrentLives");
		this.player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.lifeCounter < 0) {
			this.gameOverScreen.SetActive (true);
			this.player.gameObject.SetActive (false);
		}

		this.theText.text = "x " + this.lifeCounter;

		if (this.gameOverScreen.activeSelf) {
			this.waitAfterGameOver -= Time.deltaTime;
		}

		if (this.waitAfterGameOver < 0) {
			Application.LoadLevel (this.mainMenu);
		}
	}

	public void GiveLife ()
	{
		this.lifeCounter++;
		PlayerPrefs.SetInt ("PlayerCurrentLives", this.lifeCounter);
	}

	public void TakeLife ()
	{
		this.lifeCounter--;
		PlayerPrefs.SetInt ("PlayerCurrentLives", this.lifeCounter);
	}
}
