using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{


   public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(2);
    }
}
