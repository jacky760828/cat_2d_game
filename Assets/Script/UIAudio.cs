using Cat;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIAudio : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
   
        public void OnPointerEnter(PointerEventData eventData)
        {
            Game_Manager.Instance.Audio?.play(0, "·Æ¹«²¾°Ê", false, 1f);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Game_Manager.Instance.Audio?.play(1, "ÂIÀ»", false, 1f);
        }
    
}
