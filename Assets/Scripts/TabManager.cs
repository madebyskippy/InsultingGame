using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{

    [SerializeField] GameObject[] contents;
    [SerializeField] GameObject tabObject = null;
    [SerializeField] Color disabledTabColor = Color.white;

    Color activeTabColor;
    Image[] tabs;

    int currentlySelectedTab;

    // Start is called before the first frame update
    void Start()
    {
        currentlySelectedTab = 0;

        tabs = new Image[contents.Length];
        tabs[0] = tabObject.GetComponent<Image>();
        activeTabColor = tabs[0].color;

        for (int i=1; i<contents.Length; i++)
        {
            GameObject newTab = Instantiate(tabObject, tabObject.transform.parent);
            newTab.GetComponent<Image>().color = disabledTabColor;
            int index = i;
            newTab.GetComponent<Button>().onClick.AddListener(() => { clickTab(index); });
            tabs[i] = newTab.GetComponent<Image>();
        }
    }

    public int getCurrentlySelectedTab()
    {
        return currentlySelectedTab;
    }
    public GameObject getCurrentlySelectedContent()
    {
        return contents[currentlySelectedTab];
    }

    public void clickTab(int index)
    {
        currentlySelectedTab = index;
        for (int i=0; i<contents.Length; i++)
        {
            if (i == index)
            {
                contents[i].SetActive(true);
                tabs[i].color = activeTabColor;
            }
            else
            {
                contents[i].SetActive(false);
                tabs[i].color = disabledTabColor;
            }
        }
    }
}
