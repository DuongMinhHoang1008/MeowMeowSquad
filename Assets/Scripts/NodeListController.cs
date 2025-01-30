using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeListController : MonoBehaviour
{
    [SerializeField] GameObject NodePref;
    [SerializeField] List<GameObject> nodeLists = new List<GameObject>();
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            GameObject node = Instantiate(NodePref, transform.position + Vector3.left * i * 2, Quaternion.identity);
            nodeLists.Add(node);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            StartCoroutine(NodeGoUp(0, true));
        } else {
            StartCoroutine(NodeGoUp(0, false));
        }
    }
    IEnumerator NodeGoUp(int index, bool goup) {
        float waitTime = 0.1f;
        if (index == 0) waitTime = 0;
        yield return new WaitForSeconds(waitTime);
        if (goup) nodeLists[index].GetComponent<NodeController>().GoUp();
        else nodeLists[index].GetComponent<NodeController>().GoDown();
        if (index < nodeLists.Count - 1) {
            StartCoroutine(NodeGoUp(index + 1, goup));
        }
    }
}
