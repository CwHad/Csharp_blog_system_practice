using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace  MyBBSWebApi.Model
{
    [Serializable] // 这个class不可被继承 有或无是没关系的
    public class Posts
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public Posts()
        { }

        private System.Int32 _Id;
        private System.String _PostTitle;
        private System.String _PostIcon;
        private System.Int32 _PostTypeId;
        private System.String _PostType;
        private System.String _PostContent;
        private System.Int32 _Clicks;
        private System.Int32 _Replys;
        private System.DateTime? _CreateTime;
        private System.Int32 _CreateUserId;
        private System.DateTime? _EditTime;
        private System.Int32 _EditUserId;
        private System.DateTime? _LastReplyTime;
        private System.Int32 _LastReplyUserId;
        private System.String _Up;
        private System.String _Down;

        /// <summary>
        /// Id属性封装
        /// </summary>
        public System.Int32 Id
        {
            set { _Id = value; }
            get { return _Id; }
        }
        /// <summary>
        /// PostTitle属性封装
        /// </summary>
        public System.String PostTitle
        {
            set { _PostTitle = value; }
            get { return _PostTitle; }
        }
        /// <summary>
        /// PostIcon属性封装
        /// </summary>
        public System.String PostIcon
        {
            set { _PostIcon = value; }
            get { return _PostIcon; }
        }
        /// <summary>
        /// PostTypeId属性封装
        /// </summary>
        public System.Int32 PostTypeId
        {
            set { _PostTypeId = value; }
            get { return _PostTypeId; }
        }
        /// <summary>
        /// PostType属性封装
        /// </summary>
        public System.String PostType
        {
            set { _PostType = value; }
            get { return _PostType; }
        }
        /// <summary>
        /// PostContent属性封装
        /// </summary>
        public System.String PostContent
        {
            set { _PostContent = value; }
            get { return _PostContent; }
        }
        /// <summary>
        /// Clicks属性封装
        /// </summary>
        public System.Int32 Clicks
        {
            set { _Clicks = value; }
            get { return _Clicks; }
        }
        /// <summary>
        /// Replys属性封装
        /// </summary>
        public System.Int32 Replys
        {
            set { _Replys = value; }
            get { return _Replys; }
        }
        /// <summary>
        /// CreateTime属性封装
        /// </summary>
        public System.DateTime? CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }
        /// <summary>
        /// CreateUserId属性封装
        /// </summary>
        public System.Int32 CreateUserId
        {
            set { _CreateUserId = value; }
            get { return _CreateUserId; }
        }
        /// <summary>
        /// EditTime属性封装
        /// </summary>
        public System.DateTime? EditTime
        {
            set { _EditTime = value; }
            get { return _EditTime; }
        }
        /// <summary>
        /// EditUserId属性封装
        /// </summary>
        public System.Int32 EditUserId
        {
            set { _EditUserId = value; }
            get { return _EditUserId; }
        }
        /// <summary>
        /// LastReplyTime属性封装
        /// </summary>
        public System.DateTime? LastReplyTime
        {
            set { _LastReplyTime = value; }
            get { return _LastReplyTime; }
        }
        /// <summary>
        /// LastReplyUserId属性封装
        /// </summary>
        public System.Int32 LastReplyUserId
        {
            set { _LastReplyUserId = value; }
            get { return _LastReplyUserId; }
        }
        /// <summary>
        /// Up属性封装
        /// </summary>
        public System.String Up
        {
            set { _Up = value; }
            get { return _Up; }
        }
        /// <summary>
        /// Down属性封装
        /// </summary>
        public System.String Down
        {
            set { _Down = value; }
            get { return _Down; }
        }
    }
}
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
