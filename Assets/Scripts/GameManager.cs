using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float velocidad = 2;
    public GameObject menuPrincipal;
    public GameObject menuGameOver;
    public GameObject col;
    public GameObject piedra;
 
    public GameObject buzon;
    public GameObject muro;
    public GameObject cono;
    //atributo de tipo publico 
    public Renderer fondo;
    public bool gameOver = false;
    public bool start=false;

    public List<GameObject> cols;
    public List<GameObject> obstaculos;
    // Start is called before the first frame update
    void Start()
    {
        // Crear Mapa 
        for(int i=0; i < 21; i++)
        {
           cols.Add(Instantiate(col, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        // Crear los obstaculos
        obstaculos.Add(Instantiate(piedra, new Vector2(10, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(buzon, new Vector2(30, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(muro, new Vector2(40, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(cono, new Vector2(50, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {

        if (start == false)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start==true && gameOver==false)
        {
            menuPrincipal.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;

            // Mover mapa 
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -10)
                {
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }
                //cols.Add(Instantiate(col, new Vector2(-10 + 1, i - 3), Quaternion.identity));
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            //Mover Obstaculos
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(15, 35);
                    obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                
                obstaculos[i].transform.position = obstaculos[i].transform. position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

        }
    }
}
