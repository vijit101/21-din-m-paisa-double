using System;
using System.IO;
using UnityEngine;

public class DataIntegration : MonoBehaviour
{
    public Student Mystudent;
    public Student stud;
    // Start is called before the first frame update
    void Start()
    {
        
        stud.firstName = "Shubham";
        stud.lastName = "Hashira";
        WriteStudentData(stud);
        string pathstring = "d: /unityprojects/audiotesting/assets/Sdata.json";
        Mystudent = ReadJson(pathstring);
        Debug.Log(Mystudent.firstName);
        Debug.Log(Mystudent.lastName);
    }

    public void WriteStudentData(Student mystud)
    {
        string Studentjson = JsonUtility.ToJson(mystud, true);
        File.WriteAllText(Application.dataPath + "/Sdata.json", Studentjson);

    }

    public Student ReadJson(string FilePath)
    {
        string DataFromJson;
        if (FilePath == null)
        {
            DataFromJson  = File.ReadAllText(Application.dataPath + "/StudentsData.json");
        }
        else
        {
            DataFromJson = File.ReadAllText(FilePath);
        }
        return JsonUtility.FromJson<Student>(DataFromJson);        
    }
}

[Serializable]
public class Student
{
    public string firstName;
    public string lastName;
}