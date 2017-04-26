using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TestXmlEscape();
//            TestSimpleMethod();
//            TestSimpleMethodCompoundCall();
            TestBizagiTimeOut();
            TestBizagi();
        }

        private static void TestSimpleMethod()
        {
            StreamReader fs = new StreamReader("SOAPMessage.txt");
            string message = fs.ReadToEnd();
            string url = "http://localhost:30084/Service1.svc";// "http://www.dneonline.com/calculator.asmx?wsdl";
            string soapAction = "http://tempuri.org/IService1/GetData";


            Console.WriteLine(SOAPClient.SOAPUtil.Call(url, soapAction, message));
        }

        private static void TestSimpleMethodCompoundCall()
        {
            StreamReader fs = new StreamReader("SOAPMessage.txt");
            string message = fs.ReadToEnd();
            string url = "http://localhost:30084/Service1.svc";// "http://www.dneonline.com/calculator.asmx?wsdl";
            string soapAction = "http://tempuri.org/IService1/GetData";

            var web = SOAPClient.SOAPUtil.CreateWebRequest(url, soapAction);
            var result = SOAPClient.SOAPUtil.InvokeWS(web, message);
            Console.WriteLine(result);
        }

        private static void TestBizagi()
        {
            StreamReader fs = new StreamReader("SOAPCreateCase.txt");
            string message = fs.ReadToEnd();
            string url = "http://slk30as1010v/PROJ_PHOENIX/Webservices/workflowenginesoa.asmx";
            string soapAction = "http://tempuri.org/createCasesAsString";

            Console.WriteLine(SOAPClient.SOAPUtil.Call( url, "sharelnk30.net", "juan.crossley", "Bizagi2018", soapAction, message));
        }

        private static void TestXmlEscape()
        {
            string unescaped = "<>&\"'";
            string escaped = "&lt;&gt;&amp;&quot;&apos;";

            string resultUnescaped = SOAPClient.XmlHelper.UnescapeXml(escaped);
            Debug.Assert(resultUnescaped.CompareTo(unescaped) == 0);
            string resultEscaped = SOAPClient.XmlHelper.EscapeXml(unescaped);
            Debug.Assert(resultEscaped.CompareTo(escaped) == 0);
        }

        private static void TestBizagiTimeOut()
        {
            StreamReader fs = new StreamReader("SOAPCreateCase.txt");
            string message = fs.ReadToEnd();
            string url = "http://slk30as1010v/PROJ_PHOENIX/Webservices/workflowenginesoa.asmx";
            string soapAction = "http://tempuri.org/createCasesAsString";

            var web = SOAPClient.SOAPUtil.CreateWebRequest(url, soapAction);
            SOAPClient.SOAPUtil.SetTimeout(web, 60000);
            SOAPClient.SOAPUtil.AddAuthentication(web, "sharelnk30.net", "juan.crossley", "Bizagi2018");
            var result = SOAPClient.SOAPUtil.InvokeWS(web, message);
            Console.WriteLine(result);
        }
    }
}
