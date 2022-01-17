using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Title");
        //FadeManager.Instance.LoadScene("Title", 1.0f);
    }

}