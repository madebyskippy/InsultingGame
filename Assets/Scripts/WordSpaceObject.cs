using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WordType { noun, adjective, verb};

public class WordSpaceObject : MonoBehaviour
{
    [SerializeField] WordType type = WordType.noun;

    public WordType getType()
    {
        return type;
    }
}
