using TMPro;
using UnityEngine;

namespace Asteroids.Command
{
    internal sealed class PanelTwo : BaseUi
    {
        [SerializeField] private TextMeshProUGUI _text;
        public override void Execute()
        {
            _text.text = nameof(PanelTwo);
            gameObject.SetActive(true);
        }
        public override void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}

