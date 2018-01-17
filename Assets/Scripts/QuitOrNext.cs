using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitOrNext : MonoBehaviour
{
	public string NameScene = "Level2";
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Aku disini");
        SceneManager.LoadScene(NameScene);
    }

}