using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideElementsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ElementsToHide;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in ElementsToHide)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
