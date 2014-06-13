using UnityEngine;
using System.IO;
using System.Collections;
using LitJson;

public class TubeFactory : MonoBehaviour {
    public Rigidbody2D tube;
    public float waitTime;
    public float minCreatePosY;
    public float maxCreatePosY;
    public float finishPosX;
    public float speed;

	// Use this for initialization
	void Start () {
        Random.seed = System.DateTime.Today.Millisecond;

        GetComponent<Observer>().AddEventHandler("GameOver", OnGameOver);

        StartCoroutine(CreateTube());    
	}

    IEnumerator CreateTube() {
        yield return new WaitForSeconds(waitTime);

        float posY = Random.Range(minCreatePosY, maxCreatePosY);
        Vector3 createPos = new Vector3(0, posY, transform.position.z);
        Rigidbody2D instance = Instantiate(tube, createPos, Quaternion.identity) as Rigidbody2D;
        instance.velocity = new Vector2(speed, 0);

        StartCoroutine(CreateTube());

        while(instance.transform.position.x >= finishPosX)
            yield return null;
        Destroy(instance.gameObject);
    }

    public void OnGameOver(object sender, System.EventArgs e)
    {
        StopAllCoroutines();
    }
}