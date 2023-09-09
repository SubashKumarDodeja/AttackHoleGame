using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    float health;
    [SerializeField]
    Animator anim;
    [SerializeField]
    internal Transform bulletPoint;
    [SerializeField]
    float attackAfter;
    Coroutine c;
    bool hit;
    // Start is called before the first frame update
    void Start()
    {
        c=StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackAfter);
        anim.SetTrigger("Attack");
        hit = true;
        yield return new WaitForSeconds(2);
        GameManager.LevelFail();
    }
    public void Damage(float bulletDamage)
    {
        if (hit)
            return;
        Debug.Log("damage");
        health -= bulletDamage;
        if (health <= 0)
        {
            anim.SetTrigger("Death");
            StopCoroutine(c);
            GameManager.LevelComplete();
        }
    }
}
