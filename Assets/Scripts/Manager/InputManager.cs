using System;
using UnityEngine;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {

        [SerializeField] private GameObject cursorEffectRef;

        [SerializeField] private GameObject clickEffectRef;
        
        private Unit activeUnit;
        
        private Camera mainCamera;

        private Vector2 startClickPosition;

        private GameObject cursorEffect;

        public bool HaveSelected => activeUnit != null;
        private void Awake()
        {
            mainCamera = Camera.main;
#if UNITY_EDITOR
            cursorEffect = Instantiate(cursorEffectRef,Vector3.zero, Quaternion.identity);
            Cursor.visible = false;
#endif
        }

        private void Update()
        {
            Vector2 mousePosition = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;
            var worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
            {
                startClickPosition = mousePosition;
            }
            
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0))
            {
                if (Vector2.Distance(startClickPosition, mousePosition) < 10)
                {
                    OnClickHandle(worldPosition);
                }
            }
           
            ShowCursorEffect(worldPosition);
        }

        private void OnClickHandle(Vector2 worldPosition)
        {
            var hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (TrySelectUnit(hit,out var unit))
            {
                if (HaveSelected)
                {
                    if (unit == activeUnit)
                    {
                        DeSelectActiveUnit();
                        return;
                    }
                }
                SelectUnit(unit);
            }
            else
            {
                if (activeUnit != null)
                {
                    activeUnit.MoveToTarget(worldPosition);
                    ShowClickEffect(worldPosition);
                }
            }
          
        }


        private void ShowCursorEffect(Vector2 pos)
        {
#if UNITY_EDITOR
            if (cursorEffect != null)
            {
                cursorEffect.transform.position = pos;
            }
#endif
        }
        
        private void ShowClickEffect(Vector2 pos)
        {
            if (clickEffectRef != null)
            {
                Instantiate(clickEffectRef, pos, Quaternion.identity);
            }
        }
        
        private bool TrySelectUnit(RaycastHit2D hit2D,out Unit unit)
        {
            if (hit2D.collider != null && hit2D.collider.TryGetComponent<Unit>(out var hitUnit))
            {
                unit = hitUnit;
                return true;
            }
            else
            {
                unit = null;
                return false;
            }
        }

        private void SelectUnit(Unit unit)
        {
            DeSelectActiveUnit();
            activeUnit = unit;
            activeUnit.Select();
        }

        private void DeSelectActiveUnit()
        {
            if (HaveSelected)
            {
                activeUnit.UnSelect();
                activeUnit = null;
            }
        }
    }
}