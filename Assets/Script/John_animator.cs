using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John_animator : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)) {
        
            animator.SetInteger("isFight",1);
        }
        else {
            animator.SetInteger("isFight",0);
        }
    }
}
