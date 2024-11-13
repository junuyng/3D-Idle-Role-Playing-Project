using System.IO;
using UnityEngine;

public  class DataManager
{
    public static void SaveData<T>(T saveData)
    {
        string directoryPath = Path.Combine(Application.dataPath, "@Data");
        string filePath = Path.Combine(directoryPath, $"{typeof(T).Name}.txt");

         if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        
        
        string json = JsonUtility.ToJson(saveData, true);

        Debug.Log(filePath + "저장");
        File.WriteAllText(filePath, json);
    }

    public static T LoadData<T>() where T : class // null 반환은 참조 타입의 경우에만 가능 하므로 where를 통해 조건 걸어줌
    {
        string directoryPath = Path.Combine(Application.dataPath, "@Data");
        string filePath = Path.Combine(directoryPath, $"{typeof(T).Name}.txt");

         if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        
        
        if (!File.Exists(filePath))
        {
            Debug.Log(filePath + "불러오기");
            Debug.Log($"해당 데이터가 존재 하지 않습니다.");
            return null;  
        }

        string json = File.ReadAllText(filePath);

        T data = JsonUtility.FromJson<T>(json);

        return data;
    }
    
    public static void DeleteData<T>()
    {
        string filePath = Path.Combine(Application.dataPath, "@Data", $"{typeof(T).Name}.txt");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log($"파일 삭제: {filePath}");
        }
        else
        {
            Debug.Log($"파일이 존재 하지 않습니다.: {filePath}");
        }
    }

}