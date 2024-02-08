namespace BankClientUI.Models
{
    public class Client
    {
        [JsonProperty]
        private string firstName { get; set; }
        [JsonProperty]
        private string secondName { get; set; }
        [JsonProperty]
        private string lastName { get; set; }
        [JsonProperty]
        private string phone { get; set; }
        [JsonProperty]
        private string passport { get; set; }
        [JsonProperty]
        private RecordInfo recordInfo { get; set; }

        public Client(string firstName, string secondName, string lastName, string phone, string passport, string createdBy)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
            this.phone = phone;
            this.passport = passport;
            this.recordInfo = new RecordInfo(createdBy);
        }
        [JsonConstructor]
        public Client(string firstName, string secondName, string lastName, string phone, string passport, RecordInfo recordInfo)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
            this.phone = phone;
            this.passport = passport;
            this.recordInfo = recordInfo;
        }

        public void SetFirstname(string firstName) => this.firstName = firstName;
        public void SetSecondname(string secondName) => this.secondName = secondName;
        public void SetLastName(string lastName) => this.lastName = lastName;
        public void Setphone(string phone) => this.phone = phone;
        public void SetPassport(string passport) => this.passport = passport;

        public string GetFirstName() => this.firstName;
        public string GetSecondName() => this.secondName;
        public string GetLastName() => this.lastName;
        public string GetPhone() => this.phone;
        public string GetPassport() => this.passport;
        public RecordInfo GetRecordInfo() => this.recordInfo;

        public override string ToString()
        {
            return $"Client Info:\n{firstName} {secondName} {lastName}\nPhone: {phone}\nPassport: {passport}\n{recordInfo}";
        }
    }
}
