using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringBehaviour : MonoBehaviour
{
    //время смены цвета
    [SerializeField]
    private float _recoloringDuration = 2f;
  //наш текущий цвет
  private Color _startColor;
  private Color _nextColor;
  private Renderer _renderer;
  
  //наше тукущее время
  [SerializeField]
  private float _recoloringTime;
  


  private void Awake()
  {
      _renderer = GetComponent<Renderer>();
      GenerateNextColor();
      
  }

  private void GenerateNextColor()
  {
      //присваеваем _startColor цвет нашего текущего материала
      _startColor = _renderer.material.color;
    //рандомный метод :  hue(База цветов),Saturation(Насыщеность),Value(Яркость),Alfa(прозрачность)
     _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
  }

  private void Update()
  {
      //накапливаем время
      _recoloringTime += Time.deltaTime;
      var progress = _recoloringTime / _recoloringDuration;
      var currentColor = Color.Lerp(_startColor, _nextColor, progress);
      //обращаемся к материалу и присваем currentColor
      _renderer.material.color = currentColor;

      if (_recoloringTime >= _recoloringDuration)
      {
          _recoloringTime = 0f;
          GenerateNextColor();
      }
  }
}
