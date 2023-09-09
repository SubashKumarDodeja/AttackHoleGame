using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField]
    float Damage;
    [SerializeField]
    float force;
    [SerializeField]
    ForceMode forceMode;
    internal bool done=false;
    [SerializeField]
    Bullet bullet;
    public void EnableCorotine()
    {
        done = true;
        StartCoroutine(DisableItem());
    }
    IEnumerator DisableItem()
    {
        this.gameObject.AddComponent<Rigidbody>().AddForce(-Vector3.up*force,forceMode);
        GameManager.CollectObject(bullet);
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
}
