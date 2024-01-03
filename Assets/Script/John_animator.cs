using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class John_animator : MonoBehaviour
{
    Animator animator;
    float attackRange = 1000f;
    public LayerMask EnemyLayer;
    GameObject Geometry;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Geometry = GameObject.Find("Geometry");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)) {
            // perform animation
            animator.SetInteger("isFight",1);
            Collider[] enemyInScope = Physics.OverlapSphere(Geometry.transform.position, attackRange, EnemyLayer);
            foreach (Collider enemy in enemyInScope) {
                enemycontrol enemyControl = enemy.GetComponent<enemycontrol>();
                enemyControl.Damage();
            }
        }
        else {
            animator.SetInteger("isFight",0);
        }
    }
}
