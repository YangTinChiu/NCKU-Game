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
    [SerializeField] float atk = 5;

    public float Life = 100;
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

        //face
        if(distance <= maxdetectdistance)
        {
            Vector3 v = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
            Quaternion rotation = Quaternion.LookRotation(v - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
        }

        //moving and attack
        if((2 <= distance) && (distance <= maxdetectdistance))
        { 
            Vector3 movingDirction = new Vector3(playerTransform.position.x - t.position.x, 0,playerTransform.position.z - t.position.z).normalized;
            t.localPosition += movingSpeed * Time.deltaTime * movingDirction;
            animator.SetInteger("State", 1);
        }else if (2 >= distance){
            animator.SetInteger("State", 2);

            //enemy attack
            if (damageDelay > 2.0f) {
                damageDelay = 0f;

                RaycastHit hit;
                if (Physics.Raycast(transform.position, (playerTransform.position-transform.position), out hit, 2))
                {
                    if(hit.transform == playerTransform)
                    {
                        JohnState johnState = player.GetComponent<JohnState>();
                        johnState.Damage(atk);
                    }
                }
            }
        }else {
            animator.SetInteger("State", 0);
        }
    }
    public bool Damage(float atk) {
        Life -= atk;

        health_bar_func.set_health(Life / 100f);

        if(Life<=0) {
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
