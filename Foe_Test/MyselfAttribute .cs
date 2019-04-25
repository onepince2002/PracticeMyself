using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;//應用反映(反射)技術獲得特性信息

namespace Foe_Test
{
    class ReportDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public ReportDescriptionAttribute(string Description)
        {
            this.Description = Description+"bbbb";
        }

        public override string ToString()
        {
            return this.Description+"RRRRR";
        }
    }

    class TestAttribute : Attribute
    {
        public string Description { get; set; }

        public TestAttribute(string Description)
        {
            this.Description = Description + "QQQ";
        }

        public override string ToString()
        {
            return this.Description + "SSSSS";
        }
    }


    class run2
    {
        public string aa() 
        {
            var reportType = ReportType.All;
            var members = typeof(ReportType).GetMember(reportType.ToString());
            var attributes = members[0].GetCustomAttributes(typeof(ReportDescriptionAttribute), false);
            var attributes1 = members[0].GetCustomAttributes(typeof(TestAttribute), false).FirstOrDefault();
            var description = ((ReportDescriptionAttribute)attributes[0]).Description;

            var a = new sutd
            {
                _age="1"
            };
            var asd = a.age;
            return description;
        }
    }

    public class sutd
    {
        public string _age;

        [Test("TEST1")]
        public int age
        {
            get { return Convert.ToInt32(_age); }
            set { _age = (value).ToString(); }
        }
    }

    public enum ReportType
{
            /// 310 全部發送清單 
            /// <summary>
            /// 310 全部發送清單
            /// </summary>
            [ReportDescription("全部發送清單")]
            [Test("TEST1")]
            All = 310,

                /// 320 成功發送清單
                /// <summary>
                /// 320 成功發送清單
                /// </summary>
                [ReportDescription("成功發送清單")]
                [Test("TEST2")]
        Succeed = 320,

                /// 330 傳送中清單
                /// <summary>
                /// 330 傳送中清單
                /// </summary>
                [ReportDescription("傳送中清單")]
            Sending = 330,

                /// 340 預約簡訊清單
                /// <summary>
                /// 340 預約簡訊清單
                /// </summary>
                [ReportDescription("預約簡訊清單")]
            PreSend = 340,

                /// 350 逾期簡訊清單
                /// <summary>
                /// 350 逾期簡訊清單
                /// </summary>
                [ReportDescription("逾期簡訊清單")]
            Timeout = 350,

                /// 360 發送失敗清單
                /// <summary>
                /// 360 發送失敗清單
                /// </summary>
                [ReportDescription("發送失敗清單")]
            Fail = 360,

                /// 370 回覆簡訊清單
                /// <summary>
                /// 370 回覆簡訊清單
                /// </summary>
                [ReportDescription("回覆簡訊清單")]
            Reply = 370,
    }
    class run
    {
        static void Main(string[] args)
        {
            try
            {
                //var a=new run2();
                //var aasd=a.aa();
                string a = "asd";
                var b = catchtest(a);
            }
            catch (AppEzPaymentException ex1)
            {
                Console.WriteLine(ex1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }


        public static int catchtest(string a)
        {
            try
            {
                
                return Convert.ToInt16(a); 
            }
            catch(Exception ex)
            {
                throw new AppEzPaymentException(UniversalStatus.Failed);
            }
        }
    }

    public enum UniversalStatus
    {
        [Description("失敗")]
        Failed = 0,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1,
    }

    public class AppEzPaymentException : ApplicationException
    {
        /// <summary>
        /// 例外狀況代碼欄位
        /// </summary>
        private UniversalStatus _Code;
        private UniversalStatus code { get { return _Code; } }
        private string v;
        private object p;

        public AppEzPaymentException(UniversalStatus code) :
            this(code, GetCodeDescription(code), null)
        {
        }

        public AppEzPaymentException(UniversalStatus code1, string v, Exception ex)
        {
            this.v = v;
        }

        public static string GetCodeDescription(UniversalStatus code)
            {
                var field = code.GetType().GetField(code.ToString());
                var desc = (DescriptionAttribute)
                    field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
                return (desc != null) ? desc.Description : string.Empty;
            }
        }

    }
