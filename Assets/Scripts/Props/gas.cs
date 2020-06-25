using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gas : MonoBehaviour{
    public GameObject player;
    public GameObject monster;
    public float onTime;//成功动画所用时间
    public float dist;

    bool isOn;
    Animator mAnim;
    float t2;
    
    void Start(){
        t2 = onTime;
        isOn = false;
        mAnim = GetComponent<Animator>();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.F)) {
            if (isClose(player) && isClose(monster)) {
                isOn = true;
                mAnim.SetBool("succ", true);
                //Debug.Log("on");
                //send message to player 
            }
            else if(isClose(player) && !isClose(monster)) {
                mAnim.SetBool("fail", true);
                //Debug.Log("fail");
                //send message to player
            }
        }
        if (isOn) {
            t2 = t2 - Time.deltaTime;
            if (t2 <= 0) {
                mAnim.SetBool("succ", false);
                Debug.Log("off");
                t2 = onTime;
            }
        }

    }

    bool isClose(GameObject obj) {
        //Bounds objBound = obj.GetComponent<Collider2D>().bounds;
        //Bounds gasBound = GetComponent<Collider2D>().bounds;

        //Debug.Log(objBound);
        //Debug.Log(gasBound);

        //Vector2 newSize = gasBound.size;
        //newSize.x = newSize.x * 1.5f;
        //newSize.y = newSize.y * 1.5f;

        //Bounds testBounds = new Bounds(gasBound.center, newSize);

        //return testBounds.Intersects(objBound);

        Bounds objBound = obj.GetComponent<Collider2D>().bounds;
        Bounds gasBound = GetComponent<Collider2D>().bounds;

        float dis = (gasBound.center - objBound.center).magnitude;
        //Debug.Log(dis);
        return (dis < dist);

    }

    private void OnDestroy() {
        Destroy(gameObject, 0f);
    }
}
