using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemycontrol : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float movingSpeed = 2;
    [SerializeField] float maxdetectdistance = 30;

    Transform playerTransform, t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = player.transform;
        t = transform;

        float distance = Vector3.Distance(t.position, playerTransform.position);

        if((2 <= distance) && (distance <= maxdetectdistance))
        { 
            Vector3 movingDirction = new Vector3(playerTransform.position.x - t.position.x, 0, playerTransform.position.z - t.position.z).normalized;

            t.localPosition += movingSpeed * Time.deltaTime * movingDirction;
        }
        
    }
}
