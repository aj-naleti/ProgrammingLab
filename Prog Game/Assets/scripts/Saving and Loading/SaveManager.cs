using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public byte[] playerScore;
}

public class SaveManager : MonoBehaviour 
{
    private string saveFileName = "save.json";
    private byte[] key = new byte[] { 0x02, 0x04, 0x08, 0x04 };

    public void SaveGame(int score) 
    {
        SaveData data = new SaveData();
        data.playerScore = Encoding.UTF8.GetBytes(score.ToString());

        for (int i = 0; i < data.playerScore.Length; i++) 
        {
            data.playerScore[i] = (byte)(data.playerScore[i] ^ key[i % key.Length]);
        }

        string jsonData = JsonUtility.ToJson(data);
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);

        File.WriteAllText(filePath, jsonData);
    }

    public int LoadGame() 
    {
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);

        if (File.Exists(filePath)) 
        {
            string jsonData = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            for (int i = 0; i < data.playerScore.Length; i++) 
            {
                data.playerScore[i] = (byte)(data.playerScore[i] ^ key[i % key.Length]);
            }

            string scoreString = Encoding.UTF8.GetString(data.playerScore);
            int score = 0;
            int.TryParse(scoreString, out score);

            return score;
        } 

        else 
        {
            return 0;
        }
    }
}