using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButtonLogic : MonoBehaviour
{
    [Header("Rewards for finishing")]
    [SerializeField] FinishRewards FinishRewards;
    [SerializeField] StarAnimation StarAnimation;
    [SerializeField] CoinBarLogic CoinBarLogic;
    [SerializeField] UserProfile UserProfile;

    [Header("Check survey answers")]
    [SerializeField] SurveyChecker SurveyChecker;

    [Header("End of survey animators")]
    [SerializeField] Animator BackAnimator;
    [SerializeField] Animator FinishAnimator;
    [SerializeField] Animator EndAnimator;

    [Header("End of survey objects")]
    [SerializeField] GameObject FocusBackpanel;
    [SerializeField] GameObject FinishPanel;
    [SerializeField] GameObject EndPanel;
    [SerializeField] GameObject FinishBack;

    bool animPlayed;

    public void ShowFinishScreen(bool show) { StartCoroutine(IShowFinishScreen(show)); }

    public void FinishSurvey() { StartCoroutine(IFinishSurvey()); }

    IEnumerator IShowFinishScreen(bool show)
    {
        if (!SurveyChecker.CheckAnswers())
        {
            yield break;
        }

        if (show)
        {
            FocusBackpanel.SetActive(true);
            FinishPanel.SetActive(true);

            BackAnimator.SetTrigger("Close");
            FinishAnimator.SetTrigger("Show");

            yield return new WaitForSeconds(1f);
            FinishBack.SetActive(true);

            if (animPlayed) yield break;

            CoinBarLogic.SetProgressBar(UserProfile.ReturnPrizePercent());
            animPlayed = true;
            //StarAnimation.StartAnimation();
        }
        else
        {
            FinishBack.SetActive(false);
            BackAnimator.SetTrigger("Open");
            FinishAnimator.SetTrigger("Hide");
            yield return new WaitForSeconds(1f);

            FocusBackpanel.SetActive(false);
            FinishPanel.SetActive(false);
        }
    }

    IEnumerator IFinishSurvey()
    {
        EndPanel.SetActive(true);
        FinishBack.SetActive(false);
        FinishAnimator.SetTrigger("Hide");
        EndAnimator.SetTrigger("Show");
        yield return new WaitForSeconds(1f);

        FinishPanel.SetActive(false);

        //FinishRewards.GiveExperience(true, true);
    }
}
