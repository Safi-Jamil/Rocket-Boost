using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag) 
        {
            case "Friendly":
                Debug.Log("Everything is looking good!");
                break;
            case "Finish":
                LoadNextLevel();
                break;
            default:
                ReloadLevel();
                break;
        }
    }
     void LoadNextLevel(){
        int currentscene =SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentscene+1;
        if (nextScene == SceneManager.sceneCountInBuildSettings){
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
    void ReloadLevel(){
        int currentscene =SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
    }
}
