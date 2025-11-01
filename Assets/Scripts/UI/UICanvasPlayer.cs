using UnityEngine;

public class UICanvasPlayer : MonoBehaviour
{
    public Canvas inventoryCanvas;
    private bool changeState = true;
    public GameObject UIPrefab;
    public GameObject ContentRef;
    public PlayerInventory plyRef;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryCanvas.enabled = changeState;
            changeState = !changeState;
            //cambiar el estado del mouse
        }

    }
    
}
