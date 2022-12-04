using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Text_Slider : MonoBehaviour
{
    public TextMeshProUGUI numberText;

    public void SetNumber(float value)
    { 
        numberText.text = value.ToString();
    }

    
}
