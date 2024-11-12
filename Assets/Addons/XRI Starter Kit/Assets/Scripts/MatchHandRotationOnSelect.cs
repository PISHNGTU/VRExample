// Author MikeNspired. 

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace MikeNspired.UnityXRHandPoser
{
    public class MatchHandRotationOnSelect : MonoBehaviour
    {
        public XRBaseInteractable interactable;
        public Transform HandAttachTransformParent;

        private void OnValidate()
        {
            if (!interactable) interactable = GetComponent<XRBaseInteractable>();
        }

        private void Start()
        {
            OnValidate();
            interactable.selectEntered.AddListener(x => SetPosition(x.interactorObject.transform.GetComponentInParent<HandReference>()?.Hand));
        }

        private void SetPosition(HandAnimator handAnimator)
        {
            var handDirection = handAnimator.transform.forward;
            HandAttachTransformParent.transform.forward = Vector3.ProjectOnPlane(handDirection, transform.up);
            HandAttachTransformParent.transform.Rotate(Vector3.forward, -90f);
        }
    }
}
