using System;
using System.Collections.Generic;
using DemoTests.AttributesExample;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace DemoTests {
    public class UnitTest1 {
        private readonly ITestOutputHelper testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper) {
            this.testOutputHelper = testOutputHelper;
        }



        
        
        [Fact]
        public void ActionsFuncAndPredicates() {
            Action echoString = () => testOutputHelper.WriteLine("hey");
            echoString();

            Action<string> echoGivenString = str => testOutputHelper.WriteLine(str);
            echoGivenString("hey");

            Func<string> returnString = () => "hey";
            string returned = returnString();

            Func<int, string> returnNumberAsString = number => number.ToString();
            string number = returnNumberAsString(10);

            Predicate<string> compareStrings = str => str.Equals("hey");
            bool result = compareStrings("Faxe kondi");
        }







        #region other tests

        
        [Fact]
        public void Attributes() {
            
            var transactions = new List<PaymentTransaction> {
                new() { Account = "DK001", BeneficiaryAccount = "DK002", Amount = 123 },
                new() { Account = "DK123", BeneficiaryAccount = "DK456", Amount = 1000 }
            };

            var accounts = new List<AccountInformation>() {
                new() { Account = "DK001", Owner = "Nicklas Millard", CurrentBalance = 30 },
                new() { Account = "DK003", Owner = "Emma", CurrentBalance = 1_000_000 }
            };
            
            /*
            Same transaction represented in multiple ways depending on a formatter
            
            plain text
            Account: DK0001, BeneficiaryAccount: DK0002, Amount: 123
            Account: DK123, BeneficiaryAccount: DK456, Amount: 1000
            
            csv
            ACCCOUNT,BENEFICIARY_ACCOUNT,AMOUNT
            "DK0001","DK0002",123
            "DK123","DK456",1000
           */
            
            
            // common DI container in .NET apps
            IServiceCollection services = new ServiceCollection()
                .AddTransient<IFileFormatter, CsvFormatter>()
                .AddTransient<IFileFormatter, PlainTextFormatter>();

            IEnumerable<IFileFormatter> formatters = services.BuildServiceProvider().GetServices<IFileFormatter>();

            string result = formatters.PickFormatter(FileFormat.Csv)?.Format(accounts);

        }


        [Fact]
        public void ParameterModifiers() {
            void PassValueByReference(ref MyStruct myStruct) {
                testOutputHelper.WriteLine(myStruct.Title);
            }

            var myStruct = new MyStruct { Title = "Some title" };

            PassValueByReference(ref myStruct);
        }

        #endregion
    }
}