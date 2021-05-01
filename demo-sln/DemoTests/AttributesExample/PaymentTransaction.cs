namespace DemoTests.AttributesExample {
    
    public class PaymentTransaction : StorageBase {
        [CsvInfo("ACCOUNT", typeof(EscapedString))]
        public string Account { get; set; }
        
        [CsvInfo("BENEFICIARY_ACCOUNT", typeof(EscapedString))]
        public string BeneficiaryAccount { get; set; }
        
        [CsvInfo("AMOUNT", typeof(NoFormatting))]
        public decimal Amount { get; set; }
    }


    public class AccountInformation : StorageBase {
        [CsvInfo("ACCOUNT", typeof(EscapedString))]
        public string Account { get; set; }
        
        [CsvInfo("OWNER", typeof(EscapedString))]
        public string Owner { get; set; }
        
        [CsvInfo("CURRENT_BALANCE", typeof(MoneyFormatting))]
        public decimal CurrentBalance { get; set; }
    }
}