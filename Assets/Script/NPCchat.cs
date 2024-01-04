using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCchat : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject panel;
    [SerializeField] Text chatboxox;
    [SerializeField] Button button;

    bool ischating = false;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("NPC"))
        {      
            if (!ischating)
            {
                canvas.SetActive(true);
                button.gameObject.SetActive(true);
                
                if(Input.GetKeyDown(KeyCode.F))
                {
                    ischating = true;
                    button.gameObject.SetActive(false);
                    panel.SetActive(true);
                }    
            }  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("NPC"))
        {
            ischating = false;
            panel.SetActive(false);
            canvas.SetActive(false);
        }
    }
}
