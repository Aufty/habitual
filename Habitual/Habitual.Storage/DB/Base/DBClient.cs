using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Storage.DB.Base
{
    public class DBClient
    {
        private static volatile HttpClient client;

        public static HttpClient GetInstance()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 4096000;
            }

            return client;
        }
    }
}
