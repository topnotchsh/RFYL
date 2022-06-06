using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameSoundManager : MonoBehaviour
{

    AudioSource playerSource;
    public AudioClip audioHeart;
    public AudioClip audioTalis;
    public AudioClip audioWalk;
    public AudioClip audioAttack;

    void Awake()
    {
        this.playerSource = GetComponent<AudioSource>();
    }

    
}
