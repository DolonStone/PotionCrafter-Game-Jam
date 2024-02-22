using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAttackAnimation : MonoBehaviour
{
    public Animator attackanimation;
    public bool attackdelay = false;
    public float attackdelaytime = 0.1f;
    const string pressanim = "Attack";

    // Start is called before the first frame update
    void Start()
    {

   
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (attackdelay)
            {
                return;
            }
            print("hello");
            attackanimation.SetTrigger(pressanim);
            //attackdelay = true;
            //StartCoroutine(DelayAttack());
        }
    }

    public void attack()
    {
        if (attackdelay)
        {
            return;
        }
        attackanimation.SetTrigger("Attack");
        attackdelay = true;
        StartCoroutine(DelayAttack());
    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackdelaytime);
        attackdelay = true;
    }
}
