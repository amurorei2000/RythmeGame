using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public GameObject nodeBlock;
    public Transform[] nodePosition;
    public float startDelay = 3.0f;

    List<GameObject> nodePrefabs = new List<GameObject>();

    void Start()
    {
        // ��� ���� ������ �ֱ�
        Invoke("NodeCreate", startDelay);
    }

    void NodeCreate()
    {
        // ��ü ��� �̸� �����ϱ�
        for (int i = 0; i < NodeReader.nodeList.Count; i++)
        {
            GameObject go = Instantiate(nodeBlock);
            go.transform.SetParent(transform);
            nodePrefabs.Add(go);
            go.SetActive(false);
        }

        StartCoroutine(CreateNodes());
    }

    IEnumerator CreateNodes()
    {
        while(true)
        {
            if(NodeReader.nodeList.Count == 0)
            {
                print("��� ���� �Ϸ�~~");
                yield break;
            }

            while (NodeReader.nodeList.Count > 0)
            {
                // ����Ʈ�� ù ��° ��� �̱�
                MyNode currentNode = NodeReader.nodeList[0];
                
                // ��� ��� �ð��� ���� �ð��� ������ �����ϰ� ����Ʈ���� ��� �����ϱ�
                if (Time.time - 3.0f >= currentNode.time)
                {
                    nodePrefabs[0].transform.position = nodePosition[currentNode.key].position;
                    nodePrefabs[0].SetActive(true);
                    nodePrefabs.RemoveAt(0);

                    NodeReader.nodeList.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
