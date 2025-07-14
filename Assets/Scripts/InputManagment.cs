using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GenerationValues;


public class InputManagment : MonoBehaviour
{
    public TMP_InputField sizeInput;
    public TMP_InputField scaleInput;
    public TMP_InputField yPositionInput;
    public Toggle perlinNoiseToggle;
    public Toggle sinConToggle;

    public Button generateButton;
    public GameObject mesh;
    private GameObject currentMesh;
    
    private void Start()
    {
        sizeInput.onValueChanged.AddListener(OnChangeSize);
        scaleInput.onValueChanged.AddListener(OnChangeScale);
        yPositionInput.onValueChanged.AddListener(OnChangeYPosition);
        perlinNoiseToggle.onValueChanged.AddListener(OnChangePerlin);
        sinConToggle.onValueChanged.AddListener(OnChangeSinCon);
        
        generateButton.onClick.AddListener(OnGenerateTerrain);
    }

    public void OnGenerateTerrain()
    {
        if (currentMesh != null)
        {
            Destroy(currentMesh);
            currentMesh = Instantiate(mesh);
        }
        else
        {
            currentMesh = Instantiate(mesh);
        }
    }

    public void OnChangeSize(string value)
    {
        size = int.Parse(value);
        Debug.Log("Size: " + size);
    }
    public void OnChangeScale(string value) { scale = float.Parse(value); }
    public void OnChangeYPosition(string value) { yPosition = int.Parse(value); }
    public void OnChangePerlin(bool toggle) { perlinNoise = toggle; }
    public void OnChangeSinCon(bool toggle) { sincon = toggle; }
}
