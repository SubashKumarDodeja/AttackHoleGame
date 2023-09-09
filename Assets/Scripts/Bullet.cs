using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public Boss target;
    bool move = false;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Vector3 targetPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.bulletPoint.position, step);

            
            if (Vector3.Distance(transform.position, target.bulletPoint.position) < 1f)
            {
                target.Damage(damage);
                this.gameObject.SetActive(false);
            }
        }
    }
    public void GoToTarget()
    {
        move = true;
    }
}
