using System.IO;
using UnityEngine;

public  class DataManager
{
    
    //TODO 파일 확인을 위해 dataPath로 설정  실제 빌드 시에는 persistentDataPath 사용 해야함
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
        
        //Combine을 사용하면 OS환경 제한 없이 PATH 설정 가능 \으로 하면 OS에 따라서 오류 생길 수 있음
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