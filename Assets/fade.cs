using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    // La durée de l'animation de fondu en secondes
    public float fadeDuration = 1.0f;

    // L'image à faire apparaître progressivement
    public Image image;

    private float currentTime = 0.0f;
    private bool fadingIn = false;

    void Start()
    {
        // On démarre l'animation en rendant l'image transparente
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
        fadingIn = true;
    }

    void Update()
    {
        if (fadingIn)
        {
            // On augmente la transparence de l'image progressivement
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0.0f, 1.0f, currentTime / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            // Si l'animation est terminée, on arrête de la faire apparaître progressivement
            if (currentTime >= fadeDuration)
            {
                fadingIn = false;
            }
        }
    }
}
