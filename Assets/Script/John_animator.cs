using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class John_animator : MonoBehaviour
{
    Animator animator;
    [SerializeField]float attackRange = 10f;
    [SerializeField]float atk = 10;

    public LayerMask EnemyLayer;
    GameObject Geometry;

    float damageDelay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Geometry = GameObject.Find("Geometry");
    }

    // Update is called once per frame
    void Update()
    {
        damageDelay += Time.deltaTime;
        if(Input.GetMouseButton(0) && damageDelay > 1.0f) {
            damageDelay = 0.0f;
            // perform animation
            animator.SetInteger("isFight",1);
            Collider[] enemyInScope = Physics.OverlapSphere(Geometry.transform.position, attackRange, EnemyLayer);
            foreach (Collider enemy in enemyInScope) {
                enemycontrol enemyControl = enemy.GetComponent<enemycontrol>();
                enemyControl.Damage(atk);
            }
        }
        else {
            animator.SetInteger("isFight",0);
        }
    }
}
