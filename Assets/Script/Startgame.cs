using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndex = 1;

    public void OnPointerClick(PointerEventData eventData)
    {
        Scene scene = SceneManager.GetActiveScene();
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneIndex);
    }
}
