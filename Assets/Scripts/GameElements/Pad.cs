using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour {

    private float width;
    private PadPosition padPosition;
	void Start () {
        width = GetComponent<SpriteRenderer>().bounds.extents.x*2f;
	}

    public PadPosition GetPadPosition()
    {
        return padPosition;
    }

    public void Init(PadPosition pos)
    {
        padPosition = pos;
        Vector2 position = Vector2.zero;
        switch (pos)
        {
            case PadPosition.Top:
                position = new Vector2(0, GameManager.TopRight.y);
                transform.name = Constants.topPadGameObectName;
                break;
            case PadPosition.Bottom:
                position = new Vector2(0, GameManager.BottomLeft.y);
                transform.name = Constants.bottomPadGameObjectName;
                break;
        }
        transform.position = position;
    }

	public void MoveWithSettedUnitValue (float value) {

        transform.position += value * Vector3.right;

        if (transform.position.x < GameManager.BottomLeft.x + width / 2)
        {
            transform.position = (GameManager.BottomLeft.x + width / 2) * Vector3.right;
        }

        if (transform.position.x > GameManager.TopRight.x - width / 2)
        {
            transform.position = (GameManager.TopRight.x + width / 2) * Vector3.right;
        }


    }
}
