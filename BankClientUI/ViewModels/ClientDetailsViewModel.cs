﻿namespace BankClientUI.ViewModels
{
    public partial class ClientDetailsViewModel : BaseViewModel
    {
        public bool CanAdd;
        public bool CanDelete;
        [ObservableProperty]
        private string firstName;
        [ObservableProperty]
        private string secondName;
        [ObservableProperty]
        private string lastName;
        [ObservableProperty]
        private string phone;
        [ObservableProperty]
        private string passport;
        [ObservableProperty]
        private DateTime created;
        [ObservableProperty]
        private string createdBy;
        [ObservableProperty]
        private DateTime updated;
        [ObservableProperty]
        private string updatedBy;
        [ObservableProperty]
        private string updateInfo;

        private Client client;
        private readonly IWorker worker;
        private readonly string accessToken = "manager";


        public ClientDetailsViewModel(Client client, IWorker worker)
        {
            this.client = client;
            this.worker = worker;
            UpdateFields();
        }

        private void UpdateFields()
        {
            CanAdd = (worker.GetAccess() == accessToken) ? true : false;
            CanDelete = (worker.GetAccess() == accessToken) ? true : false;
            FirstName = client.GetFirstName();
            SecondName = client.GetSecondName();
            LastName = client.GetLastName();
            Phone = (worker.GetAccess() == accessToken) ? client.GetPhone() : "permission denied";
            Passport = (worker.GetAccess() == accessToken) ? client.GetPassport() : "permission denied";
            RecordInfo recordInfo = client.GetRecordInfo();
            Created = recordInfo.GetRecordCreationDate();
            CreatedBy = recordInfo.GetRecordCreationPerson();
            Updated = recordInfo.GetRecordUpdatedDate();
            UpdatedBy = recordInfo.GetRecordUpdatedPerson();
            UpdateInfo = recordInfo.GetRecordUpdatedInfo();
        }


    }
}
