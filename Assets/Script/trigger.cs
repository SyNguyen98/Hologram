using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {
    public Animator ani;
    public AudioClip Introduce;
    public AudioClip Wait;
    public AudioClip Vuonvai;
    AudioSource MiyukiVoice;
    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
        MiyukiVoice = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            ani.SetTrigger("1");
        }
        if (Input.GetKeyDown("2"))
        {
            ani.SetTrigger("2");
        }
        if (Input.GetKeyDown("3"))
        {
            ani.SetTrigger("3");
        }
        if (Input.GetKeyDown("4"))
        {
            ani.SetTrigger("4");
            MiyukiVoice.PlayOneShot(Introduce);
        }
        if (Input.GetKeyDown("5"))
        {
            ani.SetTrigger("5");
            MiyukiVoice.PlayOneShot(Wait);
        }
        if (Input.GetKeyDown("6"))
        {
            ani.SetTrigger("6");
            MiyukiVoice.PlayOneShot(Vuonvai);
        }
        if (Input.GetKeyDown("7"))
        {
            ani.SetTrigger("7");
        }
    }
}
