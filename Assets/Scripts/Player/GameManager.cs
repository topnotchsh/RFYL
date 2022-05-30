using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [System.NonSerialized]
    public bool isGameover;
    public int talisman;
    public GameObject talismanObject;

    public PlayerParams pp;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameover = false;
        //FindObjectOfType<PlayerHealth>().onDeath += EndGame;
    }

    public void EndGame()
    {
        isGameover = true;

        // 만약 부적의 개수가 80개 이상이면 -> 생존 엔딩
        if (pp.talisman >= 80)
        {
            SceneManager.LoadScene("HappyEnding");
            DontDestroyOnLoad(talismanObject);
        }

        // 만약 부적의 개수가 80 미만이면 -> 사망 엔딩
        if (pp.talisman < 80)
        {
            SceneManager.LoadScene("BadEnding");
            DontDestroyOnLoad(talismanObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
