using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Ball BallPrefab;
    public Pad PadPrefab;

    [SerializeField] private Transform gameElementsParent;
    [SerializeField] private PadController padController;

    public static Vector2 BottomLeft;
    public static Vector2 TopRight;

	void Start () {

        BottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        TopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
 
        Pad topPad = Instantiate(PadPrefab) as Pad;
        Pad bottomPad = Instantiate(PadPrefab) as Pad;

        topPad.transform.SetParent(gameElementsParent);
        bottomPad.transform.SetParent(gameElementsParent);

        topPad.Init(PadPosition.Top);
        bottomPad.Init(PadPosition.Bottom);

        List<Pad> padList = new List<Pad>{topPad,bottomPad};
        padController.Init(padList);

        Ball ball = Instantiate(BallPrefab, gameElementsParent) as Ball;
        ball.transform.SetParent(gameElementsParent);

        //ball.Init();
    }
}

public enum PadPosition
{
    Top,
    Bottom
}
