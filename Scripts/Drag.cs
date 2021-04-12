using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 pos;

    private SpriteRenderer renderer;
    //private List<Sprite> sprites = new List<Sprite>();
    private int spriteCount = 0;
    private int spriteCountR = 0;
    private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Manage").GetComponent<GameManager>();

        pos = gameObject.transform.position;
        renderer = gameObject.GetComponent<SpriteRenderer>();

        /*foreach(Sprite sprite in Resources.LoadAll<Sprite>("Sprite/CardTest"))
        {
            sprites.Add(sprite);
        }*/
        spriteCountR = GM.sprites.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        spriteCount += 1;
        Debug.Log(GM.sprites.Count);
        if (spriteCount > spriteCountR)
            spriteCount = 0;
        renderer.sprite = GM.sprites[spriteCount];
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    void OnMouseUp()
    {
        if (gameObject.transform.position.y > -2)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.position = pos;
        }
    }
}
