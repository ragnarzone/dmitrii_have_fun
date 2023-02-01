using System;
using System.Net.Http.Headers;
   
class Program {  
    static async Task Main(string[] args) {  
            //Console.WriteLine(getTimestamp());
            //generateMessage();
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            await ProcessRepositoriesAsync(client);   
    }


    // function to return current timestamp according to IPC2541
    static string getTimestamp(){
        string format = "o";  
        string now = DateTime.Now.ToString(format);  
        return now;
    }

    static async Task ProcessRepositoriesAsync(HttpClient client)
 {
     var json = await client.GetStringAsync(
         "https://api.github.com/orgs/dotnet/repos");

     Console.Write(json);
 }

    // function to generate xml message
    static void generateMessage(){

        // set of variable parameters
        string contentLength = "some string";
        string sender = "some string";
        string now = getTimestamp();
        string itemInstanceId = "some string";
        string laneId = "some string";
        string zoneId = "some string";
        string scannerId = "some string";

        string[] toWrite = {
            "---BOUNDARY-",
            "Content-Type: text/xml",
            "Content-Transfer-Encoding: 8bit",
            "Content-Length: " + contentLength + "",
            "\n",
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>",
            "<soap-env:Envelope xmlns:soap-env=\"http://schemas.xmlsoap.org/soap/envelope/\">",
            "<soap-env:Header>",
            "<ipc2502mh:MessageInfo\n xmlns:ipc2501mh=\"http://webstds.ipc.org/2501/MessageInfo.xsd\"\n " +
            "soap-env:actor=\"Jabil.TIS.CAMXSwitch.Listener\"\n" + 
            " sender=\"" + sender + "\" \n" +
            " destination=\"Jabil.TIS.CAMXSwitch.Listener\" \n" +
            " dateTime=\"" + now + "\"\n" + 
            " messageSchema=\"http://webstds.ipc.org/2541/ItemIdentifierRead.xsd\"\n" +
            " messageId=\"CAMX-API\"\n" +  
            " />",
            "</soap-env:Header>",
            "</soap-env:Envelope>",
            "\n",
            "---BOUNDARY-",
            "Content-Type: text/xml",
            "Content-Transfer-Encoding: 8bit",
            "Content-ID: CAMX-API",
            "Content-Length: " + contentLength + "",
            "\n",
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>",
            "<ItemIdentifierRead", 
            "\tdateTime=\"" + now + "\"",
            "\titemInstanceId=\"" + itemInstanceId + "\"",
            "\tlaneId=\"" + laneId + "\"",
            "\tzoneId=\"" + zoneId + "\"",
            "\tscannerId=\"" + scannerId + "\"",
            "/>",
            "---BOUNDARY---"
        };

        File.WriteAllLines("message.xml", toWrite);
    }

}  