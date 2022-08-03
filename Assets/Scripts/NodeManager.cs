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
        // 노드 생성 딜레이 주기
        Invoke("NodeCreate", startDelay);
    }

    void NodeCreate()
    {
        // 전체 노드 미리 생성하기
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
                print("노드 생성 완료~~");
                yield break;
            }

            while (NodeReader.nodeList.Count > 0)
            {
                // 리스트의 첫 번째 노드 뽑기
                MyNode currentNode = NodeReader.nodeList[0];
                
                // 노드 기록 시간이 현재 시간과 같으면 생성하고 리스트에서 목록 제거하기
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
