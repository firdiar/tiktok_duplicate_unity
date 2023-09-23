using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    [System.Serializable]
    public class ContentData
    {
        [Header("Detail")]
        public string username;
        public Sprite profileIcon;
        [TextArea]
        public string description;

        [Header("Content")]
        public int contentId;
        public Sprite contentImage;

        [Header("Song")]
        public string songName;
        public Sprite songIcon;

        [Header("Status")]
        public long likes;
        public long comments;
        public long share;
    }

    public class ContentItemView : AMenuView
    {
        [Header("Main Content")]
        [SerializeField]
        Image contentHolder;
        [SerializeField]
        DoubleTapListener doubleTapListener;

        [Header("Right Bar")]
        [SerializeField]
        ProfileHolder profile;
        [SerializeField]
        LikesHolder like;
        [SerializeField]
        TextCountHolder comment;
        [SerializeField]
        TextCountHolder share;
        [SerializeField]
        SongHolder song;

        [Header("Desc Bar")]
        [SerializeField]
        DescriptionBar descriptionBar;

        [Header("Dummy")]
        [SerializeField]
        ContentData contentData;

        private void Start()
        {
            doubleTapListener.OnDoubleTap.AddListener(OnDoubleTap);

            Initialize(contentData);
        }

        private void OnDoubleTap() 
        {
            if (like.IsLiked)
            { 
                //spawn like sprite
            }

            like.LikeChange();
        }

        public void Initialize(ContentData data)
        {
            descriptionBar.Initialize(data);
            profile.Initialize(data.profileIcon, () => Debug.Log($"Opening Profile : {data.username}"));
            like.Initialize(data.likes, false, (isLiked) => Debug.Log($"Like content : {(isLiked)}"));
            comment.Initialize(data.comments, () => Debug.Log($"Open Comment"));
            share.Initialize(data.comments, () => Debug.Log($"Open Share"));
            song.Initialize(data.songIcon, () => Debug.Log($"Open Song {data.songName}"));
        }
    }
}