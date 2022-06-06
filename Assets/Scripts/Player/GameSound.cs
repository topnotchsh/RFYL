using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    
    static AudioSource playerSource;
    public static AudioClip audioHeart;
    public static AudioClip audioTalis;
    public static AudioClip audioWalk;
    public static AudioClip audioAttack;

    // Start is called before the first frame update
    void Awake()
    {
        playerSource = GetComponent<AudioSource>();
    }


}
