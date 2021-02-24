using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectSelectorForSeason : MonoBehaviour
{
    [SerializeField]
    private GameObject springObj;

    [SerializeField]
    private GameObject summerObj;

    [SerializeField]
    private GameObject fallObj;

    [SerializeField]
    private GameObject winterObj;

    private List<GameObject> objects;
    private int currentIndex = 0;
    
    private void Awake()
    {
        if (!SeasonManager.Instance) Destroy(this);
        objects = new List<GameObject>();
        objects.Add(springObj);
        objects.Add(summerObj);
        objects.Add(fallObj);
        objects.Add(winterObj);

        AllHide();
        switch (SeasonManager.Instance.CURRENT_SEASON)
        {
            case SeasonManager.Season.SPRING:
                currentIndex = 0;
                break;
            case SeasonManager.Season.SUMMER:
                currentIndex = 1;
                break;
            case SeasonManager.Season.FALL:
                currentIndex = 2;
                break;
            case SeasonManager.Season.WINTER:
                currentIndex = 3;
                break;
        }
        ActivateObject(currentIndex);
    }

    private void ActivateObject(int index)
    {
        if (index < 0 || index >= objects.Count) return;
        for (int i = 0;i<objects.Count;i++)
        {
            if (i==index) continue;
            if (!objects[i]) continue;
            objects[i].SetActive(false);
        }
        if (!objects[index]) return;
        objects[index].SetActive(true);
        currentIndex = index;
    }

    private void AllHide()
    {
        foreach (GameObject obj in objects)
        {
            if (!obj) continue;
            obj.SetActive(false);
        }
        
    }
}
