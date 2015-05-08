using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
	public Transform[] backgrounds;
	public float smoothing;

	private float[] parallaxScales;
	private Transform cam;
	private Vector3 previousCamPos;

	// Use this for initialization
	void Start ()
	{
		this.cam = Camera.main.transform;
		this.previousCamPos = this.cam.position;
		this.parallaxScales = new float[this.backgrounds.Length];
		for (int i = 0; i < this.backgrounds.Length; i++) {
			this.parallaxScales[i] = this.backgrounds[i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		for (int i = 0; i < this.backgrounds.Length; i++) {
			float parallax = (this.previousCamPos.x - this.cam.position.x) * this.parallaxScales[i];
			float backgroundTargetPosX = this.backgrounds[i].position.x + parallax;
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, this.backgrounds[i].position.y, this.backgrounds[i].position.z);
			this.backgrounds[i].position = Vector3.Lerp (this.backgrounds[i].position, backgroundTargetPos, this.smoothing * Time.deltaTime);
		}
		this.previousCamPos = this.cam.position;
	}
}
