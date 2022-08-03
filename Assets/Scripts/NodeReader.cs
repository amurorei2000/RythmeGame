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
        // ������ ������ �����ϸ� �о���� ����!
        if (File.Exists(Application.dataPath + "/SaveData.txt"))
        {
            ReadNodeData("SaveData.txt");
        }
    }

    void ReadNodeData(string path)
    {
        // ���� ��Ʈ���� ����
        FileStream fs = new FileStream(Application.dataPath + "/" + path, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs, Encoding.UTF8);

        string data = sr.ReadToEnd();
        string[] lineData = data.Split('\n');
        
        // �о�� �����͸� MyNode ������ ����Ʈ�� �����ϱ�
        for(int i = 0; i < lineData.Length - 1; i++)
        {
            string[] temp = lineData[i].Split('\r');
            string[] realData = temp[0].Split(',');

            MyNode node = new MyNode(System.Convert.ToSingle(realData[0]), System.Convert.ToInt32(realData[1]));
            nodeList.Add(node);
        }

        // ���� ��Ʈ���� �ݱ�
        fs.Close();
        sr.Close();

        print("������ �б� �Ϸ�!");
    }
}
