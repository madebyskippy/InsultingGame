using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterObject : MonoBehaviour
{

    [SerializeField] WordSpaceObject[] spaces = null;

    public TaggedObject[] getFilledWords()
    {
        TaggedObject[] allWords = new TaggedObject[spaces.Length];
        for (int i=0; i<spaces.Length; i++)
        {
            allWords[i] = spaces[i].transform.GetChild(1).GetComponent<TaggedObject>();
        }
        return allWords;
    }
}
