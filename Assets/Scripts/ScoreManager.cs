using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TabManager profileTabs = null;
    [SerializeField] TabManager letterTabs = null;

    [Space(20)]
    [SerializeField] TextMeshProUGUI scoreLabel = null;

    LetterObject currentLetter;
    TaggedObject currentProfile;

    int score;

    public void generateScore()
    {
        Debug.Log("scoring!");
        score = 0;
        currentProfile = profileTabs.getCurrentlySelectedContent().GetComponent<TaggedObject>();
        currentLetter = letterTabs.getCurrentlySelectedContent().GetComponent<LetterObject>();

        TaggedObject[] wordsUsed = currentLetter.getFilledWords();

        Tags[] profileTags = currentProfile.getAllTags();

        for (int i=0; i<wordsUsed.Length; i++)
        {
            score += 1;
            if (wordsUsed[i].hasTagOverlap(profileTags)){
                score += 1;
            }
        }

        scoreLabel.text = score.ToString();
    }
}
