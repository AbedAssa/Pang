using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderRatio : MonoBehaviour
{
    [SerializeField]
    private GameObject topBorder;
    [SerializeField]
    private GameObject downBorder;
    [SerializeField]
    private GameObject leftBorder;
    [SerializeField]
    private GameObject rightBorder;

    //Call function for each border.
    void Update()
    {
        RepositionBorderToFitScreenEdges(topBorder,Screen.height,0.25f,false);
        RepositionBorderToFitScreenEdges(downBorder, 0f,0.25f,false);
        RepositionBorderToFitScreenEdges(leftBorder, 0f, -0.25f,true);
        RepositionBorderToFitScreenEdges(rightBorder, Screen.width, 0.35f,true);

        ScaleBorderToFitScreenEdges(topBorder, false);
        ScaleBorderToFitScreenEdges(downBorder, false);
        ScaleBorderToFitScreenEdges(leftBorder, true);
        ScaleBorderToFitScreenEdges(rightBorder, true);
    }

    /*
    Reposition the border so they fit the screen edges.
    parameters:
        wall: the GameObject to change.
        pointOnScreen: the position on screen it should be (By pixel).
        offset: add to the position of the border.
        isVertical:to check if it is vertical or horizontal
    */
    private void RepositionBorderToFitScreenEdges(GameObject border, float pointOnScreen, float offset,bool isVertical)
    {
        Vector2 positionFromScreenToWorld;
        if (isVertical)
        {
            positionFromScreenToWorld = Camera.main.ScreenToWorldPoint(new Vector2(pointOnScreen, Screen.height / 2));
            border.transform.position = new Vector3(positionFromScreenToWorld.x + offset, positionFromScreenToWorld.y, 1f);
        }
        else
        {
            positionFromScreenToWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2f, pointOnScreen));
            border.transform.position = new Vector3(positionFromScreenToWorld.x, positionFromScreenToWorld.y + offset, 1f);
        }
    }

    /*Rescale the border so it fits the edge of the screen
    paraneters:
        border: the GameObject to change.
        isVertical: to check what direction to scale.
     */
    private void ScaleBorderToFitScreenEdges(GameObject border, bool isVertical)
    {
        Vector2 scaleOnWorldSpace = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        border.transform.localScale = isVertical ? new Vector3(1f, scaleOnWorldSpace.y * 3.2f, 1): new Vector3(scaleOnWorldSpace.x * 3.2f, 1f, 1);
    }

}