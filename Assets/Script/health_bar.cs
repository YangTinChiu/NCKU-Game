using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_bar : MonoBehaviour
{
    public GameObject health_bar_obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate the health bar to face the camera
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
    }

    public void set_health(float health)
    {
        // set the health bar to the correct size
        if(health<0)
        {
            health = 0;
        }else if(health>1)
        {
            health = 1;
        }
        health_bar_obj.transform.localScale = new Vector3(health, 1, 1);

    }
}
