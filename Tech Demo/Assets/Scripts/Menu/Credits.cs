using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PatataStudio
{
    public class Credits : MonoBehaviour
    {
        [SerializeField] private GameObject creditsScreen;
        private Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void CreditsEnd()
        {
            creditsScreen.SetActive(false);
        }
    }
}
