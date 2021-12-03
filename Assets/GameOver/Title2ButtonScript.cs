using UnityEngine;
using UnityEngine.SceneManagement;

public class Title2ButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Title");
    }

}