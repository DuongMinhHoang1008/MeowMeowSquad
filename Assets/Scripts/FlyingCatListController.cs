using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
public class FlyingCatListController : MonoBehaviour
{
    [SerializeField] GameObject NodePref;
    [SerializeField] List<GameObject> catList = new List<GameObject>();
    Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 1f;
    [SerializeField] int maxCatNum = 5;
    int catNum = 2;
    void Start()
    {
        for (int i = 0; i < maxCatNum; i++) {
            GameObject cat = Instantiate(NodePref, transform.position + Vector3.left * i * 1.25f, Quaternion.identity, transform);
            catList.Add(cat);
            FlyingCatController catController = cat.GetComponent<FlyingCatController>();
            catController.SetHorizontalSpeed(speed);
            catController.SetListController(this);
            catController.SetIndex(i);
            if (i >= catNum) catController.SetVisible(false);
        }

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            StartCoroutine(NodeWaveCoroutine(true));
        } else {
            StartCoroutine(NodeWaveCoroutine(false));
        }
    }
    
    private void FixedUpdate() {
        Vector2 movePos = rigidbody2D.position + speed * Vector2.right * Time.fixedDeltaTime;
        rigidbody2D.MovePosition(movePos);
    }

    // Coroutine xử lý hiệu ứng "dãy sóng" cho các Node
    IEnumerator NodeWaveCoroutine(bool goUp)
    {
        for (int i = 0; i < catList.Count; i++) {
            // Nếu muốn thay đổi ngay Node đầu tiên, không cần delay
            if (i > 0) yield return new WaitForSeconds(0.1f);
            if (goUp) {
                catList[i].GetComponent<FlyingCatController>().GoUp();
            } else {
                catList[i].GetComponent<FlyingCatController>().GoDown();
            }
        }
    }

    public void AppendCat() {
        if (catNum < maxCatNum) {
            catList[catNum].GetComponent<FlyingCatController>().SetVisible(true);
            catNum++;
        }
        for (int i = catNum - 1; i >= 1; i--) {
            catList[i].GetComponent<FlyingCatController>().ChangeType(catList[i - 1].GetComponent<SpriteRenderer>().color);
        }
        catList[0].GetComponent<FlyingCatController>().ChangeType();
    }

    public void DestroyCat(int index) {
        for (int i = index; i < catNum - 1; i++) {
            catList[i].GetComponent<FlyingCatController>().ChangeType(catList[i + 1].GetComponent<SpriteRenderer>().color);
        }
        catList[catNum - 1].GetComponent<FlyingCatController>().SetVisible(false);
        catNum--;
    }
}
