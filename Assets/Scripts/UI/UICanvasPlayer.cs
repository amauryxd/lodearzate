using UnityEngine;

public class UICanvasPlayer : MonoBehaviour
{
    public Canvas inventoryCanvas;
    private bool changeState = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryCanvas.enabled = changeState;
            changeState = !changeState;
        }
    }
}
