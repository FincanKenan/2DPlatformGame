using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI cellText;

    private int keyHold;
    private int cellHold;
    
    void Start()
    {
        UpdateKeyUI();
        UpdateCellUI();
    }

    public void addKey()
    {
        keyHold++;
        UpdateKeyUI();
    }
    public void addCell()
    {
        cellHold++;
        UpdateCellUI();
    }

    public void removeCell()
    {
        cellHold--;
        UpdateCellUI();
    }

    public void UpdateKeyUI()
    {
        keyText.text = "Keys: " + keyHold;
    }

    public void UpdateCellUI()
    {
        cellText.text = "Cell: " + cellHold;
    }
    
    void Update()
    {
        
    }
}
