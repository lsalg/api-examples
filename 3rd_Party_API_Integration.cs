//function searches employees by ID
        [WebMethod]
        public string SearchEmployee(string id)
        {
            //serialization 
            JavaScriptSerializer jsStatus = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue };
            string strResult = string.Empty;
            
            //For Basic Authentication
            AuthObj aObj = new AuthObj();
            //sets security protocol used by service point 
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            
            //create authentication to connect to api
            string authInfo = aObj.client_id + ":" + aObj.client_key;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            string url = "https://api.THIRD_PARTY_API.com/api/users/external_lookup/" + id;
 
            //creates uri object with URL above
            Uri myUri = new Uri(url);

            //creates a request for the URL
            WebRequest myWebRequest = HttpWebRequest.Create(myUri);
            //creates request http
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
            //sets authenticatation to true
            myHttpWebRequest.PreAuthenticate = true;
            //adds header property for the authorization 
            myHttpWebRequest.Headers.Add("Authorization", "Basic " + authInfo);
            //sets api type method to GET
            myHttpWebRequest.Method = "GET";
            //sets acceptable return value to json
            myHttpWebRequest.Accept = "application/json";
            //sets content type to json
            myHttpWebRequest.ContentType = "application/json";
 
            //creates response object
            HttpWebResponse result;
            WebResponse myWebResponse;

            try
            {
                //gets the response from the request
                myWebResponse = myWebRequest.GetResponse();
                //gets response of the request
                Stream responseStream = myWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);
                //reades contents from the reader
                string pageContent = myStreamReader.ReadToEnd();
                //closes connection
                responseStream.Close();
                myWebResponse.Close();
                //serializes page contents into the string
                strResult = jsStatus.Serialize(pageContent);
            }
            catch (WebException ex)
            {
                strResult = jsStatus.Serialize("DNE");
            }        
            return strResult;
        }
