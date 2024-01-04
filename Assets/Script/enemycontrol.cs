using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemycontrol : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player;
    [SerializeField] float movingSpeed = 2;
    [SerializeField] float maxdetectdistance = 10;

    public int Life = 100;
    public health_bar health_bar_func;

    Transform playerTransform, t;
    float damageDelay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        damageDelay += Time.deltaTime;
        if(animator.GetInteger("State") == 3) {
            return;    
        }
        playerTransform = player.transform;
        t = transform;

        float distance = Vector3.Distance(t.position, playerTransform.position);

        if((2 <= distance) && (distance <= maxdetectdistance))
        { 
            Vector3 movingDirction = new Vector3(playerTransform.position.x - t.position.x, 0,playerTransform.position.z - t.position.z).normalized;
            t.localPosition += movingSpeed * Time.deltaTime * movingDirction;
            animator.SetInteger("State", 1);
        }else if ((2 >= distance) && (distance <= maxdetectdistance)){
            animator.SetInteger("State", 2);
        }else {
            animator.SetInteger("State", 0);
        }
    }
    public bool Damage() {
        Life -= 10;

        health_bar_func.set_health(Life / 100f);

        if(Life==0) {
            animator.SetInteger("State", 3);
            return true;
        }
        return false;
    }
    
    void OnCollisionStay(Collision collision) {
        // if(collision.gameObject.tag == "Player") {
        //     if(damageDelay >= 1f) {
        //         damageDelay = 0.0f;
        //         Damage();
        //     }
        // }
    }
}
