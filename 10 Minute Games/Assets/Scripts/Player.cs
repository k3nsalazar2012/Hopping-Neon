using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    new Rigidbody rigidbody;
    bool left, right;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 20 * Time.deltaTime);
        Time.timeScale += (Time.fixedDeltaTime * 0.001f) / 2f;
        rigidbody.velocity += transform.rotation * (Vector3.right * Input.GetAxisRaw("Horizontal") * 20f * Time.deltaTime);
        rigidbody.velocity += (transform.rotation * (Vector3.up * Input.GetAxisRaw("Vertical") * 20f * Time.deltaTime) / 10f);

        if(left)
            rigidbody.velocity += transform.rotation * (Vector3.right * -1f * 20f * Time.deltaTime);
        else if (right)
            rigidbody.velocity += transform.rotation * (Vector3.right * 1f * 20f * Time.deltaTime);
        //print(rigidbody.velocity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Destroyer") return;

        Time.timeScale = 1f;
        FindObjectOfType<SoundEffects>().Dead();

        int score = FindObjectOfType<HUD>().score;

        if (PlayerPrefs.GetInt("best") < score)
            PlayerPrefs.SetInt("best", score);

        StartCoroutine(Restart()); 
    }

    public void Left()
    {
        left = true;
    }

    public void Up()
    {
        left = false;
        right = false;
    }

    public void Right()
    {
        right = true;
    }


    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
