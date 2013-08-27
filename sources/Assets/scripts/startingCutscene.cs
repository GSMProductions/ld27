using UnityEngine;
using System.Collections;

public class startingCutscene : MonoBehaviour {

	public CharacterMotor hero;
	public MouseLook heroLook;
	public MouseLook cameraLook;
	public clock timer;
	public GameObject subs;

	public AudioSource[] sfx;

	public GameObject light;
	public flicker flickerFX;

	float timeSinceStart;
	int lastSequence;


	// Use this for initialization
	void Start () {
		lastSequence = 0;
		timeSinceStart = 0.0f;
		timer.enabled = false;
		//hero.enabled = false;
		//heroLook.enabled=false;
		//cameraLook.enabled = false;
		subs.GetComponent<subtitles>().display("ecran_noir",9.0f);
		sfx[0].Play();
		CameraFade.StartAlphaFade( Color.black, true, 10f, 2f, () => { } );
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceStart += Time.deltaTime;

		if (timeSinceStart >= 10 && lastSequence == 0) {
			sfx[1].Play();
			subs.GetComponent<subtitles>().display("fade_in",5.0f);
			lastSequence = 1;
		}
		if (timeSinceStart >= 15 && lastSequence == 1) {
			flickerFX.flickering = true;
			heroLook.enabled=true;
			cameraLook.enabled = true;
			lastSequence = 2;
		}
		if (timeSinceStart >= 18 && lastSequence == 2) {
			flickerFX.flickering = false;
			flickerFX.TurnOn();
			sfx[2].Play();
			subs.GetComponent<subtitles>().display("lumiere_allume",12.0f);
			lastSequence = 3;
		}
		if (timeSinceStart >= 30 && lastSequence == 3) {
			hero.enabled = true;
			lastSequence = 4;
		}

	}


	public void playNext() {

		if (lastSequence == 5){
			subs.GetComponent<subtitles>().display("devant_fenetre",16.0f);
			sfx[4].Play();
			lastSequence = 6;
			//timer.enabled = true;
			//timer.running = true;

		}

		if (lastSequence == 4){
			subs.GetComponent<subtitles>().display("sortie_chambre",9.0f);
			sfx[3].Play();
			lastSequence = 5;
		}


	}


	void restartControl() {
		timer.enabled = true;
		hero.enabled = true;
		heroLook.enabled=true;
		cameraLook.enabled = true;
		timer.running = true;

	}
}
