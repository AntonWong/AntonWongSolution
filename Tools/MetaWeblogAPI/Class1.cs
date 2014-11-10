using System;
using CookComputing.XmlRpc;

namespace Tools.MetaWeblogService
{
    #region 微软MSN网站 使用的 MetaWeblog API.
    /// 这个结构代表用户的博客基本信息         
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct UserBlog
    {
        public string Url;
        public string Blogid;
        public string BlogName;
    }


    /// <summary>  
    /// 这个结构代表用户信息         
    /// </summary>          
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct UserInfo
    {
        public string Url;
        public string Blogid;
        public string BlogName;
        public string Firstname;
        public string Lastname;
        public string Email;
        public string Nickname;
    }


    /// <summary>  
    /// 这个结构代表博客分类信息         
    /// 这后面的getCategories()方法会取到CATEGORY数据。         
    /// </summary>          
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Category
    {
        public string Description;
        public string Title;
    }

    /// <summary>  
    /// 这个结构代表博客（ 文章 ）信息。         
    /// 这后面的 editPost()方法, getRecentPosts()方法 和 getPost()方法 会取倒POST数据 .  
    /// </summary>          
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Post
    {
        public DateTime DateCreated;
        public string Description;
        public string Title;
        public string Postid;
        public string[] Categories;
    }
    #endregion


    #region 网站:http://msdn.microsoft.com/en-us/library/aa905670.aspx
    ///// <summary>  
    ///// 微软MSN网站 使用的 MetaWeblog API.  
    ////  网站:http://msdn.microsoft.com/en-us/library/aa905670.aspx         
    ///// </summary>          
    public class MMetaWeblog : XmlRpcClientProtocol
    {


        /// <summary>  
        /// Returns the most recent draft and non-draft blog posts sorted in descending order by publish date.  
        /// </summary>  
        /// <param name="blogid"> This should be the string MyBlog, which indicates that the post is being created in the user’s blog. </param>  
        /// <param name="username"> The name of the user’s space. </param>  
        /// <param name="password"> The user’s secret word. </param>  
        /// <param name="numberOfPosts"> The number of posts to return. The maximum value is 20. </param>  
        /// <returns></returns>  
        /// TODO:得到最近发布的帖子         
        [XmlRpcMethod("metaWeblog.getRecentPosts")]
        public Post[] GetRecentPosts(
        string blogid,
        string username,
        string password,
        int numberOfPosts)
        {

            return (Post[])Invoke("getRecentPosts", new object[] { blogid, username, password, numberOfPosts });
        }


        /// <summary>  
        /// Posts a new entry to a blog.  
        /// </summary>  
        /// <param name="blogid"> This should be the string MyBlog, which indicates that the post is being created in the user’s blog. </param>  
        /// <param name="username"> The name of the user’s space. </param>  
        /// <param name="password"> The user’s secret word. </param>
        /// <param name="content"></param>
        /// <param name="publish"> If false, this is a draft post. </param>  
        /// <returns> The postid of the newly-created post. </returns>  
        /// TODO:增加一个最新的帖子         
        [XmlRpcMethod("metaWeblog.newPost")]
        public string NewPost(
        string blogid,
        string username,
        string password,
        Post content,
        bool publish)
        {

            return (string)Invoke("newPost", new object[] { blogid, username, password, content, publish });
        }

        /// <summary>  
        /// Edits an existing entry on a blog.  
        /// </summary>  
        /// <param name="postid"> The ID of the post to update. </param>  
        /// <param name="username"> The name of the user’s space. </param>  
        /// <param name="password"> The user’s secret word. </param>
        /// <param name="content"></param>
        /// <param name="publish"> If false, this is a draft post. </param>  
        /// <returns> Always returns true. </returns>  
        /// TODO:更新一个帖子         
        [XmlRpcMethod("metaWeblog.editPost")]
        public bool EditPost(
        string postid,
        string username,
        string password,
        Post content,
        bool publish)
        {

            return (bool)Invoke("editPost", new object[] { postid, username, password, content, publish });
        }

        /// <summary>  
        /// Deletes a post from the blog.  
        /// </summary>  
        /// <param name="appKey"> This value is ignored. </param>  
        /// <param name="postid"> The ID of the post to update. </param>  
        /// <param name="username"> The name of the user’s space. </param>  
        /// <param name="password"> The user’s secret word. </param>
        /// <param name="publish"> This value is ignored. </param>  
        /// <returns> Always returns true. </returns>  
        /// TODO:删除一个帖子         
        [XmlRpcMethod("blogger.deletePost")]
        public bool DeletePost(
        string appKey,
        string postid,
        string username,
        string password,
        bool publish)
        {

            return (bool)Invoke("deletePost", new object[] { appKey, postid, username, password, publish });
        }


        /// <summary>  
        /// Returns information about the user’s space. An empty array is returned if the user does not have a space.  
        /// </summary>  
        /// <param name="appKey"> This value is ignored. </param>
        /// <param name="username"> The name of the user’s space. </param>  
        /// <param name="password"></param>         
        /// <returns> An array of structs that represents each of the user’s blogs. The array will contain a maximum of one struct, since a user can only have a single space with a single blog. </returns>  
        /// TODO:得到用户的博客清单         
        [XmlRpcMethod("blogger.getUsersBlogs")]
        public UserBlog[] GetUsersBlogs(
        string appKey,
        string username,
        string password)
        {

            return (UserBlog[])Invoke("getUsersBlogs", new object[] { appKey, username, password });
        }

        /// <summary>  
        /// Returns basic user info (name, e-mail, userid, and so on).  
        /// </summary>  
        /// <param name="appKey"> This value is ignored. </param>
        /// <param name="username"> The name of the user’s space. </param>  
        /// <param name="password"></param>         
        /// <returns> A struct containing profile information about the user.  
        /// Each struct will contain the following fields: nickname, userid, url, e-mail,  
        /// lastname, and firstname. </returns>  
        /// TODO:得到用户信息         
        [XmlRpcMethod("blogger.getUserInfo")]
        public UserInfo GetUserInfo(
        string appKey,
        string username,
        string password)
        {

            return (UserInfo)Invoke("getUserInfo", new object[] { appKey, username, password });
        }


        /// <summary>  
        /// Returns a specific entry from a blog.  
        /// </summary>  
        /// <param name="postid"> The ID of the post to update. </param>  
        /// <param name="username"> The name of the user’s space. </param>  
        /// <param name="password"> The user’s secret word. </param>  
        /// <returns> Always returns true. </returns>  
        /// TODO:获取一个帖子         
        [XmlRpcMethod("metaWeblog.getPost")]
        public Post GetPost(
        string postid,
        string username,
        string password)
        {

            return (Post)Invoke("getPost", new object[] { postid, username, password });
        }

        /// <summary>  
        /// Returns the list of categories that have been used in the blog.  
        /// </summary>  
        /// <param name="blogid"> This should be the string MyBlog, which indicates that the post is being created in the user’s blog. </param>  
        /// <param name="username"> The name of the user’s space. </param>  
        /// <param name="password"> The user’s secret word. </param>  
        /// <returns> An array of structs that contains one struct for each category. Each category struct will contain a description field that contains the name of the category. </returns>  
        /// TODO:得到博客分类         
        [XmlRpcMethod("metaWeblog.getCategories")]
        public Category[] GetCategories(
        string blogid,
        string username,
        string password)
        {

            return (Category[])Invoke("getCategories", new object[] { blogid, username, password });
        }
    }
    #endregion
}
