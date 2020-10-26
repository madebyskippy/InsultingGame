using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{

    [SerializeField] GameObject[] profiles;
    [SerializeField] GameObject tabObject;
    [SerializeField] Color disabledTabColor;

    Color activeTabColor;
    Image[] tabs;

    int currentlySelectedProfile;

    // Start is called before the first frame update
    void Start()
    {
        currentlySelectedProfile = 0;

        tabs = new Image[profiles.Length];
        tabs[0] = tabObject.GetComponent<Image>();
        activeTabColor = tabs[0].color;

        for (int i=1; i<profiles.Length; i++)
        {
            GameObject newTab = Instantiate(tabObject, tabObject.transform.parent);
            newTab.GetComponent<Image>().color = disabledTabColor;
            int index = i;
            newTab.GetComponent<Button>().onClick.AddListener(() => { clickTab(index); });
            tabs[i] = newTab.GetComponent<Image>();
        }
    }

    public void clickTab(int index)
    {
        for (int i=0; i<profiles.Length; i++)
        {
            if (i == index)
            {
                profiles[i].SetActive(true);
                tabs[i].color = activeTabColor;
            }
            else
            {
                profiles[i].SetActive(false);
                tabs[i].color = disabledTabColor;
            }
        }
    }
}
