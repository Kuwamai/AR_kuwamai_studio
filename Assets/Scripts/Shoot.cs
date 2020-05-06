using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public Transform muzzle;
    public float speed = 1000;

    public SteamVR_Input_Sources hand;
    public SteamVR_Action_Boolean clickAction;

    public float timeOut;
    private float timeElapsed;

    void Update () {
        if (clickAction.GetState(hand)){
            timeElapsed += Time.deltaTime;

            if(timeElapsed >= timeOut){
                // 弾丸の複製
                GameObject bullets = Instantiate(bullet) as GameObject;
                Renderer coloring = bullets.GetComponent<Renderer>();
                coloring.material.color = new Color(Random.value, Random.value, Random.value, 1.0f);

                Vector3 force;

                force = muzzle.gameObject.transform.forward * speed;

                // Rigidbodyに力を加えて発射
                bullets.GetComponent<Rigidbody>().AddForce(force);

                // 弾丸の位置を調整
                bullets.transform.position = muzzle.position;

                timeElapsed = 0.0f;
            }
        }
    }
}