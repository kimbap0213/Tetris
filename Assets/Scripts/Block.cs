using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrisObject
{
    int x;
    int y;
    GameObject blockObject;
    public tetrisObject(int x, int y, GameObject blockObject)
    {
        this.x = x;
        this.y = y;
        this.blockObject = blockObject;
        setxy(x, y);
    }

    void setxy(int x, int y)
    {
        this.x = x;
        this.y = y;
        blockObject.transform.position = new Vector3(x, y, blockObject.transform.position.z);
    }
}

public class Block : MonoBehaviour
{
    protected int[,] existBlock = new int[4, 4];
    protected tetrisObject[] blockObject;
    public List<tetrisObject> thisObject = new List<tetrisObject>();
    public List<GameObject> tmpObject = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            tmpObject.Add(transform.GetChild(i).gameObject);
        }
        updateBlock();
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
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
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
    }
}
