using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSimpleMethod();
            TestSimpleMethodCompoundCall();
            TestBizagi();
            TestBizagiTimeOut();
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
            string url = "http://cross-vm/Test107/WebServices/workflowenginesoa.asmx";
            string soapAction = "http://tempuri.org/createCasesAsString";

            Console.WriteLine(SOAPClient.SOAPUtil.Call( url, "", "crossleyjuan@gmail.com", "cher2005", soapAction, message));
        }

        private static void TestBizagiTimeOut()
        {
            StreamReader fs = new StreamReader("SOAPCreateCase.txt");
            string message = fs.ReadToEnd();
            string url = "http://cross-vm/Test107/WebServices/workflowenginesoa.asmx";
            string soapAction = "http://tempuri.org/createCasesAsString";

            var web = SOAPClient.SOAPUtil.CreateWebRequest(url, soapAction);
            SOAPClient.SOAPUtil.SetTimeout(web, 60000);
            SOAPClient.SOAPUtil.AddAuthentication(web, "", "crossleyjuan@gmail.com", "cher2005");
            var result = SOAPClient.SOAPUtil.InvokeWS(web, message);
            Console.WriteLine(result);
        }
    }
}
