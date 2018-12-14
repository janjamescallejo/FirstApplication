using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class Documents
    {
        string filename;
        string filetype;
        string document;

        public string Filename
        {
            get
            {
                return filename;
            }

            set
            {
                filename = value;
            }
        }

        public string Filetype
        {
            get
            {
                return filetype;
            }

            set
            {
                filetype = value;
            }
        }

        public string Document
        {
            get
            {
                return document;
            }

            set
            {
                document = value;
            }
        }
    }
}