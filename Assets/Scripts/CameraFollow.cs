﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float Ahead; //当角色向右移动时，摄像机比任务位置领先，当角色向左移动时，摄像机比角色落后
    public Vector3 Targetpos; //摄像机的最终目标
    public float smooth; //摄像机平滑移动的值

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
       Targetpos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0)
        {
            Targetpos = new Vector3(player.transform.position.x + Ahead, transform.position.y, transform.position.z);
        }
        if (player.transform.localScale.x < 0)
        {
            Targetpos = new Vector3(player.transform.position.x - Ahead, transform.position.y, transform.position.z);
        }
        //让摄像机进行平滑的移动
        transform.position = Vector3.Lerp(transform.position, Targetpos, smooth);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
