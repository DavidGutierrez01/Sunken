using System;
using TMPro;
using UnityEngine;

namespace Experimental
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _uiPrompt;


        public void Start()
        {
            _uiPrompt.text = " ";
        }

        public void UpdateText(String value)
        {
            _uiPrompt.text = value;
        }

    }
}
