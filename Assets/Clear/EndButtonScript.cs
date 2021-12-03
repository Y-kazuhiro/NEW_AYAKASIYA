using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Title");
    }

}