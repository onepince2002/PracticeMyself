using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Vision.V1;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Google_API
{
    class Google_Vision
    {
        public void post(string read= "https://tix.brothers.tw/pic.aspx?TYPE=UTK0205&ts=1556091801365")
        {
            try
            {
                var newClass=new Google_Vision_Request();
                var newRequest = new Request();
                var newImage = new Image();
                var newSource = new Source
                {
                    imageUri= "https://tix.brothers.tw/pic.aspx?TYPE=UTK0205&ts=1556091801365"
                };
                var newFeature = new Feature()
                {
                    type = "TEXT_DETECTION",
                    maxResults = 1
                };
                newImage.source = newSource;
                newRequest.image = newImage;
                newRequest.features = newFeature;
                newClass.requests = newRequest;

                var josn = JsonConvert.SerializeObject(newClass);

                string url ="https://vision.googleapis.com/v1/images:annotate?key=AIzaSyAgTc-4LU_2nGp9WHDoCBCTbyvVcWqR3ms";

                //Google_SDK
                //var image = Google.Cloud.Vision.V1.Image.FromUri(read);
                //var client = ImageAnnotatorClient.Create();
                //var response = client.DetectText(image);
                ////var a =JsonConvert.DeserializeObject(response);

                //if( JsonConvert.SerializeObject(response) !=null)
                //     Console.WriteLine(response[0].Description.Replace(" ", ""));
                //foreach (var annotation in response)
                //{
                //    if (annotation.Description != null)
                //        Console.WriteLine(annotation.Description);
                //    else
                //        Console.WriteLine("NOT");
                //}
                //一般HTTP_POST
                var requestContent = josn.ToString();
                var request = WebRequest.CreateHttp(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                var data = Encoding.UTF8.GetBytes(requestContent);
                request.ContentLength = data.Length;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }


                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    // 如果 StatusCode 在範圍 200-299 中，才表示 HTTP 回應成功的值。
                    if (response.StatusCode < HttpStatusCode.OK || response.StatusCode >= HttpStatusCode.MultipleChoices)
                    {
                        Console.WriteLine("error");
                    }

                    using (var responseStream = new StreamReader(response.GetResponseStream()))
                    {
                        var a = responseStream.ReadToEnd();
                        var b = JsonConvert.DeserializeObject<Google_Vision_Response>(a);
                        foreach (var i in b.responses)
                        {

                        }
                        Console.WriteLine(b.responses[0].fullTextAnnotation.text);

                    }
                }
            }
            catch (Exception ex)
            {
                //設定環境變數GOOGLE_APPLICATION_CREDENTIALS
                //安裝google sdk : Install-Package Google.Cloud.Vision.V1 -Pre
                //http://vacvin.blogspot.com/2017/09/net-google-vision-api.html
                Console.WriteLine("無法辨識");
            }
            Console.ReadKey();
        }
    }
}
