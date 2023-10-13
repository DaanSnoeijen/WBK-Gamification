using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Linq;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class FortuneWheelManager : MonoBehaviour
{
	[Header("Game Objects for some elements")]
	[SerializeField] Button TurnButton;             // This button is showed when you can turn the wheel for free
    [SerializeField] GameObject Circle; 					// Rotatable GameObject on scene with reward objects

	private bool _isStarted;                    // Flag that the wheel is spinning
	private bool _hasSpinned;

    [Header("After wheel spin")]
    [SerializeField] GameObject CircleBlock;
    [SerializeField] GameObject EndButton;

    [Header("Coin effects")]
    [SerializeField] ParticleSystem CoinsEffect;

    [Header("Update coins")]
    [SerializeField] UpdateCoins UpdateCoins;

    [Header("Params for each sector")]
    [SerializeField] FortuneWheelSector[] Sectors;		// All sectors objects

	private float _finalAngle;					// The final angle is needed to calculate the reward
	private float _startAngle;    				// The first time start angle equals 0 but the next time it equals the last final angle
	private float _currentLerpRotationTime;		// Needed for spinning animation

	private FortuneWheelSector _finalSector;

    private void TurnWheel ()
	{
		if (_hasSpinned) return;

        _currentLerpRotationTime = 0f;

        // All sectors angles
        int[] sectorsAngles = new int[Sectors.Length];

		// Fill the necessary angles (for example if we want to have 12 sectors we need to fill the angles with 30 degrees step)
		// It's recommended to use the EVEN sectors count (2, 4, 6, 8, 10, 12, etc)
		for (int i = 1; i <= Sectors.Length; i++) sectorsAngles[i - 1] = 360 / Sectors.Length * i;

        //int cumulativeProbability = Sectors.Sum(sector => sector.Probability);

        double rndNumber = UnityEngine.Random.Range (1, Sectors.Sum(sector => sector.Probability));

		// Calculate the propability of each sector with respect to other sectors
		int cumulativeProbability = 0;
		// Random final sector accordingly to probability
		int randomFinalAngle = sectorsAngles [0];
		_finalSector = Sectors[0];

		for (int i = 0; i < Sectors.Length; i++) {
			cumulativeProbability += Sectors[i].Probability;

			if (rndNumber <= cumulativeProbability) {
				// Choose final sector
				randomFinalAngle = sectorsAngles [i];
				_finalSector = Sectors[i];
				break;
			}
		}

		int fullTurnovers = 5;

		// Set up how many turnovers our wheel should make before stop
		_finalAngle = fullTurnovers * 360 + randomFinalAngle;

		// Stop the wheel
		_isStarted = true;
		_hasSpinned = true;

    }

	public void TurnWheelButtonClick() { TurnWheel(); }

	private void Update ()
	{
		if (!_isStarted)
		{
			if (!_hasSpinned)
			{
                float angle = Mathf.Lerp(Circle.transform.eulerAngles.z,
                                Circle.transform.eulerAngles.z + 5f, 0.05f);
                Circle.transform.eulerAngles = new Vector3(0, 0, angle);

                _startAngle = Circle.transform.eulerAngles.z;
            }

            return;
		}

        // Animation time
        float maxLerpRotationTime = 4f;

		// increment animation timer once per frame
		_currentLerpRotationTime += Time.deltaTime;

		// If the end of animation
		if (_currentLerpRotationTime > maxLerpRotationTime || Circle.transform.eulerAngles.z == _finalAngle) {
			_currentLerpRotationTime = maxLerpRotationTime;
			_isStarted = false;
			_startAngle = _finalAngle % 360;

			//GiveAwardByAngle ();
			_finalSector.RewardCallback.Invoke();

            CircleBlock.SetActive(true);
            EndButton.SetActive(true);
        } else {
			// Calculate current position using linear interpolation
			float t = _currentLerpRotationTime / maxLerpRotationTime;

			// This formulae allows to speed up at start and speed down at the end of rotation.
			// Try to change this values to customize the speed
			t = t * t * t * (t * (6f * t - 15f) + 10f);

			float angle = Mathf.Lerp (_startAngle, _finalAngle, t);
			Circle.transform.eulerAngles = new Vector3 (0, 0, angle);	
		}
	}

	/// <summary>
	/// Sample callback for giving reward (in editor each sector have Reward Callback field pointed to this method)
	/// </summary>
	/// <param name="awardCoins">Coins for user</param>
	private void RewardCoins (int awardCoins)
	{
        var em = CoinsEffect.emission;
        em.rateOverTime = awardCoins;
        CoinsEffect.Play();

        UpdateCoins.ShowNewCoins(awardCoins);
    }
}

/**
 * One sector on the wheel
 */
[Serializable]
public class FortuneWheelSector : System.Object
{
	[Tooltip("Value of reward")]
	public int RewardValue = 100;

	[Tooltip("Chance that this sector will be randomly selected")]
	[RangeAttribute(0, 100)]
	public int Probability = 100;

	[Tooltip("Method that will be invoked if this sector will be randomly selected")]
	public UnityEvent RewardCallback;
}