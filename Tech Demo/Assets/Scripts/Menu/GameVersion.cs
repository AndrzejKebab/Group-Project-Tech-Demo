using TMPro;
using UnityEngine;

namespace PatataStudio
{
    public class GameVersion : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI version;
        private void Awake()
        {
            version.text = "Version: " + Application.version + ".v";
        }
    }
}
