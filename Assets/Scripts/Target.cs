using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour{
    public static List<Target> targets = new List<Target>();
    ParticleSystem particles;
    Text text;

    // Start is called before the first frame update
    void Start(){
        targets.Add(this);
        particles = GetComponent<ParticleSystem>();
        text = GetComponentInChildren<Text>();
    }

    void OnDestroy(){
        targets.Remove(this);
    }

    public void Hit(){
        if (particles)
            particles.Play();
    }

    public void SetText(string message){
        if (text)
            text.text = message;
    }
}
