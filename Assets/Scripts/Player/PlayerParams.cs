﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParams : MonoBehaviour
{   
    public int talisman { get; set; }
    public int maxTalisman;

    public GameManager gm;

    void Start()
    {
        InitParams();
    }

    public void InitParams()
    {
        talisman = 0;

        //isDead = false;

        //초기화 할때 헤드업 디스플레이에 플레이어 이름과 기타 정보가 표시되도록 함
        UIManager.instance.UpdatePlayerUI(this);
    }

    public void AddTalisman(int talisman)
    {
        this.talisman += talisman;
        UIManager.instance.UpdatePlayerUI(this);
        if(gm.talisman != 0 ) gm.EndGame();
    }

    // 사운드
    void PlaySound(string action){
        switch (action){
            case "ATTACK":
                audioSource.clip = audioAttack;
        }
    }


}
