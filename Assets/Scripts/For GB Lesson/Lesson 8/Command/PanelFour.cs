using TMPro;
using UnityEngine;

namespace Asteroids.Command
{
    internal sealed class PanelFour : BaseUi
    {
        [SerializeField] private TextMeshProUGUI _text;
        public override void Execute()
        {
            _text.text = nameof(PanelFour);
            gameObject.SetActive(true);
        }
        public override void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}

