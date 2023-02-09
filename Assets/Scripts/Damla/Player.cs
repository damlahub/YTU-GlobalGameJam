using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed= 2f;
    private float horizontal, vertical;
    [SerializeField] private List <GameObject> enemy = new List <GameObject>();

    [SerializeField] private GameObject lung;
    [SerializeField] private GameObject lungScenePanel;

    [SerializeField] private GameObject brain;
    [SerializeField] private GameObject brainScenePanel;

    private GameObject music;
    private MusicFiles musicFiles;
    
    int counter = 0;
    public Can _lives;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        music = GameObject.Find("AudioManager");
        musicFiles = music.GetComponent(typeof(MusicFiles)) as MusicFiles;
    }
    private void Update()
    {
        Time.timeScale = 1;
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontal*speed, vertical*speed, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            //AudioSource.PlayClipAtPoint(musicFiles.music[2], gameObject.transform.position);
            AudioSource.PlayClipAtPoint(musicFiles.audioClips[2], gameObject.transform.position);
            counter++;
            switch (counter)
            {
                case 1:
                    collision.gameObject.SetActive(false);
                    lung.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case 2:
                    collision.gameObject.SetActive(false);
                    lung.transform.GetChild(1).gameObject.SetActive(true);
                    lungScenePanel.SetActive(true);
                    for (int i = 0; i < enemy.Count; i++)
                    {
                        enemy[i].gameObject.SetActive(false);
                    }
                    Invoke("SceneChange", 3f);
                    break;
            }
        }
        if (collision.gameObject.CompareTag("Brain"))
        {
            AudioSource.PlayClipAtPoint(musicFiles.audioClips[2], gameObject.transform.position);
            counter++;
            switch (counter)
            {
                case 1:
                    collision.gameObject.SetActive(false);
                    brain.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case 2:
                    collision.gameObject.SetActive(false);
                    brain.transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case 3:
                    collision.gameObject.SetActive(false);
                    brain.transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case 4:
                    collision.gameObject.SetActive(false);
                    brain.transform.GetChild(3).gameObject.SetActive(true);
                    brainScenePanel.SetActive(true);
                    for(int i=0; i<enemy.Count; i++)
                    {
                        enemy[i].gameObject.SetActive(false);
                    }
                    Invoke("SceneChange", 3f);
                    break;
            }
        }

    }
    private void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _lives.can--;
            AudioSource.PlayClipAtPoint(musicFiles.audioClips[1], gameObject.transform.position);
            if (_lives.can == 0 )
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
