using System;
using UnityEngine;

namespace UI
{
    public class PointToClick : MonoBehaviour
    {
        [SerializeField] private float duration = 1;

        [SerializeField] private AnimationCurve scaleCurve;
        private SpriteRenderer sp;

        private float timer;

        private float scaleTimer;

        private Vector3 originScale;
        private void Awake()
        {
            TryGetComponent<SpriteRenderer>(out sp);
        }

        private void Start()
        {
            originScale = transform.localScale;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            scaleTimer += Time.deltaTime;
            scaleTimer %= 1;

            transform.localScale = originScale * scaleCurve.Evaluate(scaleTimer);
            if (timer > duration * .9f)
            {
                float alpha = 1 - (timer - duration * .9f) / (duration * .1f);
                var color = sp.color;
                color.a = alpha;
                sp.color = color;
            }
            
            if (timer > duration)
            {
                Destroy(this.gameObject);
            }
        }
    }
}