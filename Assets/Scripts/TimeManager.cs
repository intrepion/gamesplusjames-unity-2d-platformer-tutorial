using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
	public float startingTime;
	//public GameObject gameOverScreen;

	private Text theText;
	private PauseMenu thePauseMenu;
	//private PlayerController player;
	private float countingTime;
	private HealthManager theHealth;

	// Use this for initialization
	void Start ()
	{
		this.theText = GetComponent<Text> ();
		this.thePauseMenu = FindObjectOfType<PauseMenu> ();
		this.countingTime = this.startingTime;
		this.theHealth = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (this.thePauseMenu.isPaused) {

			return;
		}

		this.countingTime -= Time.deltaTime;

		if (this.countingTime <= 0) {
			this.theHealth.KillPlayer();
		}

		this.theText.text = "" + Mathf.Round(this.countingTime);
	}

	public void ResetTime ()
	{
		this.countingTime = this.startingTime;
	}
}
