using System;
using UnityEngine;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using RSG;
using RSG.Extensions;
using TMPro;
using Zenject;
using DG.Tweening;

namespace Project.Dev.UI.Windows
{
    public abstract  class WindowBase : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] [CanBeNull] private RectTransform window;
        [SerializeField] [Range(1f, 10f)] private float init;
        [SerializeField] [Range(0.1f, 1f)] private float open;

        [SerializeField] protected TextMeshProUGUI tiles;
        [SerializeField] protected TextMeshProUGUI dataText;

        protected bool accepted;
        protected Promise<bool> Promise;

        private void Awake() => kjh();



        private void kjh()
        {
            if (canvasGroup) (canvasGroup.blocksRaycasts, canvasGroup.alpha) = (false, 0);
            if (window) window.localScale = Vector3.one * open;
        }

        private Promise SetVisible(bool value)
        {
            if (canvasGroup) canvasGroup.blocksRaycasts = value;
            var animationPromise = new Promise();

        }


        public virtual Promise<bool> Joi<T>(T data, string tile)
        {
            var ddata = data as string;

            if (tiles && string.IsNullOrEmpty(tile))
                tiles.text = tile;
            if (dataText && string.IsNullOrEmpty(ddata))
                dataText.text = ddata;

            SetVisible(true);

            return Promise = new Promise<bool>();




        }



    }
}

