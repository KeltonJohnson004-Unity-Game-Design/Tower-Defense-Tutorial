using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public Text liveText;
    void Update()
    {
        liveText.text = PlayerStats.Lives + " Lives";
    }
}
