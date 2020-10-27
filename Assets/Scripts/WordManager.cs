using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class WordObject{
    public string word;
    public WordType type;
    public Tags[] tags;
}

public class WordManager : MonoBehaviour
{
    [SerializeField] GameObject dragHolder = null;
    [SerializeField] GameObject listHolder = null;

    [Space(20)]
    [SerializeField] Color[] typeColor = null;

    [Space(20)]
    [SerializeField] GameObject wordPrefab = null;
    [SerializeField] WordObject[] words = null;

    GameObject originalParent = null;
    GameObject currentlyHolding = null;
    Vector3 dragOffset = Vector3.zero;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    private void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();

        for (int i=0; i<words.Length; i++)
        {
            GameObject newWord = Instantiate(wordPrefab, listHolder.transform);
            newWord.GetComponent<TextMeshProUGUI>().text = words[i].word;
            newWord.name = words[i].word;
            newWord.GetComponent<TextMeshProUGUI>().color = typeColor[(int)words[i].type];
            newWord.GetComponent<TaggedObject>().setTags(words[i].tags);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pickup(mouseAction());
        }
        if (Input.GetMouseButtonUp(0))
        {
            putdown(mouseAction());
        }

        if (currentlyHolding != null)
        {
            currentlyHolding.transform.position = Input.mousePosition+dragOffset;
        }
    }

    List<RaycastResult> mouseAction()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);
        return results;
    }

    void pickup(List<RaycastResult> results)
    {
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.tag == "noun" ||
                result.gameObject.tag == "adjective" ||
                result.gameObject.tag == "verb")
            {
                Debug.Log(Time.time+" clicked word");
                currentlyHolding = result.gameObject;
                originalParent = result.gameObject.transform.parent.gameObject;
                currentlyHolding.transform.SetParent(dragHolder.transform);
                dragOffset = currentlyHolding.transform.position - Input.mousePosition;
                break;
            }
        }
    }

    void putdown(List<RaycastResult> results)
    {
        if (currentlyHolding != null)
        {
            Transform parentToReturnTo = originalParent.transform;
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.tag == "blank")
                {
                    parentToReturnTo = result.gameObject.transform;
                    break;
                }
                if (result.gameObject.tag == "list")
                {
                    parentToReturnTo = listHolder.transform;
                    break;
                }
            }
            currentlyHolding.transform.SetParent(parentToReturnTo);
            currentlyHolding.transform.localPosition = Vector3.zero;
            currentlyHolding = null;
            originalParent = null;
        }
    }
}
