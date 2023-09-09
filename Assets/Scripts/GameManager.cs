using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static int bulletCount = 0;
    [SerializeField]
    float levelTime;
    public static float LevelTime;
    [SerializeField]
    List<CollectableObject> objectsInScene= new List<CollectableObject>();
    public static List<CollectableObject> ObjectInScene = new List<CollectableObject>();

    [SerializeField]
    BossScene bossLevel;
    public static BossScene BossLevel;
    [SerializeField]
    GameObject collectLevel;
    public static GameObject CollectLevel;

    [SerializeField]
    GameObject levelComplete;
    static GameObject LevelCompletePanel;
    [SerializeField]
    GameObject levelfail;
    static GameObject LevelFailPanel;
    [SerializeField]
    Hole hole;
    public static Hole _Hole;


    // Start is called before the first frame update
    void Awake()
    {
        LevelTime = levelTime;
        ObjectInScene  = objectsInScene;
        CollectLevel = collectLevel;
        BossLevel = bossLevel;
        LevelFailPanel = levelfail;
        LevelCompletePanel = levelComplete;
        _Hole = hole;
        _Hole.SetTimmer();
        Time.timeScale = 0;
    }
    public static void UpgradeSize()
    {
        _Hole.gameObject.transform.localScale = new Vector3(_Hole.gameObject.transform.localScale.x * 1.2f, _Hole.gameObject.transform.localScale.y,
            _Hole.gameObject.transform.localScale.z * 1.2f);

    }
    public static void UpgradeTime()
    {
        LevelTime += 15;
        _Hole.SetTimmer();
    }
    public static void Play()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        CollectLevel.SetActive(true);
        BossLevel.gameObject.SetActive(false);
    }
    // Update is called once per frame
    
    public static bool CheckAllCollected()
    {
        foreach (var item in ObjectInScene)
            if (!item.done)
                return false; 
        return true;
    }
    public static void CollectObject(Bullet obj)
    {
        bulletCount++;
        BossLevel.bullets.Add(obj);
        if (CheckAllCollected())
        {
            BossScene();
        }
    }
    public static void BossScene()
    {
        Debug.Log("EnableBossScene");
        CollectLevel.SetActive(false);
        BossLevel.gameObject.SetActive(true);
    }
    public static void LevelFail()
    {
        LevelFailPanel.SetActive(true);
    }
    public static void LevelComplete()
    {
        LevelCompletePanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
