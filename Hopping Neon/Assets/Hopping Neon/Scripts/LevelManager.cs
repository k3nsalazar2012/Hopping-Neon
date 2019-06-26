using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables
    public GameObject stagePrefab;
    public Material transparent;
    int floorCount = 20;
    public float spinRate = 15f;
    #endregion

    #region Main Methods
    void Start()
    {
        Initialize();
    }

    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    //GameManager.Tutorial.SetActive(false);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    float spin = (-touch.deltaPosition.x * 10f) / 4f;
                    transform.rotation *= Quaternion.AngleAxis(spin, transform.up);
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //GameManager.Tutorial.SetActive(false);
            }
            else if (Input.GetMouseButton(0))
            {
                spinRate = 15f;
                if (Input.GetAxis("Mouse X") != 0)
                    transform.rotation *= Quaternion.AngleAxis(-Input.GetAxis("Mouse X") * spinRate, transform.up);
            }
        }
    }
    #endregion

    #region Helper Methods
    void Initialize()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < floorCount; i++)
        {
            // Instantiate a floor
            GameObject stage = GameObject.Instantiate(stagePrefab);
            stage.name = "Level";
            stage.transform.SetParent(transform);
            stage.transform.localScale = Vector3.one;
            stage.transform.localPosition = Vector3.down * (i * 0.14f);

            List<int> floorIndices = new List<int>();

            for (int index = 0; index < stage.transform.childCount; index++) { floorIndices.Add(index); }
            int previousIndex = 0;
            for (int t = 0; t < 1; t++)
            {
                int randomIndex = Random.Range(0, floorIndices.Count);
                int width = 2;

                if (t == 0)
                    previousIndex = randomIndex;
                else
                {
                    randomIndex = previousIndex + 16;
                    if (randomIndex > floorIndices.Count - 1)
                        randomIndex = (randomIndex - (floorIndices.Count - 1));

                    if (randomIndex == -1)
                        randomIndex = 0;
                }

                if (width == 1)
                {
                    GenerateGoal(stage.transform.GetChild(randomIndex));
                    floorIndices.RemoveAt(randomIndex);
                }
                else
                {
                    for (int w = 0; w < width; w++)
                    {
                        GenerateGoal(stage.transform.GetChild(randomIndex));
                        floorIndices.RemoveAt(randomIndex);
                        randomIndex++;
                        if (randomIndex > floorIndices.Count - 1)
                            randomIndex = 0;
                    }
                }
            }
        }
    }

    void GenerateGoal(Transform target)
    {
        target.GetComponent<MeshRenderer>().material = transparent;
        target.gameObject.name = "Goal";
    }
    #endregion
}
