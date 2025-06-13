using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFase : MonoBehaviour
{
    public string nextSceneName; 

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
