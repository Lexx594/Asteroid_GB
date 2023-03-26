using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DamageUI : MonoBehaviour
{
    private class ActiveText
    {
        public TextMeshProUGUI UIText;
        public float maxTime;
        public float timer;
        public Vector3 unitPosition;

        public void MoveText(Camera camera) //отображение урона
        {
            float delta = 1.0f - (timer / maxTime); // смещение текста урона
            Vector3 pos = unitPosition + new Vector3 (delta, delta, 0.0f); // к позиции юнита прибавляем смещение дельта
            pos = camera.WorldToScreenPoint(pos); // конвертируем в экранные координаты
            pos.z = 0.0f; //обнуляем позицию по z
            UIText.transform.position = pos;
        }
    }
       
    
    
    public static DamageUI instance {get; private set;}

    public TextMeshProUGUI textPrefab;
    const int POOL_SIZE = 128;

    Queue<TextMeshProUGUI> _textPool = new Queue<TextMeshProUGUI>();
    List<ActiveText> _activeTexts = new List<ActiveText>();

    Camera _camera;
    Transform _transform;




    private void Awake()
    {
        instance = this;
    }
        
    void Start()
    {
        _camera = Camera.main;
        _transform = transform;
        //заполняем ПУЛ
        for (int i = 0; i < POOL_SIZE; i++)
        {
            TextMeshProUGUI temp = Instantiate(textPrefab, _transform);
            temp.gameObject.SetActive(false);
            _textPool.Enqueue(temp);
        }
    }

    
    void Update()
    {
        for(int i = 0; i < _activeTexts.Count; i++)
        {
            ActiveText activeText = _activeTexts[i];
            activeText.timer -= Time.deltaTime;

            if(activeText.timer <= 0.0f )
            {
                activeText.UIText.gameObject.SetActive(false);
                _textPool.Enqueue(activeText.UIText);
                _activeTexts.RemoveAt(i);
                --i;

            }
            else
            {
                var color = activeText.UIText.color;
                color.a = activeText.timer / activeText.maxTime;
                activeText.UIText.color = color;

                activeText.MoveText(_camera);
            }
        }
    }

    public void AddText(int damage, Vector3 unitPosition)
    {
        // извлекаем объект для отрисовки из ПУЛА
        var text = _textPool.Dequeue();
        //устанавливаем сам текст
        text.text = damage.ToString();
        text.gameObject.SetActive(true);

        ActiveText activeText = new ActiveText() { maxTime = 1.0f };
        activeText.timer = activeText.maxTime;
        activeText.UIText = text;
        activeText.unitPosition = unitPosition + Vector3.up;
        activeText.MoveText(_camera);
        _activeTexts.Add(activeText);
    }








}

