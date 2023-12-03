using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    [SerializeField] GameObject shortcutPanel;
    [SerializeField] GameObject fittingRoomPanel;

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!fittingRoomPanel.activeSelf)
                fittingRoomPanel.SetActive(true);
        }
    }

    public void ToggleShortcutPanel(bool show)
    {
        shortcutPanel.SetActive(show);
    }
}
