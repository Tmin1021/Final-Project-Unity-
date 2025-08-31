using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutManager : MonoBehaviour
{
    [SerializeField] Canvas aboutCanvas; // assign your Menu Canvas in Inspector

    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
