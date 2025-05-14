using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameoverPanel : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI winstatetext;
    public TextMeshProUGUI totalscoretext;
    public Button continueButton;

    public void setWinState(winState state, BigInteger score)
    {
        panel.SetActive(true);

        totalscoretext.text = score.ToString();

        if (state.Equals(winState.win))
        {
            panel.GetComponent<Animator>().SetTrigger("Win");

            winstatetext.text = "You Are Winner";
            continueButton.interactable = true;
        }
        else
        {
            panel.GetComponent<Animator>().SetTrigger("Lose");

            winstatetext.text = "Why'd You Lose?";
            continueButton.interactable = false;
        }
    }

    public void clickContinue()
    {
        panel.GetComponent<Animator>().SetTrigger("Win");

        panel.SetActive(false);

    }
}
