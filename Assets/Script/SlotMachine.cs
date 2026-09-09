using UnityEngine;
using System.Collections;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    public Reel[] reels;

    public float[] stopDelays = { 1.5f, 2f, 2.5f };

    [Header("UI")]
    public GameObject winPanel;
    public GameObject lossPanel;
    public GameObject notEnoughCoinsPanel;
    public TMP_Text coinsText;

    [Header("Lever")]
    public GameObject normalLeverButton;
    public GameObject pulledLever;

    [Header("Coins")]
    public int coins = 100;
    public int spinCost = 10;
    public int winPayout = 100;

    private bool isSpinning = false;

    void Start()
    {
        UpdateCoinsUI();

        winPanel.SetActive(false);
        lossPanel.SetActive(false);
        notEnoughCoinsPanel.SetActive(false);
    }

    public void OnSpinButtonPressed()
    {
        if (isSpinning)
            return;

        if (coins < spinCost)
        {
            notEnoughCoinsPanel.SetActive(true);
            return;
        }

        coins -= spinCost;

        UpdateCoinsUI();

        winPanel.SetActive(false);
        lossPanel.SetActive(false);
        notEnoughCoinsPanel.SetActive(false);

        StartCoroutine(SpinRoutine());
    }

    public void OnLeverPressed()
    {
        if (isSpinning)
            return;

        StartCoroutine(LeverRoutine());
    }

    IEnumerator LeverRoutine()
    {
        normalLeverButton.SetActive(false);
        pulledLever.SetActive(true);

        // Start spinning immediately
        OnSpinButtonPressed();

        yield return new WaitForSeconds(1f);

        pulledLever.SetActive(false);
        normalLeverButton.SetActive(true);
    }

    IEnumerator SpinRoutine()
    {
        isSpinning = true;

        foreach (var reel in reels)
            reel.StartSpin();

        for (int i = 0; i < reels.Length; i++)
        {
            yield return new WaitForSeconds(stopDelays[i]);

            int randomSymbol = Random.Range(0, 4);

            reels[i].StopSpin(randomSymbol);
        }

        isSpinning = false;
        // Give player time to see the final result
       
        CheckWin();
    }

    void CheckWin()
    {
        Sprite first = reels[0].landedSprite;
        Sprite second = reels[1].landedSprite;
        Sprite third = reels[2].landedSprite;

        if (first == second && second == third)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    void Win()
    {
        coins += winPayout;

        UpdateCoinsUI();

        winPanel.SetActive(true);

        Debug.Log("WIN! +100 coins");
        Debug.Log("Coins: " + coins);
    }

    void Lose()
    {
        lossPanel.SetActive(true);

        Debug.Log("LOSS!");
        Debug.Log("Coins: " + coins);
    }

    void UpdateCoinsUI()
    {
        coinsText.text = "COINS: " + coins;
    }
}