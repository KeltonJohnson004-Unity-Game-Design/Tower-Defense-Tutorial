using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundsSurvived : MonoBehaviour
{

    public Text roundsText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        
        
        int round = 0;
        roundsText.text = round.ToString();

        yield return new WaitForSeconds(.7f);

        while(round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f);

        }

    }

}
