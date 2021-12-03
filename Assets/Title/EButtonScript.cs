using UnityEngine;
using UnityEngine.SceneManagement;

public class EButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Explanation");
    }

}