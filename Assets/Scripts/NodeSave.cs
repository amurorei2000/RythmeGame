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
            // 최초 기록 체크
            if (Input.GetKeyDown(KeyCode.Space))
            {
                recordStart = true;
                startTime = Time.time;
                print("기록 시작");
            }
        }
        // 기록 시작 후 각 키별로 노드 정보 저장
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

            // 스페이스 바 누르면 파일로 저장
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
                print("기록 종료!");
                recordStart = false;
            }
        }

    }
}

