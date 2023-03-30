using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    private int score = 0;
    private SaveManager saveManager;

    void Start() 
    {
        saveManager = FindObjectOfType<SaveManager>();
        score = saveManager.LoadGame();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Y)) 
        {
            score++;
            print("Score increased!");
        }

        if (Input.GetKeyDown(KeyCode.X)) 
        {
            saveManager.SaveGame(score);
            print("Saved!");
        }

        if (Input.GetKeyDown(KeyCode.C)) 
        {
            score = saveManager.LoadGame();
            print($"Saved score is: {score}");
        }
    }
}