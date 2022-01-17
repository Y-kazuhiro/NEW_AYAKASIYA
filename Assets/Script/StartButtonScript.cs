using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        //SceneManager.LoadScene("Nakano2");
        FadeManager.Instance.LoadScene("Nakano2", 2.0f);
    }

}