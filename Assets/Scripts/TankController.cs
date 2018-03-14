using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    float speed = 100.0f;
    public GameObject projectile, missileStart;
    public Controls c;
    public int missileCount = 5;
    bool isShot, fire;

    HashSet<int> selection = new HashSet<int>();

    void Update() {

        //This will fire once...

        // 1-5 1 1-5(shoot,forward,left,right,back) 1 = 3

        if (Input.GetKey(KeyCode.A))
            Control(c.aControl);
        else if (Input.GetKey(KeyCode.D))
            Control(c.dControl);
        else if (Input.GetKey(KeyCode.W))
            Control(c.wControl);
        else if (Input.GetKey(KeyCode.S))
            Control(c.sControl);
        else if (Input.GetKey(KeyCode.Space))
            Control(c.spaceControl);

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || 
            Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Space))
        {
            selection.Remove(5);
        }
    }

    

    void Control(int cse) {
        switch (cse) {
            case 1:
                transform.Rotate(-Vector3.up * speed * Time.deltaTime);
                break;
            case 2:
                transform.Rotate(Vector3.up * speed * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector3.forward * (speed * 4) * Time.deltaTime);
                break;
            case 4:
                transform.Translate(-Vector3.forward * (speed * 1.5f) * Time.deltaTime);
                break;
            case 5:
                if (!selection.Contains(5)){
                    selection.Add(5);

                    if (missileCount > 0){
                        missileCount--;

                        GameObject tempBulletHandler;
                        tempBulletHandler = Instantiate(projectile, missileStart.transform.position, missileStart.transform.rotation) as GameObject;

                        tempBulletHandler.transform.Rotate(90, 0, 0);

                        Rigidbody tempRigidbody;
                        tempRigidbody = tempBulletHandler.GetComponent<Rigidbody>();

                        tempRigidbody.AddForce(transform.forward * (speed * 500));

                        Destroy(tempBulletHandler, 2.0f);
                    }
                }
                    break;
        }
    }

    void OnTriggerEnter(Collider other){
        if (missileCount == 0){
            if (other.gameObject.tag == "AmmoDrop"){
                missileCount++;
                Destroy(other.gameObject);
            }
        }
    }
}
