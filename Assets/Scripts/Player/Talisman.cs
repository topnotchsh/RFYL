﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talisman : MonoBehaviour
{
    public float rotateSpeed = 180f;

    [System.NonSerialized]
    public int talisman = 1;
    void Start()
    {

    }

    public void SetTalismanValue(int talisman)
    {
        this.talisman = talisman;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerParams>().AddTalisman(talisman);
            //SoundManager.instance.PlayPickUpSound();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }
}
