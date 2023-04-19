var destination : Transform;
//var sound : AudioClip;

function OnTriggerEnter(other : Collider) {
    //audio.PlayOneShot(sound);
    if (other.tag == "Player") {  
        other.transform.position = destination.position;
        
    }
}