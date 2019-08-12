using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class Comment
    {
        string commentID;
        string productID;
        string userID;
        string commentContent;
        int upvotes;
        int downvotes;
        DateTime datecreated;
        
        public string CommentID
        {
            get
            {
                return commentID;
            }

            set
            {
                commentID = value;
            }
        }

        public string ProductID
        {
            get
            {
                return productID;
            }

            set
            {
                productID = value;
            }
        }

        public string UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        public string CommentContent
        {
            get
            {
                return commentContent;
            }

            set
            {
                commentContent = value;
            }
        }

        public int Upvotes
        {
            get
            {
                return upvotes;
            }

            set
            {
                upvotes = value;
            }
        }

        public int Downvotes
        {
            get
            {
                return downvotes;
            }

            set
            {
                downvotes = value;
            }
        }

        public DateTime Datecreated
        {
            get
            {
                return datecreated;
            }

            set
            {
                datecreated = value;
            }
        }
    }
}