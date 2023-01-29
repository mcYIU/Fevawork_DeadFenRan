using UnityEngine;

public class HurtRegion : MonoBehaviour {

	void OnTriggerStay2D (Collider2D col) {
        if (col.CompareTag("Player"))
        {
                col.SendMessage("Kill");
                col.SendMessage("Restart");
        }
	}
}


