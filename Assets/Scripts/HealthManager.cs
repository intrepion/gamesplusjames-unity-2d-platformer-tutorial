using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

	public static int playerHealth;

	public int maxPlayerHealth;
	public Text text;
	public bool isDead;

	private LevelManager levelManager;
	private LifeManager lifeSystem;
	private TimeManager theTime;

	// Use this for initialization
	void Start ()
	{
		this.text = GetComponent<Text> ();
		//HealthManager.playerHealth = this.maxPlayerHealth;
		HealthManager.playerHealth = PlayerPrefs.GetInt ("PlayerCurrentHealth");
		this.levelManager = FindObjectOfType<LevelManager> ();
		this.isDead = false;
		this.lifeSystem = FindObjectOfType<LifeManager> ();
		this.theTime = FindObjectOfType<TimeManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (HealthManager.playerHealth <= 0 && !this.isDead) {
			HealthManager.playerHealth = 0;
			this.levelManager.RespawnPlayer();
			this.isDead = true;
			this.lifeSystem.TakeLife ();
			this.theTime.ResetTime ();
		}

		this.text.text = "" + HealthManager.playerHealth;
	}

	public static void HurtPlayer (int damageToGive)
	{
		HealthManager.playerHealth -= damageToGive;
		PlayerPrefs.SetInt ("PlayerCurrentHealth", HealthManager.playerHealth);
	}

	public void FullHealth ()
	{
		HealthManager.playerHealth = PlayerPrefs.GetInt ("PlayerMaxHealth");
		PlayerPrefs.SetInt ("PlayerCurrentHealth", HealthManager.playerHealth);
	}

	public void KillPlayer ()
	{
		HealthManager.playerHealth = 0;

	}
}
