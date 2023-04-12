using UnityEngine;
using TMPro;


namespace Asteroids.Command
{
    internal sealed class PanelOne : BaseUi
    {
        [SerializeField] private TextMeshProUGUI _text;
        public override void Execute()
        {
            _text.text = nameof(PanelOne);
            gameObject.SetActive(true);
        }
        public override void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}

