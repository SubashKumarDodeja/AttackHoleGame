using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScene : MonoBehaviour
{
    [SerializeField]
    Transform startPos;
    public List<Bullet> bullets = new List<Bullet>();
    [SerializeField]
    Boss boss;

    List<Bullet> generatedBullet = new List<Bullet>();

    void Start()
    {
        foreach (var item in bullets)
        {
           Bullet g= Instantiate(item, startPos);
            g.transform.localPosition = Vector3.zero;
            g.transform.localRotation = Quaternion.identity;
            g.transform.localPosition = new Vector3(Random.Range(-0.22f, 0.95f), 0, Random.Range(-0.4f, 0.5f));
            g.target = boss;
            g.gameObject.SetActive(false);
            generatedBullet.Add(g);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        int count = 0;
        for (int i=0;i<generatedBullet.Count;i++)
        {
            if (count > 10)
                return;
            generatedBullet[0].gameObject.SetActive(true);
            generatedBullet[0].GoToTarget();
            generatedBullet.RemoveAt(0);
            count++;
        }
    }
}
