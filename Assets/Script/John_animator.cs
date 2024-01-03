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
            Debug.Log("Geo" + Geometry.transform.position.ToString());
            Collider[] enemyInScope = Physics.OverlapSphere(Geometry.transform.position, attackRange, EnemyLayer);
            Debug.Log("We Hit : " + enemyInScope.Length.ToString());
            foreach (Collider enemy in enemyInScope) {
                Debug.Log("We Hit");
            }
        }
        else {
            animator.SetInteger("isFight",0);
        }
    }
    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(Geometry.transform.position, attackRange);
    }
}
