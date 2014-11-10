using System;
using CookComputing.XmlRpc;

namespace Tools.MetaWeblogAPI
{
    #region Structs
    public struct BlogInfo
    {
        public string Blogid;
        public string Url;
        public string BlogName;
    }
    public struct Category
    {
        public string CategoryId;
        public string CategoryName;
    }
    [Serializable]
    public struct CategoryInfo
    {
        public string Description;
        public string HtmlUrl;
        public string RssUrl;
        public string Title;
        public string Categoryid;
    }
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Enclosure
    {
        public int Length;
        public string Type;
        public string Url;
    }
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Post
    {
        public DateTime DateCreated;
        public string Description;
        public string Title;
        public string[] Categories;
        public string Permalink;
        public object Postid;
        public string Userid;
        public string WpSlug;
    }
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Source
    {
        public string Name;
        public string Url;
    }
    public struct UserInfo
    {
        public string Userid;
        public string Firstname;
        public string Lastname;
        public string Nickname;
        public string Email;
        public string Url;
    }
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct MediaObject
    {
        public string Name;
        public string Type;
        public byte[] Bits;
    }
    [Serializable]
    public struct MediaObjectInfo
    {
        public string Url;
    }
    #endregion
}
