using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioSource musicsource;
	public AudioSource btnsource;

    public AudioSource playerSource;
    public AudioClip audioHeart;
    public AudioClip audioTalis;
    public AudioClip audioWalk;
    public AudioClip audioAttack;

    public void SetMusicVolume(float volume){
    	musicsource.volume = volume;
    }

    public void SetBtnVolume(float volume){
    	btnsource.volume = volume;
    }

    public void OnSfx(){
    	btnsource.Play();
    }

    public void AttackSound(){
        playerSource.clip = audioAttack;
        playerSource.Play();
    }

    public void PickUpSound(){
        playerSource.clip = audioTalis;
        playerSource.Play();
    }

    void Awake(){
        this.playerSource = GetComponent<AudioSource>();
    }
}
