using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talisman : MonoBehaviour
{
    public static int numTalis;
    public float rotateSpeed = 180f;

    //public SoundManager sm;

    [System.NonSerialized]
    public int talisman = 1;
    void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    public void SetTalismanValue(int talisman)
    {
        this.talisman = talisman;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            numTalis++;
            col.gameObject.GetComponent<PlayerParams>().AddTalisman(talisman);
            //sm.PickUpSound();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }
}
