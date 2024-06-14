using Experimental;
using UnityEngine;
using UnityEngine.Events;

namespace Prompts
{
    public class PromptTypeA : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onPromptCollided;
        [SerializeField] private UnityEvent _onPromptExited;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                Debug.Log(player.gameObject.name + " has entered the trigger");
                _onPromptCollided.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                Debug.Log(player.gameObject.name + " has left the trigger");
                _onPromptExited.Invoke();
            }
        }
    }
}
