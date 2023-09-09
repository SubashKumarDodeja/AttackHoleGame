using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void UpgradeTime()
    {
        GameManager.UpgradeTime();
    }
    public void UpgradeSize()
    {
        GameManager.UpgradeSize();
    }
    public void Close()
    {
        GameManager.Play();
        this.gameObject.SetActive(false);
    }
}
