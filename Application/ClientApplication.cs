using STC.DTOs.ClientDto;
using STC.Models;
using STC.Services;
using STC.View.ClientViewModel;

namespace STC.Application
{
    public class ClientApplication
    {
        private ClientService clientService = new ClientService();

        public async Task<Client> CreateClient(CreateClientDTO model)
        {
            Client clientCreate = new Client
            {
                CliName = model.CliName,
                CliNameMother = model.CliNameMother,
                CliNameFather = model.CliNameFather,
                CliBirthDate = model.CliBirthDate,
                CliAddressStreet = model.CliAddressStreet,
                CliAddressNeighborhood = model.CliAddressNeighborhood,
                CliAddressFull = model.CliAddressFull,
                CliAddressNumber = model.CliAddressNumber,
                CliAddressCity = model.CliAddressCity,
                CliSchool = model.CliSchool,
                CliSchoolGrade = model.CliSchoolGrade,
                CliSchoolCity = model.CliSchoolCity,
                CliSchoolState = model.CliSchoolState,
                CliPhoneNumber = model.CliPhoneNumber,
                CliPhoneCell = model.CliPhoneCell,
                CliNote = model.CliNote,
                CliActive = model.CliActive,
            };

            await clientService.CreateClient(clientCreate);

            return clientCreate;
        }

        public async Task<List<ClientViewModel>> GetAllClientAsync()
        {
            List<Client> clients = await clientService.GetAllUser();
            List<ClientViewModel> clientView = new List<ClientViewModel>();

            foreach (var item in clients)
            {
                ClientViewModel model = new ClientViewModel();
                model.CliId = item.CliId;
                model.CliName = item.CliName;
                model.CliNameMother = item.CliNameMother;
                model.CliNameFather = item.CliNameFather;
                model.CliBirthDate = item.CliBirthDate;
                model.CliAddressStreet = item.CliAddressStreet;
                model.CliAddressNeighborhood = item.CliAddressNeighborhood;
                model.CliAddressFull = item.CliAddressFull;
                model.CliAddressNumber = item.CliAddressNumber;
                model.CliAddressCity = item.CliAddressCity;
                model.CliSchool = item.CliSchool;
                model.CliSchoolGrade = item.CliSchoolGrade;
                model.CliSchoolCity = item.CliSchoolCity;
                model.CliSchoolState = item.CliSchoolState;
                model.CliPhoneNumber = item.CliPhoneNumber;
                model.CliPhoneCell = item.CliPhoneCell;
                model.CliNote = item.CliNote;
                model.CliActive = item.CliActive;

                clientView.Add(model);
            }

            return clientView;
        }

        public async Task<ClientViewModel> GetClientById(int cliId)
        {
            var client = await clientService.GetUserById(cliId);

            var clientView = new ClientViewModel
            {
                CliId = client.CliId,
                CliName = client.CliName,
                CliNameMother = client.CliNameMother,
                CliNameFather = client.CliNameFather,
                CliBirthDate = client.CliBirthDate,
                CliAddressStreet = client.CliAddressStreet,
                CliAddressNeighborhood = client.CliAddressNeighborhood,
                CliAddressFull = client.CliAddressFull,
                CliAddressNumber = client.CliAddressNumber,
                CliAddressCity = client.CliAddressCity,
                CliSchool = client.CliSchool,
                CliSchoolGrade = client.CliSchoolGrade,
                CliSchoolCity = client.CliSchoolCity,
                CliSchoolState = client.CliSchoolState,
                CliPhoneNumber = client.CliPhoneNumber,
                CliPhoneCell = client.CliPhoneCell,
                CliNote = client.CliNote,
                CliActive = client.CliActive,
            };

            return clientView;
        }
    }
}