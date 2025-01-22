using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public GameObject UnderstandingChoices;

    void OnTriggerEnter()
    {
        UnderstandingChoices.SetActive(true);
    }
}
