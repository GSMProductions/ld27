 using UnityEngine;
 using System.Collections;
 public class flicker : MonoBehaviour {
   
    float timer;
    float wait;
    public bool flickering = false;
 
    void Start() {
    	wait = Random.Range(0f,3f);
   	}

    void Update(){
       timer +=Time.deltaTime;
       if(timer>wait && flickering){
         Blink();
         timer =0f;
         wait = Random.Range(0f,3f);
       }
    }

    void Blink(){
    	light.enabled = !light.enabled;
    }
}