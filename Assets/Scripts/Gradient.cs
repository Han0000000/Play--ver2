using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradient : MonoBehaviour
{
    public Color startColor = Color.red;
    public Color endColor = Color.blue;
    public Renderer renderer; // ��Ƽ������ ������ ������
    void Start()
    {
        ApplyGradient();
    }

    void ApplyGradient()
    {
        Material material = renderer.material;

        // �׶��̼��� �����ϱ� ���� ��Ƽ������ �÷� ������Ƽ�� �����մϴ�.
        material.SetColor("_Color", startColor); // ���� ���� ����

        // �ʿ信 ���� ���İ� �� �ٸ� �÷� ������Ƽ�� ������ �� �ֽ��ϴ�.

        StartCoroutine(AnimateGradient()); // �׶��̼� �ִϸ��̼� ����
    }

    System.Collections.IEnumerator AnimateGradient()
    {
        float duration = 2.0f; // �ִϸ��̼� ���� �ð�
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // �ð��� ���� ���� ���
            Color lerpedColor = Color.Lerp(startColor, endColor, t);

            renderer.material.SetColor("_Color", lerpedColor);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
