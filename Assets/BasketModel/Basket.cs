using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public ApplePicker applePicker;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        applePicker = Camera.main.GetComponent <ApplePicker>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2d = Input.mousePosition;

        mousePos2d.z = -Camera.main.transform.position.z;

        Vector3 MousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);

        Vector3 pos = this.transform.position;
        pos.x = MousePos3d.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
        if (collidedWith.CompareTag("Stick"))
        {
            Destroy(collidedWith);
            applePicker.gameOver();

        }
    }
}
