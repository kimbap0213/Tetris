using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrisObject
{
    private int x, y;
    private GameObject blockObject;
    public tetrisObject(int x, int y, GameObject blockObject)
    {
        this.x = x;
        this.y = y;
        this.blockObject = blockObject;
        setxy(x, y);
    }

    public void setxy(int x, int y)
    {
        this.x = x;
        this.y = y;
        blockObject.transform.localPosition = new Vector3(y, 3 - x, blockObject.transform.position.z);
    }
}

public class Block : MonoBehaviour
{
    protected int[] bottom = new int[3];
    protected int[] rl = new int[2];
    protected int[,] existBlock = new int[4, 4];
    protected tetrisObject[] blockObject;
    public List<tetrisObject> thisObject = new List<tetrisObject>();
    public List<GameObject> tmpObject = new List<GameObject>();
    private void Start()
    {
        StartCoroutine(Down());
        for (int i = 0; i < 4; i++)
        {
            tmpObject.Add(transform.GetChild(i).gameObject);
        }
        int objecti = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (existBlock[i, j] == 1)
                {
                    thisObject.Add(new tetrisObject(i, j, tmpObject[objecti]));
                    objecti++;
                    if (objecti >= tmpObject.Count)
                    {
                        return;
                    }
                }
            }
        }
    }

    void updateBlock()
    {
        int objecti = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (existBlock[i, j] == 1)
                {
                    thisObject[objecti].setxy(i, j);
                    objecti++;
                    if (objecti >= thisObject.Count)
                    {
                        return;
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("aa");
            int[,] tmpBlock = (int[,])existBlock.Clone();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    existBlock[i, j] = tmpBlock[3 - j, i];
                }
            }
            updateBlock();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("aa");
            int[,] tmpBlock = (int[,])existBlock.Clone();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    existBlock[i, j] = tmpBlock[j, 3 - i];
                }
            }
            updateBlock();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    public IEnumerator Down()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            Debug.Log("down");
            transform.position -= new Vector3(0, 1, 0);
        }
    }
}
