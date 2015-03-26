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

	// Use this for initialization
	void Start ()
	{
		this.text = GetComponent<Text> ();
		HealthManager.playerHealth = this.maxPlayerHealth;
		this.levelManager = FindObjectOfType<LevelManager> ();
		this.isDead = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (HealthManager.playerHealth <= 0 && !this.isDead) {
			HealthManager.playerHealth = 0;
			this.levelManager.RespawnPlayer();
			this.isDead = true;
		}

		this.text.text = "" + HealthManager.playerHealth;
	}

	public static void HurtPlayer (int damageToGive)
	{
		HealthManager.playerHealth -= damageToGive;
	}

	public void FullHealth ()
	{
		HealthManager.playerHealth = this.maxPlayerHealth;
	}
}
