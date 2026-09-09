using UnityEngine;
using UnityEngine.UI;

public class Reel : MonoBehaviour
{
    [Header("Reel Setup")]
    public RectTransform[] symbols;
    public Image[] symbolImages;

    [Header("Symbol Settings")]
    public Sprite[] allSymbolSprites;
    public float scrollSpeed = 1500f;
    public float symbolHeight = 150f;

    [Header("Result")]
    public int resultSlotIndex = 1;

    public Sprite landedSprite { get; private set; }

    private bool isSpinning = false;

    void Start()
    {
        ResetPositions();
    }

    public void StartSpin()
    {
        isSpinning = true;
    }

    void Update()
    {
        if (!isSpinning)
            return;

        foreach (RectTransform symbol in symbols)
        {
            symbol.anchoredPosition +=
                Vector2.down * scrollSpeed * Time.deltaTime;

            if (symbol.anchoredPosition.y < -symbolHeight * symbols.Length)
            {
                symbol.anchoredPosition +=
                    Vector2.up * (symbolHeight * symbols.Length);
            }
        }
    }

    public void StopSpin(int landedSymbolIndex)
    {
        isSpinning = false;

        // The actual game result.
        landedSprite = allSymbolSprites[landedSymbolIndex];

        // Put every symbol back into its normal position.
        ResetPositions();

        // Give every visual slot a random symbol.
        for (int i = 0; i < symbolImages.Length; i++)
        {
            symbolImages[i].sprite =
                allSymbolSprites[
                    Random.Range(0, allSymbolSprites.Length)
                ];
        }

        // IMPORTANT:
        // Put the actual result into the slot that is
        // visually considered the center/result position.
        symbolImages[resultSlotIndex].sprite = landedSprite;
    }

    private void ResetPositions()
    {
        for (int i = 0; i < symbols.Length; i++)
        {
            symbols[i].anchoredPosition =
                new Vector2(0, -i * symbolHeight);
        }
    }
}