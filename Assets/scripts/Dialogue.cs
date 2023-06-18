using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string[] speechTxt;
    public string actorName;
    public AudioSource falaPersonagem;
    public bool legendas;
    private DialogueControl dc;
    bool onRadious;

    public LayerMask playerLayer;
    public float radious;

    private void Start(){
        this.dc=FindObjectOfType<DialogueControl>();
        this.legendas = ComponentStorage.legendas;
    }

    private void FixedUpdate(){
        Interact();
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space)&&onRadious){
            if(!falaPersonagem.isPlaying){
                falaPersonagem.Play();
            }
            if(legendas == true){
            dc.Speech(this.speechTxt, this.actorName);
            }
             
        }
    }
    
    public void Interact(){
        Collider2D hit=Physics2D.OverlapCircle(this.transform.position, this.radious, this.playerLayer);
        if(hit != null){
            onRadious=true;
        }else{
            onRadious=false;
        }
    }
    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position, this.radious);
    }
}
