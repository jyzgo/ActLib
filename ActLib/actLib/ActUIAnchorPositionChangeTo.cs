using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActLib
{
    public class ActUIAnchorPositionChangeTo : BaseAct
    {
        public ActUIAnchorPositionChangeTo(float duration, Vector2 position)
        {
            _duration = duration;
            Debug.Log("PP " + position);
            _endPosition = position;
        }

        Vector2 _endPosition;
        RectTransform _trans;

        public override void SetGameObject(GameObject tar)
        {
            base.SetGameObject(tar);
            _trans = tar.GetComponent<RectTransform>();
        }

        public override IEnumerator IAct()
        {
            float elapsedTime = 0;
            Vector2 startingPos = _trans.anchoredPosition;
            Debug.Log("name  " + _trans.name + "hih " + startingPos + " end " + _endPosition);

            while (elapsedTime < _duration)
            {
                Debug.Log("inini " + elapsedTime);
                _trans.anchoredPosition= Vector2.Lerp(startingPos, _endPosition, (elapsedTime / _duration));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            _trans.anchoredPosition = _endPosition;
            Done();
        }
    }
}

