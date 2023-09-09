using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    [SerializeField]
    float xInput = 0, yInput = 0;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Collider myCollider;
    [SerializeField]
    Text timerText;

    static float timer;
    // Start is called before the first frame update
    int minutes;
    int seconds;
    string tempTimer;
    
    public void SetTimmer()
    {
        timer = GameManager.LevelTime;
        TimerTextSet();
    }
    void TimerTextSet()
    {
        timer -= Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        tempTimer = String.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = tempTimer;
    }
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        #region Timer
        timer -= Time.deltaTime;
        TimerTextSet();
        if (timer < 0)
            GameManager.BossScene();
        #endregion

    }
    void FixedUpdate()
     {
        Vector3 movement = new Vector3(yInput, 0.0f, -xInput);

        rb.velocity = movement * moveSpeed;
    }

    private bool IsCapsuleInsideCapsule(Collider objectObj)
    {
        if (myCollider.bounds.Contains(objectObj.bounds.max) && myCollider.bounds.Contains(objectObj.bounds.min))
            return true;
        return false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pick"))
        {
            if (IsCapsuleInsideCapsule(other))
            {
                Debug.Log("Inside");
                CollectableObject c=other.GetComponent<CollectableObject>();
                if (!c.done)
                {
                    c.EnableCorotine();
                }
            }
            else
            {
                Debug.Log("OutSide");
            }
        }
    }
    
    
}
