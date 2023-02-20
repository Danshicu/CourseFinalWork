using UnityEngine;

namespace Pramchuk
{
    public class PlayerFollow : MonoBehaviour
    {
        [SerializeField] private Transform player;
    
        [SerializeField] private Vector3 offset;
        
    
        void Update()
        {
            this.transform.position = offset + new Vector3(0, player.position.y, 0);
        }
    }

}
