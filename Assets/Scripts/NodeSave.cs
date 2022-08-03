using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class NodeSave : MonoBehaviour
{
    public List<MyNode> Nodes = new List<MyNode>();
    float startTime = 0;
    bool recordStart;

    void Start()
    {
        recordStart = false;
    }

    void Update()
    {
        if (!recordStart)
        {
            // ���� ��� üũ
            if (Input.GetKeyDown(KeyCode.Space))
            {
                recordStart = true;
                startTime = Time.time;
                print("��� ����");
            }
        }
        // ��� ���� �� �� Ű���� ��� ���� ����
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                MyNode node = new MyNode(Time.time - startTime, 0);
                Nodes.Add(node);
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                MyNode node = new MyNode(Time.time - startTime, 1);
                Nodes.Add(node);
            }
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                MyNode node = new MyNode(Time.time - startTime, 2);
                Nodes.Add(node);
            }
            
            if (Input.GetKeyDown(KeyCode.L))
            {
                MyNode node = new MyNode(Time.time - startTime, 3);
                Nodes.Add(node);
            }

            // �����̽� �� ������ ���Ϸ� ����
            if(Input.GetKeyDown(KeyCode.Space))
            {
                string path = new string("/SaveData.txt");
                FileStream fs = new FileStream(Application.dataPath + path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                foreach (MyNode node in Nodes)
                {
                    sw.WriteLine("{0:F3}, {1:D}", node.time, node.key);
                }

                sw.Close();
                fs.Close();
                print("��� ����!");
                recordStart = false;
            }
        }

    }
}

