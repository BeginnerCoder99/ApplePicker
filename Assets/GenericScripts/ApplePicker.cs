using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 1.5f;
    public List<GameObject> basketList;

    [Header("UI")]
    public TMP_Text rounds;
    public GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        updateRoundText();
    }

    public void AppleMissed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGo in appleArray)
        { Destroy(tempGo); }

        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (basketList.Count == 0)
        {
            gameOver();
        }
        else
        {
            updateRoundText();
        }
    }

    void updateRoundText()
    {
        int currentRound = numBaskets - basketList.Count + 1;
        rounds.text = "Round " + currentRound;
    }

    public void gameOver()
    {
        rounds.text = "Game Over";
        restartButton.SetActive(true);
        Time.timeScale = 0f;
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("_Scene_0");
    }
}
