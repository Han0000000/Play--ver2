using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradient : MonoBehaviour
{
    public Color startColor = Color.red;
    public Color endColor = Color.blue;
    public Renderer renderer; // 머티리얼을 적용할 렌더러
    void Start()
    {
        ApplyGradient();
    }

    void ApplyGradient()
    {
        Material material = renderer.material;

        // 그라데이션을 적용하기 위해 머티리얼의 컬러 프로퍼티를 조절합니다.
        material.SetColor("_Color", startColor); // 시작 색상 설정

        // 필요에 따라 알파값 등 다른 컬러 프로퍼티도 설정할 수 있습니다.

        StartCoroutine(AnimateGradient()); // 그라데이션 애니메이션 시작
    }

    System.Collections.IEnumerator AnimateGradient()
    {
        float duration = 2.0f; // 애니메이션 지속 시간
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // 시간에 따른 보간 계수
            Color lerpedColor = Color.Lerp(startColor, endColor, t);

            renderer.material.SetColor("_Color", lerpedColor);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
