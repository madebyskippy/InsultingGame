using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaggedObject : MonoBehaviour
{

    [SerializeField] Tags[] allTags;

    public void setTags(Tags[] t)
    {
        allTags = t;
    }

    public bool hasTag(Tags t)
    {
        for (int i=0; i<allTags.Length; i++)
        {
            if (t == allTags[i])
            {
                return true;
            }
        }
        return false;
    }

    public Tags[] getAllTags()
    {
        return allTags;
    }

    public bool hasTagOverlap(Tags[] tagsToCompare)
    {
        for (int i=0; i<tagsToCompare.Length; i++)
        {
            if (hasTag(tagsToCompare[i]))
            {
                return true;
            }
        }
        return false;
    }

}
