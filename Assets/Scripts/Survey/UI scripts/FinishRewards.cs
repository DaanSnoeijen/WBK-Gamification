using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishRewards : MonoBehaviour
{
    [Header("Visual elements")]
    [SerializeField] Image ExperienceCircle;

    float oldValue;
    float stepValue;
    float fractionValue = 20f;

    int loopRate = 80;

    float regularReward = 0.4f; //Regular experience for completing the survey
    float earlyBirdBonus = 0.4f; //Bonus for being early
    float oneTryBonus = 0.3f; //Bonus for completing survey in 1 go

    public void GiveExperience(bool oneTry, bool earlyBird) { StartCoroutine(IGiveExperience(oneTry, earlyBird)); }

    private void NewLevelReward()
    {

    }

    IEnumerator IGiveExperience(bool oneTry, bool earlyBird)
    {
        float addValue = regularReward;

        while (true)
        {
            float newValue = ExperienceCircle.fillAmount + addValue;

            for (int i = 0; i < loopRate; i++)
            {
                oldValue = ExperienceCircle.fillAmount;

                stepValue = (newValue - oldValue) / fractionValue;
                ExperienceCircle.fillAmount += stepValue;

                if (ExperienceCircle.fillAmount >= 1f)
                {
                    NewLevelReward();
                    ExperienceCircle.fillAmount = 0f;

                    newValue -= 1f;
                }

                yield return new WaitForSeconds(1f / loopRate);
            }

            ExperienceCircle.fillAmount = newValue;

            if (!oneTry && !earlyBird) yield break;
            else if (earlyBird)
            {
                addValue = earlyBirdBonus;
                earlyBird = false;
            }
            else if (oneTry)
            {
                addValue = oneTryBonus;
                oneTry = false;
            }
        }
    }
}
