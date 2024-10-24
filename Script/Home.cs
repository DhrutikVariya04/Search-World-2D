using System;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    private string[] AllStrings = { "HOME", "CARS", "DHRUTIK", "GAME", "ROOM" };

    private GameObject[,] TextStorage = new GameObject[7, 6];

    private System.Random random = new System.Random();

    private bool Check = false;
    private Vector2Int startPos = Vector2Int.zero, lastPos = new Vector2Int(-1, -1);


    [SerializeField]
    GameObject Question, Alphabet, space, AnswerSaw;

    void Start()
    {

        for (int i = 0; i < AllStrings.Length; i++)
        {
            Question.transform.GetChild(i).GetComponent<Text>().text = AllStrings[i];
        }

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                TextStorage[i, j] = Instantiate(Alphabet, space.transform);
                TextStorage[i, j].GetComponent<Text>().text = GetRandomAlphabet() + "";
                TextStorage[i, j].name = $"{i},{j}";

            }
        }

    }

    void Update()
    {
        print(startPos);
        if (Input.GetMouseButtonDown(1))
        {
            Check = true;

            /*string OldPos = collider.gameObject.name;
            string[] Pos = OldPos.Split(',');
            startPos = new Vector2Int(int.Parse(Pos[0]), int.Parse(Pos[1]));
            print(startPos);*/
        }

        if (Input.GetMouseButtonUp(1))
        {
            Check = false;

            for (int i = 0; i < AllStrings.Length; i++)
            {
                if (AllStrings[i] == AnswerSaw.GetComponentInChildren<Text>().text)
                {
                    print(AllStrings[i] + " == >> " + AllStrings[i].Length);
                }
                else
                {
                    //Debug.Log("Wrong Answer");
                }

                AnswerSaw.GetComponentInChildren<Text>().text = "";
            }
        }

        if (Check)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (lastPos != new Vector2Int(-1, -1) && hit.collider.transform.tag != "Used")
                {
                    print("Enter");
                    if (startPos.y == lastPos.y + 1)
                    {
                        print("Horizonatal");
                    }

                    if (startPos.x == lastPos.x + 1)
                    {
                        print("vertical");
                    }
                }
                else
                {
                    lastPos = startPos;
                    hit.collider.transform.tag = "Used";
                }
                /*AnswerSaw.GetComponentInChildren<Text>().text += hit.transform.GetComponent<Text>().text;
                print(hit.transform.GetComponent<Text>().text);*/
            }
        }

    }

    char GetRandomAlphabet()
    {
        int randomNumber = random.Next(0, 26);

        char randomAlphabet = (char)('A' + randomNumber);
        return randomAlphabet;
    }

    void RandomString(GameObject A, int j)
    {
        var selectedstring = AllStrings[2];

        A.GetComponent<Text>().text = selectedstring[j] + "";
        print(selectedstring[j] + "");
    }
}
