using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_ : MonoBehaviour
{
    Slider slider;
    public GameObject fillArea;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        if (fillArea == null)
        {
            fillArea = gameObject.transform.GetChild(1).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= 0f)
        {
            slider.value = 0f;
            fillArea.SetActive(false);
        }
        else fillArea.SetActive(true);
    }
}
