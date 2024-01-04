using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnState : MonoBehaviour
{
    [SerializeField] float Hp = 100;
    public health_bar health_bar_func;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Damage(float dmg)
    {
        Hp -= dmg;

        health_bar_func.set_health(Hp / 100f);

        if (Hp <= 0)
        {
            //animator.SetInteger("State", 3);
            return true;
        }
        return false;
    }
}
