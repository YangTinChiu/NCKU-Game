using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndex = 2;

    public void OnPointerClick(PointerEventData eventData)
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneIndex);
    }
}
