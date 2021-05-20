using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MirrorImage
{
    public class APIAccess
    {
        public async Task<VINResult> GenericGet(string strUrl)
        {
            try
            {

                Uri uri = new Uri(strUrl);


                HttpClient httpClient = new HttpClient();

                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                HttpResponseMessage response = await httpClient.GetAsync(uri).ConfigureAwait(false);

                var result = response.Content.ReadAsStringAsync().Result;

                var r = new VINResult();
                r.receiveJson = result;
               

                var obj = JsonConvert.DeserializeObject<VINResult>(r.receiveJson);
                obj.status = "OK";
                obj.StatusCode = (int)response.StatusCode;
                obj.IsSucess = true;



                return obj;
            }
            catch (Exception )
            {
                var rslt = new VINResult { IsSucess = false };
                //msg = ex.Message + ex.StackTrace;
                return rslt;
            }
        }
    }

    public class VINResult
    {

        public List<VINVals> Results;

        public string result = "";
        public int StatusCode = 0;
        public string status = "";
        public string receiveJson = "";
        public bool IsSucess = false;
    }

    public class VINVals
    {
        public string Value { get; set; }
        public string ValueId { get; set; }
        public string Variable { get; set; }
        public string VariableId { get; set; }
    }

}
