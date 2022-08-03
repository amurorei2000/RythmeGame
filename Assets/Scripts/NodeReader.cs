using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class NodeReader : MonoBehaviour
{
    public static List<MyNode> nodeList = new List<MyNode>();


    void Start()
    {
        // 지정한 파일이 존재하면 읽어오기 시작!
        if (File.Exists(Application.dataPath + "/SaveData.txt"))
        {
            ReadNodeData("SaveData.txt");
        }
    }

    void ReadNodeData(string path)
    {
        // 파일 스트리밍 열기
        FileStream fs = new FileStream(Application.dataPath + "/" + path, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs, Encoding.UTF8);

        string data = sr.ReadToEnd();
        string[] lineData = data.Split('\n');
        
        // 읽어온 데이터를 MyNode 형식의 리스트로 저장하기
        for(int i = 0; i < lineData.Length - 1; i++)
        {
            string[] temp = lineData[i].Split('\r');
            string[] realData = temp[0].Split(',');

            MyNode node = new MyNode(System.Convert.ToSingle(realData[0]), System.Convert.ToInt32(realData[1]));
            nodeList.Add(node);
        }

        // 파일 스트리밍 닫기
        fs.Close();
        sr.Close();

        print("데이터 읽기 완료!");
    }
}
