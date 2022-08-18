using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    public bool selected, canWalk, canDig, isDead;
    public string characterName;
    public string otherName;
    public GameObject[] otherCharacter;
    public GameObject HUD, UIGem, prefabGem;
    public Outline characterOutline;
    private Animator anim;
    public Vector3 HitDistance;
    public int invGem;
    public AsteroidController AsteroidObject;
    public float HP, maxHP;
    public Image HUDbar;

    private UnityEngine.AI.NavMeshAgent myAgent;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        HP = 5;
        maxHP = 5;
        invGem = 0;
        selected=false;
        canWalk=false;
        myAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();    
        characterOutline = GetComponent<Outline>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invGem > 0 && Input.GetKeyDown("q") && selected){
            Debug.Log("Drop Item");
            invGem--;
            //Instantiate(prefabGem,new Vector3(transform.position.x ,transform.position.y +2 ,transform.position.z),Quaternion.identity);
            Instantiate(prefabGem,new Vector3(transform.position.x ,transform.position.y +1 ,transform.position.z)+(transform.forward*2),Quaternion.identity);
            
        }

        if(selected){
            UIGem.GetComponent<UnityEngine.UI.Text>().text = invGem.ToString();
        }


        if (Input.GetMouseButtonDown(0)) {  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
        if (Physics.Raycast(ray, out hit) && !isDead) {  
  
            if (hit.transform.name == characterName) {  
                Invoke("walkStats", .1f);
                Selected();
            }
            for (var i = 0; i < 2; i++)
            {
                if (hit.transform.name == otherCharacter[i].name) {  
                    UnSelected();
                }
            }
        }  

        if(canWalk){
            if(Input.GetMouseButtonDown(0)){
                Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
                RaycastHit hitInfo;

            if(Physics.Raycast (myRay, out hitInfo, 100, whatCanBeClickedOn)){
                myAgent.SetDestination(hitInfo.point);
                 anim.SetBool("IsRunning", true);

                 HitDistance = hitInfo.point; 
                 //Debug.Log(hitInfo.point);
                
            }
        }
        }
        
        
        }

        //check distance from character to location hit info

        float distance = Vector3.Distance (HitDistance, this.transform.position);
        //Debug.Log("distance " + distance);

        if(distance < 0.1f){
            anim.SetBool("IsRunning", false);
        }

        if(Input.GetKeyDown("space") && selected && canDig){
                Debug.Log("digging");
                anim.Play("dig");
                AsteroidObject.digged();
                Debug.Log("space DIg");
        }
    }

    public void walkStats(){
            canWalk=true;
    }

    public void Selected(){
            
            selected=true;
            HUD.SetActive(true);
            characterOutline.OutlineWidth=5;
    }

    public void UnSelected(){
            characterOutline.OutlineWidth=0;
            selected=false;
            HUD.SetActive(false);
            canWalk=false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Asteroid"){
            Debug.Log("Bisa dig");
            canDig=true;
            AsteroidObject = other.gameObject.GetComponent<AsteroidController>();
                
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Asteroid"){
            Debug.Log("keluar asteroid");
            canDig=false;
            AsteroidObject = null;
                
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="PickAsteroid"){
            Debug.Log("pickAsteroid");
            invGem++;
        }
        if(other.gameObject.tag=="Bullet"){
            Debug.Log("Hit Bullet");
            HP--;

            HUDbar.fillAmount = HP/maxHP;

            
            if(HP<=0){
                Debug.Log("Mati");
                CharacterDead();
            }
        }
    }

    public void CharacterDead(){
        //playdeadcharacter
        anim.Play("Dying");
        selected=false;
        canWalk=false;
        isDead=true;
        characterOutline.OutlineWidth=0;
    }
}
