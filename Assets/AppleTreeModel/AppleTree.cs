using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Inscribed")]

    public GameObject applePrefab; //prefab for apples
    public GameObject stickPrefab;
    public float speed = 2.5f; //speed that tree moves
    public float leftAndRightEdge = 10f; // distance where tree changes dir
    public float changeDirChance = 0.02f; // chance that tree changes dir
    public float appleDropDelay = 1f; //Seconds between apple spawns
    public float stickDropDelay = 3.3f;

    void Start()
    {
        Invoke("DropApple", 2f);
        Invoke("DropStick", 3f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    void DropStick()
    {
        GameObject stick = Instantiate<GameObject>(stickPrefab);
        stick.transform.position = transform.position + Vector3.down * 1f;
        Invoke("DropStick", stickDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        { speed = Mathf.Abs(speed); }
        else if (pos.x > leftAndRightEdge)
        { speed = -Mathf.Abs(speed); }

    }
    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
            { speed *= -1; }

    }
}
