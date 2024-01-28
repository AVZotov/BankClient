namespace BankClientUI.Models
{
    public class RecordInfo
    {
        [JsonProperty]
        private DateTime created { get; set; }
        [JsonProperty]
        private string createdBy { get; set; }
        [JsonProperty]
        private DateTime updated { get; set; }
        [JsonProperty]
        private string updatedBy { get; set; } = string.Empty;
        [JsonProperty]
        private string updateInfo { get; set; }

        public RecordInfo(string createdBy)
        {
            created = DateTime.Now;
            updated = created;
            this.createdBy = createdBy;
            this.updatedBy = "Record never updated";
            this.updateInfo = "Record created";
        }

        public void SetRecordUpdateDate(DateTime updated) => this.updated = updated;
        public void SetRecordUpdatePerson(string person) => this.updatedBy = person;
        public void SetRecordUpdateInfo(string info) => this.updateInfo = info;

        public DateTime GetRecordCreationDate() => created;
        public string GetRecordCreationPerson() => createdBy;
        public DateTime GetRecordUpdatedDate() => updated;
        public string GetRecordUpdatedPerson() => updatedBy;
        public string GetRecordUpdatedInfo() => updateInfo;

        public override string ToString()
        {
            return $"Record created {created} by {createdBy}.\nLast modification {updated} by {updatedBy}." +
                $"\nDetails on update:\n{updateInfo}";
        }
    }
}
